using MovieScanner.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieScanner.DataStorage
{
    public interface IMovieStorage
    {
        /// <summary>
        /// Will override movie list stored
        /// </summary>
        /// <param name="movies"></param>
        Task OverrideMovieListAsync(List<Movie> movies, string filePath, CancellationToken ct);

        /// <summary>
        /// Merge movies with existing movies
        /// Will add movies not already in the list
        /// </summary>
        /// <param name="movies"></param>
        Task AppendMovieListAsync(List<Movie> movies, string filePath, CancellationToken ct);

        /// <summary>
        /// Check if movie exist in existing data stored
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(Movie movie, string filePath, CancellationToken ct);

        /// <summary>
        /// Return every movies which title contains key word
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        Task<List<Movie>> SearchMoviesByTitleAsync(string keyWord, string filePath, CancellationToken ct);

        /// <summary>
        /// Read existing data and return movies already stored
        /// </summary>
        /// <returns></returns>
        Task<List<Movie>> GetStoredMoviesAsync(string filePath, CancellationToken ct);
    }
}
