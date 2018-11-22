using MovieScanner.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieScanner.Services
{
    public interface IMovieService
    {
        /// <summary>
        /// Scan movies, store them, and return list of new movies inserted
        /// </summary>
        /// <param name="storageMode"></param>
        /// <param name="ct"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        Task<List<Movie>> ScanMoviesAndStoreThemAsync(StorageMode storageMode, CancellationToken ct, params string[] paths);
        
    }
}
