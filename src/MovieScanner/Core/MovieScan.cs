namespace MovieScanner.Core
{
    using System;
    using System.Threading;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.Extensions.Logging;
    using Rules;
    using Entities;
    public class MovieScan : IMovieScan
    {
        private readonly ILogger _logger;
        private readonly string[] _validMovieExtensions;

        public MovieScan(ILogger<MovieScan> logger)
        {
            _logger = logger;

            // BUGBUG: This list will be outdated one day. 
            // Source: november 19, 2018 https://en.wikipedia.org/wiki/Video_file_format
            _validMovieExtensions = new[]
            {
                ".webm", ".mkv", ".flv", ".vob", ".ogv", ".ogg", ".frc", ".gif", ".gifv", ".mng", ".avi", ".mts", ".m2ts", ".mov", ".qt", ".wmv", ".yuv",
                ".rm", ".rmvb", ".asf", ".amv", ".mp4", ".m4p", ".m4v", ".mpg", ".mp2", ".mpeg", ".mpe", ".mpv", ".mpg", ".mp2", ".mpeg", ".mpe", ".mpv",
                ".mpg", ".mpeg", ".m2v", ".m4v", ".svi", ".3gp", ".3g2", ".mxf", ".roq", ".nsv", ".flv", ".f4v", ".f4p", ".f4a", ".f4b"
            };
        }

        public List<Movie> ScanForMovies(string path, CancellationToken ct)
        {
            List<Movie> movies = new List<Movie>();
            ScanForMovies(movies, path, ct);
            return movies;
        }

        private void ScanForMovies(List<Movie> movies, string path, CancellationToken ct)
        {
            _logger.LogInformation($"Scan {path} started");

            string hardDrive = GeneralRules.GetHardDrive(path);

            try
            {
                foreach (var filePath in Directory.EnumerateFiles(path))
                {
                    if (TryGetMovie(filePath, hardDrive , out Movie movie))
                    {
                        movies.Add(movie);
                    }
                }

                ct.ThrowIfCancellationRequested();

                foreach (var directoryPath in Directory.EnumerateDirectories(path))
                {
                    ScanForMovies(movies, directoryPath, ct);
                }

                ct.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException oce)
            {
                _logger.LogError(oce, $"Operation was cancelled while scanning movies in {path}");
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, $"Couldn't scan for movies in {path} due to critical error.");
            }
        }


        
        private bool TryGetMovie(string filePath, string hardDrive, out Movie movie)
        {
            var fileInfo = new FileInfo(filePath);
            if (!_validMovieExtensions.Contains(fileInfo.Extension))
            {
                _logger.LogWarning($"File ignored: {fileInfo.Name} because extension {fileInfo.Extension} does not match with list for video file formats.");
                movie = null;
            }
            else
            {
                movie = new Movie()
                {
                    Path = filePath,
                    Title = Path.GetFileNameWithoutExtension(filePath),
                    Size = fileInfo.Length,
                    Resolution = Resolution.Unknown,
                    HardDrive = hardDrive
                };
                _logger.LogInformation($"Movie found : {movie.Title}");
            }

            return movie != null;
        }


    }
}
