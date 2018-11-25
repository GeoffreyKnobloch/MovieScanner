using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using MovieScanner.Common;
using MovieScanner.Entities;
using Newtonsoft.Json;

namespace MovieScanner.UserInterface
{
    public class ArgsParser : IArgsParser
    {
        public (Command command, List<string> arguments, UserOptions options) GetCommand(string[] userInput)
        {
            if (userInput.Length == 0)
            {
                throw new ArgumentException($"You must specify a valid command.");
            }

            var command = Command.Unknown;
            List<string> arguments = new List<string>();
            var options = new List<string>();
            switch (userInput[0].ToLower())
            {
                case "scan":
                    if (!Directory.Exists(userInput[1]))
                    {
                        throw new ArgumentException($"{userInput[1]} is not a valid path. You must specify a valid path to use {command.GetDescription()} command.");
                    }
                    else
                    {
                        command = Command.Scan;
                        arguments.Add(userInput[1]);
                        for (int i = 2; i < userInput.Length; i++)
                        {
                            options.Add(userInput[i]);
                        }
                    }
                    break;
                case "scanmultiple":
                    command = Command.ScanMultiple;
                    if (!Directory.Exists(userInput[1]))
                    {
                        throw new ArgumentException($"{userInput[1]} is not a valid path. You must specify a valid path to use {command.GetDescription()} command.");
                    }
                    else
                    {
                        arguments.Add(userInput[1]);
                        int i = 2;
                        while (i < userInput.Length && Directory.Exists(userInput[i]))
                        {
                            arguments.Add(userInput[i]);
                            i++;
                        }

                        for (int j = i; j < userInput.Length; j++)
                        {
                            options.Add(userInput[j]);
                        }
                    }
                    break;
                case "exists":
                    command = Command.Exists;
                    if (userInput.Length < 3)
                    {
                        throw new ArgumentException($"You must specify a movie to look for and a json file to use command {command.GetDescription()}");
                    }
                    else
                    {
                        // movie to look for:
                        arguments.Add(userInput[1]);
                        // where to look for:
                        if (!File.Exists(userInput[2]))
                        {
                            throw new ArgumentException($"You must specify a json file to use command {command.GetDescription()}");
                        }
                        else
                        {
                            var fileInfo = new FileInfo(userInput[2]);
                            if (fileInfo.Extension != ".json")
                            {
                                throw new ArgumentException($"You must specify a json file (*.json) containing stored movies to use command {command.GetDescription()}");
                            }
                            else
                            {
                                arguments.Add(userInput[2]);
                                for (int i = 2; i < userInput.Length; i++)
                                {
                                    options.Add(userInput[i]);
                                }
                            }
                        }
                    }
                    break;
                case "help":
                    command = Command.Help;
                    if (userInput.Length > 1)
                    {
                        var existingCommands = Enum.GetValues(typeof(Command)).Cast<Command>();
                        foreach (var existingCommand in existingCommands)
                        {

                            if (userInput[1].Equals(existingCommand.GetDescription(),
                                StringComparison.InvariantCultureIgnoreCase))
                            {
                                arguments.Add(userInput[1]);
                                break;
                            }
                        }

                        if (!arguments.Any())
                        {
                            throw new ArgumentException($"Can't get help on {userInput[1]} because it is not a valid command.\n{command.GetDescription()} doesn't take any options.");
                        }

                        if (userInput.Length > 2)
                        {
                            throw new ArgumentException($"{command.GetDescription()} accepts at most one argument.\n{command.GetDescription()} doesn't take any options.");
                        }
                    }
                    
                    break;

                default:
                    break;
            }

            return (command, arguments, GetOptions(options));

        }

        private UserOptions GetOptions(List<string> options)
        {
            // TODO: Implement option management.
            // This method can throw exception if options are not valid.
            return new UserOptions() {LoggingVerbosity = true, StorageMode = StorageMode.Override};
        }
    }
}
