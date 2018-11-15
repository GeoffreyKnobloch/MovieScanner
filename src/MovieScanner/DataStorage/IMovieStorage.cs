using MovieScanner.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieScanner.DataStorage
{
    public interface IMovieStorage
    {
        /// <summary>
        /// Will override movie list stored
        /// </summary>
        /// <param name="movies"></param>
        void OverrideMovieList(List<Movie> movies);

        /// <summary>
        /// Merge movies with existing movies
        /// Will add movies not already in the list
        /// </summary>
        /// <param name="movies"></param>
        void MergeMovieList(List<Movie> movies);

        /// <summary>
        /// Check if movie exist in existing data stored
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        bool Exists(Movie movie);

        /// <summary>
        /// Return every movies which title contains key word
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        List<Movie> SearchMoviesByTitle(string keyWord);

        /// <summary>
        /// Read existing data and return movies already stored
        /// </summary>
        /// <returns></returns>
        List<Movie> GetStoredMovies();
    }
}
