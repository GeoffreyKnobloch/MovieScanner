using System;
using Microsoft.Extensions.DependencyInjection;
using MovieScanner.Core;
using MovieScanner.DataStorage;
using MovieScanner.Services;
using MovieScanner.UserInterface;

namespace MovieScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddTransient<IMovieStorage, XmlMovieStorage>()
                .AddTransient<IMovieScan, MovieScan>()
                .AddTransient<IMovieService, MovieService>()
                .AddTransient<IArgsParser, ArgsParser>()
                .BuildServiceProvider();

            var parser = services.GetService<IArgsParser>();
            // TODO : Parse args
            var movieService = services.GetService<IMovieService>();
            // TODO : Execute corresponding command

            Console.ReadKey();
        }
    }
}
