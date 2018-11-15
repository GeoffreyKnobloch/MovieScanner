using System;
using System.Collections.Generic;
using System.Text;
using MovieScanner.Entities;

namespace MovieScanner.Core
{
    public interface IMovieScan
    {
        /// <summary>
        /// Scan all movies in path and underlying path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<Movie> ScanMForMovies(string path);

    }
}
