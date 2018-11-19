using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using MovieScanner.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MovieScanner.DataStorage
{
    class XmlMovieStorage : IMovieStorage
    {
        private readonly ILogger _logger;
        private readonly string _storagePath;

        public XmlMovieStorage(ILogger<XmlMovieStorage> logger, IOptions<XmlMovieStorageOptions> options)
        {
            _logger = logger;
            _storagePath = options.Value.StoragePath;
        }

        public void OverrideMovieList(List<Movie> movies)
        {
            _logger.LogInformation("Overriding movie list");
            throw new NotImplementedException();
        }

        public void MergeMovieList(List<Movie> movies)
        {
            _logger.LogInformation("Merging movie list");
            throw new NotImplementedException();
        }

        public bool Exists(Movie movie)
        {
            _logger.LogInformation($"Looking for match between movie list and {movie.Title}");
            throw new NotImplementedException();
        }

        public List<Movie> SearchMoviesByTitle(string keyWord)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetStoredMovies()
        {
            throw new NotImplementedException();
        }
    }

    public static class XmlMovieStorageExtension
    {
        public static IServiceCollection AddXmlMovieStorage(this IServiceCollection services, Action<XmlMovieStorageOptions> configure)
        {
            services.AddTransient<IMovieStorage, XmlMovieStorage>()
                .Configure(configure);

            return services;
        }
    }

    public class XmlMovieStorageOptions
    {
        public string StoragePath { get; set; }
    }

}
