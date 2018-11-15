using MovieScanner.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieScanner.Services
{
    public interface IMovieService
    {
        /// <summary>
        /// Scan movies, store them, and return list of new movies inserted
        /// </summary>
        /// <param name="storageMode"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        List<Movie> ScanMoviesAndStoreThem(StorageMode storageMode, params string[] path);
        
    }
}
