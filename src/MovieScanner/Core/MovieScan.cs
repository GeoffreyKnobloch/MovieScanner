using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using MovieScanner.Entities;

namespace MovieScanner.Core
{
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
                "webm", "mkv", "flv", "vob", "ogv", "ogg", "frc", "gif", "gifv", "mng", "avi", "mts", "m2ts", "mov", "qt", "wmv", "yuv",
                "rm", "rmvb", "asf", "amv", "mp4", "m4p", "m4v", "mpg", "mp2", "mpeg", "mpe", "mpv", "mpg", "mp2", "mpeg", "mpe", "mpv",
                "mpg", "mpeg", "m2v", "m4v", "svi", "3gp", "3g2", "mxf", "roq", "nsv", "flv", "f4v", "f4p", "f4a", "f4b"
            };
        }

        public List<Movie> ScanForMovies(string path)
        {
            List<Movie> movies = new List<Movie>();
            try
            {
                foreach (var filePath in Directory.GetFiles(path))
                {
                    var movie = GetMovie(filePath);
                    if (movie != null)
                    {
                        movies.Add(movie);
                    }
                }

                foreach (var directoryPath in Directory.GetDirectories(path))
                {
                    ScanForMovies(directoryPath);
                }
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, $"Couldn't scan for movies in {path} due to critical error.");
            }

            return movies;
        }

        
        private Movie GetMovie(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            if (_validMovieExtensions.Contains(fileInfo.Extension))
            {
                _logger.LogWarning($"File ignored: {fileInfo.Name} because extension {fileInfo.Extension} does not match with list for video file formats.");
                return null;
            }

            Movie movie = new Movie()
            {
                Path = filePath,
                Title = Path.GetFileNameWithoutExtension(filePath),
                Size = fileInfo.Length,
                Resolution =  "Unknown"
            };
            _logger.LogInformation($"Movie found : {movie.Title}");

            return movie;
        }


    }
}
