using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Threading;
using System.Threading.Tasks;
using MovieScanner.Entities;

namespace MovieScannerTest
{
    using Microsoft.Extensions.DependencyInjection;
    using MovieScanner.Common;
    using MovieScanner.DataStorage;
    using Xunit;
    public class MovieStorageTest
    {
        [Fact]
        public async Task OverrideMovieListTest()
        {
            // BUGBUG : Only works on my machine
            string path = "L:\\Film";

            var services = DependencyInjection.GetServiceProvider(path);

            var fileMovieStorage = services.GetService<IMovieStorage>();

            List<Movie> movies = new List<Movie>();
            
            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Harry Potter.avi",
                Resolution = Resolution.FourK,
                Size = 45.6,
                Title = "Harry Potter"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Matrix.avi",
                Resolution = Resolution.FullHD,
                Size = 45.6,
                Title = "Matrix"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Kamelott.avi",
                Resolution = Resolution.HD,
                Size = 45.6,
                Title = "Kamelott"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Harry Potter.avi",
                Resolution = Resolution.FourK,
                Size = 45.6,
                Title = "Harry Potter"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Matrix.avi",
                Resolution = Resolution.FullHD,
                Size = 45.6,
                Title = "Matrix"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Kamelott.avi",
                Resolution = Resolution.HD,
                Size = 45.6,
                Title = "Kamelott"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Harry Potter.avi",
                Resolution = Resolution.FourK,
                Size = 45.6,
                Title = "Harry Potter"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Matrix.avi",
                Resolution = Resolution.FullHD,
                Size = 45.6,
                Title = "Matrix"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Kamelott.avi",
                Resolution = Resolution.HD,
                Size = 45.6,
                Title = "Kamelott"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Harry Potter.avi",
                Resolution = Resolution.FourK,
                Size = 45.6,
                Title = "Harry Potter"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Matrix.avi",
                Resolution = Resolution.FullHD,
                Size = 45.6,
                Title = "Matrix"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Kamelott.avi",
                Resolution = Resolution.HD,
                Size = 45.6,
                Title = "Kamelott"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Harry Potter.avi",
                Resolution = Resolution.FourK,
                Size = 45.6,
                Title = "Harry Potter"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Matrix.avi",
                Resolution = Resolution.FullHD,
                Size = 45.6,
                Title = "Matrix"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Kamelott.avi",
                Resolution = Resolution.HD,
                Size = 45.6,
                Title = "Kamelott"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Harry Potter.avi",
                Resolution = Resolution.FourK,
                Size = 45.6,
                Title = "Harry Potter"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Matrix.avi",
                Resolution = Resolution.FullHD,
                Size = 45.6,
                Title = "Matrix"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Kamelott.avi",
                Resolution = Resolution.HD,
                Size = 45.6,
                Title = "Kamelott"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Harry Potter.avi",
                Resolution = Resolution.FourK,
                Size = 45.6,
                Title = "Harry Potter"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Matrix.avi",
                Resolution = Resolution.FullHD,
                Size = 45.6,
                Title = "Matrix"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Kamelott.avi",
                Resolution = Resolution.HD,
                Size = 45.6,
                Title = "Kamelott"
            });
            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Harry Potter.avi",
                Resolution = Resolution.FourK,
                Size = 45.6,
                Title = "Harry Potter"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Matrix.avi",
                Resolution = Resolution.FullHD,
                Size = 45.6,
                Title = "Matrix"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Kamelott.avi",
                Resolution = Resolution.HD,
                Size = 45.6,
                Title = "Kamelott"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Harry Potter.avi",
                Resolution = Resolution.FourK,
                Size = 45.6,
                Title = "Harry Potter"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Matrix.avi",
                Resolution = Resolution.FullHD,
                Size = 45.6,
                Title = "Matrix"
            });

            movies.Add(new Movie()
            {
                HardDrive = "01",
                Path = path + "\\Kamelott.avi",
                Resolution = Resolution.HD,
                Size = 45.6,
                Title = "Kamelott"
            });

            await fileMovieStorage.OverrideMovieListAsync(movies, path + "\\jsonTestSave.json", CancellationToken.None);

            // TODO : Read & assert

        }
    }
}
