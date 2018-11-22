namespace MovieScanner
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.DependencyInjection;
    using Common;
    using Services;
    using UserInterface;
    using Entities;

    class Program
    {
        static async Task Main(string[] args)
        {
            string pathToScan = "E:\\Nvidia_shield\\Movies"; /*"L:\\Film"*/
            CancellationToken ct = new CancellationToken();

            var services = DependencyInjection.GetServiceProvider(logPath: pathToScan);

            var parser = services.GetService<IArgsParser>();
            // TODO : Parse args
            // REVIEW : pathToScan must be retrieved without ArgsParser service because
            // we need pathToScan to configure logging services in order to put log file where we scan ...
                                     

            var movieService = services.GetService<IMovieService>();
            // TODO : Executes corresponding command

            await movieService.ScanMoviesAndStoreThemAsync(StorageMode.Override, ct, pathToScan);

            Console.ReadKey();
        }
    }
}
