
using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace MovieScanner.DataStorage
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.Logging;
    using Entities;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    using Newtonsoft.Json;
    class JsonFileMovieStorage : IMovieStorage
    {
        private readonly ILogger _logger;
        private readonly string _storagePath;

        public JsonFileMovieStorage(ILogger<JsonFileMovieStorage> logger, IOptions<JsonMovieStorageOptions> options)
        {
            _logger = logger;
            _storagePath = options.Value.StoragePath;
        }

        public async Task OverrideMovieListAsync(List<Movie> movies, string filePath, CancellationToken ct)
        {
            _logger.LogInformation($"Overriding movie list with a list of {movies.Count} movies to {filePath}");
            
            var jsonMovies = JsonConvert.SerializeObject(movies);
            UnicodeEncoding uniCodeEncoding = new UnicodeEncoding();
            var jsonMoviesBytes = uniCodeEncoding.GetBytes(jsonMovies);

            int bufferMaxLength = 2048;

            // For logging % purpose:
            var numberOfWritesNecessary = jsonMoviesBytes.Length / bufferMaxLength;
            numberOfWritesNecessary = numberOfWritesNecessary == 0 ? 1 : numberOfWritesNecessary;
            
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                int offset = 0;
                int numberOfWrites = 0;
                while (offset < jsonMoviesBytes.Length)
                {
                    ct.ThrowIfCancellationRequested();

                    double completionPercent = (double)numberOfWrites / (double)numberOfWritesNecessary * 100d;
                    _logger.LogInformation($"File Writing completion: {completionPercent} %");

                    int chunkToWrite = bufferMaxLength;
                    if (bufferMaxLength > jsonMoviesBytes.Length - offset)
                    {
                        chunkToWrite = jsonMoviesBytes.Length - offset;
                    }

                    await fileStream.WriteAsync(jsonMoviesBytes , offset , chunkToWrite , ct);
                    

                    numberOfWrites++;
                    offset += chunkToWrite;
                }
            }
        }

        public Task AppendMovieListAsync(List<Movie> movies, string filePath, CancellationToken ct)
        {
            _logger.LogInformation("Merging movie list");
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Movie movie, string filePath, CancellationToken ct)
        {
            _logger.LogInformation($"Looking for match between movie list and {movie.Title}");
            throw new NotImplementedException();
        }

        public Task<List<Movie>> SearchMoviesByTitleAsync(string keyWord, string filePath, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> GetStoredMoviesAsync(string filePath, CancellationToken ct)
        {
            _logger.LogInformation($"Retrieving movies from {filePath}");
            throw new NotImplementedException();
        }

       
 


    }

    public static class XmlMovieStorageExtension
    {
        public static IServiceCollection AddXmlMovieStorage(this IServiceCollection services, Action<JsonMovieStorageOptions> configure)
        {
            services.AddTransient<IMovieStorage, JsonFileMovieStorage>()
                .Configure(configure);

            return services;
        }
    }

    public class JsonMovieStorageOptions
    {
        public string StoragePath { get; set; }
    }

}


#region EducacionalPurpose

// Writing from a buffer without using offset parameter on WriteAsync is always possible, but necessitate an additional byte[] which is not necessary.
// Could be necessary when reading from other source at the same time, but not in this case when all we do is writing a string.
// Additionally, all this is not necessary at all since some method like WriteAll exists ...

//public async Task OverrideMovieListAsync(List<Movie> movies, string filePath, CancellationToken ct)
//{
//_logger.LogInformation($"Overriding movie list with a list of {movies.Count} movies");

//var jsonMovies = JsonConvert.SerializeObject(movies);
//UnicodeEncoding uniCodeEncoding = new UnicodeEncoding();
//var jsonMoviesBytes = uniCodeEncoding.GetBytes(jsonMovies);

//// Writing a chunk of 2048 at a time:
//int bufferMaxLength = 2048;
//    // byte[] buffer = new byte[bufferMaxLength];


//    using (var fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
//{
//    int offset = 0;
//    while (offset < jsonMoviesBytes.Length)
//    {
//        int chunkToWrite = bufferMaxLength;
//        if (bufferMaxLength > jsonMoviesBytes.Length - offset)
//        {
//            //buffer = new byte[jsonMoviesBytes.Length - offset];
//            chunkToWrite = jsonMoviesBytes.Length - offset;
//        }

//        //for (int i = 0; i < buffer.Length && i + offset < jsonMoviesBytes.Length; i++)
//        //{
//        //    buffer[i] = jsonMoviesBytes[i + offset];
//        //}
//        await fileStream.WriteAsync(/*buffer*/ jsonMoviesBytes, /*0*/ offset, /*buffer.Length*/ chunkToWrite, ct);
//        offset += /*bufferMaxLength*/ chunkToWrite;
//    }
//}
//}

#endregion