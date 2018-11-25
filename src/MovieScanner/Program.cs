using System.Collections.Generic;

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
            CancellationToken ct = new CancellationToken();
            
            var parser = new ArgsParser();
            (Command Command, List<string> Arguments, UserOptions Options) userInput = (Command.Unknown, null, null);
            try
            {
                userInput = parser.GetCommand(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Try {Command.Help} command by typing MovieScan {Command.Help}");
            }


            switch (userInput.Command)
            {
                case Command.Unknown:
                    // When user input parsing threw an exception.
                    break;
                case (Command.Scan):
                case (Command.ScanMultiple):
                    {
                        var services = DependencyInjection.GetServiceProvider(logPath: userInput.Arguments[0]);
                        var movieService = services.GetService<IMovieService>();

                        await movieService.ScanMoviesAndStoreThemAsync(userInput.Options.StorageMode, ct,
                            userInput.Arguments.ToArray());
                        break;
                    }
                case Command.Exists:
                    // TODO
                    break;
                case Command.Help:
                    // TODO
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }
    }
}
