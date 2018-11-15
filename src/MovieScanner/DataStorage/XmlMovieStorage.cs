using System;
using System.Collections.Generic;
using System.Text;
using MovieScanner.Entities;

namespace MovieScanner.DataStorage
{
    class XmlMovieStorage : IMovieStorage
    {
        public void OverrideMovieList(List<Movie> movies)
        {
            throw new NotImplementedException();
        }

        public void MergeMovieList(List<Movie> movies)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Movie movie)
        {
            throw new NotImplementedException();
        }

        public List<Movie> SearchMoviesByTitle(string keyWord)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetStoredMovies()
        {
            throw new NotImplementedException();
        }
    }
}
