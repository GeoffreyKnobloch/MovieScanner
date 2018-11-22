namespace MovieScanner.Core
{
    using System.Collections.Generic;
    using System.Threading;
    using Entities;

    public interface IMovieScan
    {
        /// <summary>
        /// Scan all movies in path and underlying path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        List<Movie> ScanForMovies(string path, CancellationToken ct);

    }
}
