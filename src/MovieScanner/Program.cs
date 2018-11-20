using MovieScanner.Entities;

namespace MovieScanner
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Common;
    using Services;
    using UserInterface;

    class Program
    {
        static void Main(string[] args)
        {
            string pathToScan = "L:\\Film";

            var services = DependencyInjection.GetServiceProvider(logPath: pathToScan);

            var parser = services.GetService<IArgsParser>();
            // TODO : Parse args
            // REVIEW : pathToScan must be retrieved without ArgsParser service because
            // we need pathToScan to configure logging services in order to put log file where we scan ...
                                     

            var movieService = services.GetService<IMovieService>();
            // TODO : Executes corresponding command

            movieService.ScanMoviesAndStoreThem(StorageMode.Override,
                $"{pathToScan}");

            Console.ReadKey();
        }
    }
}
