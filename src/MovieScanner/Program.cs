

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
            var services = DependencyInjection.GetServiceProvider();

            var parser = services.GetService<IArgsParser>();
            // TODO : Parse args
            var movieService = services.GetService<IMovieService>();
            // TODO : Execute corresponding command

            Console.ReadKey();
        }
    }
}
