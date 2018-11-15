using System;
using System.Collections.Generic;
using System.Text;
using MovieScanner.Core;
using MovieScanner.DataStorage;
using MovieScanner.Entities;

namespace MovieScanner.Services
{
    class MovieService : IMovieService
    {
        public IMovieScan MovieScanner { get; }
        public IMovieStorage MovieStorage { get; }

        public MovieService(IMovieStorage movieStorage, IMovieScan movieScanner)
        {
            MovieStorage = movieStorage;
            MovieScanner = movieScanner;
        }

        public List<Movie> ScanMoviesAndStoreThem(StorageMode storageMode, params string[] path)
        {
            throw new NotImplementedException();
        }
    }
}
