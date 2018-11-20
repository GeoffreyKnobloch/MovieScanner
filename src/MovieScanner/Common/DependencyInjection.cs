namespace MovieScanner.Common
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Core;
    using DataStorage;
    using Services;
    using UserInterface;
    public static class DependencyInjection
    {
        public static IServiceProvider GetServiceProvider(string logPath)
        {
            string logFile = $"{logPath}\\MovieScanner.log";

            return new ServiceCollection()
                .AddSingleton(new LoggerFactory()
                    .AddConsole()
                    .AddFile(logFile))
                .AddLogging()
                .AddXmlMovieStorage(options => options.StoragePath = "storagePath")
                .AddTransient<IMovieStorage, XmlMovieStorage>()
                .AddTransient<IMovieScan, MovieScan>()
                .AddTransient<IMovieService, MovieService>()
                .AddTransient<IArgsParser, ArgsParser>()
                .BuildServiceProvider();

        }
    }
}
