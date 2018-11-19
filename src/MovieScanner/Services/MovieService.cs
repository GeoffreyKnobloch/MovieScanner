using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using MovieScanner.Core;
using MovieScanner.DataStorage;
using MovieScanner.Entities;

namespace MovieScanner.Services
{
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

        public List<Movie> ScanMoviesAndStoreThem(StorageMode storageMode, params string[] path)
        {
            throw new NotImplementedException();
        }
    }
}
