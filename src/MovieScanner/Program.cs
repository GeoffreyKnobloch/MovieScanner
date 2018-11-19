namespace MovieScanner
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Core;
    using DataStorage;
    using Services;
    using UserInterface;

    class Program
    {
        static void Main(string[] args)
        {

            var services = new ServiceCollection()
                .AddLogging(configure => { configure.AddConsole(); })
                .AddXmlMovieStorage(options => options.StoragePath = "storagePath")
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
