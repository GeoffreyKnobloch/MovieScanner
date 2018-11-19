namespace MovieScannerTest
{
    using MovieScanner.Common;
    using Xunit;
    using Microsoft.Extensions.DependencyInjection;
    using MovieScanner.Core;

    public class MovieScanTest
    {
        [Fact]
        public void ScanForMoviesTest()
        {
            // BUGBUG : Only works on my machine
            string path = "L:\\Film";
            var services = DependencyInjection.GetServiceProvider();
            var movieScan = services.GetService<IMovieScan>();

            var movies = movieScan.ScanForMovies(path);

            Assert.NotEmpty(movies);

        }
    }
}
