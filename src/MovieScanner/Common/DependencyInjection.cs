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
        public static IServiceProvider GetServiceProvider()
        {
            return new ServiceCollection()
                 .AddLogging(configure => { configure.AddConsole(); })
                 .AddXmlMovieStorage(options => options.StoragePath = "storagePath")
                 .AddTransient<IMovieStorage, XmlMovieStorage>()
                 .AddTransient<IMovieScan, MovieScan>()
                 .AddTransient<IMovieService, MovieService>()
                 .AddTransient<IArgsParser, ArgsParser>()
                 .BuildServiceProvider();

        }
    }
}
