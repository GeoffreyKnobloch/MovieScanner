namespace MovieScanner.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Core;
    using DataStorage;
    using Entities;
    using Rules;

    class MovieService : IMovieService
    {
        private readonly IMovieStorage _movieStorage;
        private readonly IMovieScan _movieScanner;
        private readonly ILogger<MovieService> _logger;

        public MovieService(IMovieStorage movieStorage, IMovieScan movieScanner, ILogger<MovieService> logger)
        {
            _movieStorage = movieStorage;
            _movieScanner = movieScanner;
            _logger = logger;
        }

        public async Task<List<Movie>> ScanMoviesAndStoreThemAsync(StorageMode storageMode, CancellationToken ct, params string[] paths)
        {
            var movies = new List<Movie>();

            List<string> hardDrives = new List<string>(paths.Length);
            string[] pathsTable = new string[paths.Length];

            for (var i = 0; i < paths.Length; i++)
            {
                var path = paths[i];
                pathsTable[i] = path;
                hardDrives.Add(GeneralRules.GetHardDrive(path));

                _logger.LogInformation($"Request scan movies on {path}");
                movies.AddRange(_movieScanner.ScanForMovies(path, ct));
            }

            hardDrives.Sort(string.Compare);

            string fileStorageName = string.Empty;

            foreach (var hardDrive in hardDrives)
            {
                fileStorageName += hardDrive + "_";
            }

            fileStorageName += "Movies.json";


            string storagePath = paths[0] + $"\\{fileStorageName}";

            ct.ThrowIfCancellationRequested();

            switch (storageMode)
            {
                case StorageMode.Override:
                {
                    _logger.LogInformation($"Request store movies on {storagePath}");
                    await _movieStorage.OverrideMovieListAsync(movies, storagePath, ct);
                    break;
                }
            }

            return movies;
        }
    }
}
