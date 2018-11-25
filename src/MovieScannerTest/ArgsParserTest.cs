using System;
using System.Collections.Generic;
using System.Text;
using MovieScanner.Entities;
using MovieScanner.UserInterface;
using Xunit;

namespace MovieScannerTest
{

    public class ArgsParserTest
    {
        [Fact]
        public void GetCommandTest()
        {
            /*
             Tested :
           GetCommand is case insensitive
           Retrieve correct command
           Throws correct exception when argument is invalid
           Adding options does not affect argument parsing
           
             Untested:
           Expected options are retrieved from options
             */
            // TODO test options when implemented

            var argsParser = new ArgsParser();


            string validPath = "L:\\Film";
            string validPath2 = "E:\\Nvidia_shield\\Movies";
            string validMovie = "Harry Potter";

            string[] userInput = new[] { "ScAn", validPath, "-V" };

            (Command Command, List<string> Arguments, UserOptions Options) userInputParsed =
                argsParser.GetCommand(userInput);

            Assert.Equal(Command.Scan, userInputParsed.Command);
            Assert.Equal(validPath, userInputParsed.Arguments[0]);
            Assert.Single(userInputParsed.Arguments);
            

            userInput = new[] { "scAnMultiPlE", validPath };

            userInputParsed = argsParser.GetCommand(userInput);

            Assert.Equal(Command.ScanMultiple, userInputParsed.Command);
            Assert.Equal(validPath, userInputParsed.Arguments[0]);
            Assert.Single(userInputParsed.Arguments);

            userInput = new[] { "scAnMultiPlE", validPath, validPath2 };

            userInputParsed = argsParser.GetCommand(userInput);

            Assert.Equal(Command.ScanMultiple, userInputParsed.Command);
            Assert.Equal(validPath, userInputParsed.Arguments[0]);
            Assert.Equal(validPath2, userInputParsed.Arguments[1]);
            Assert.Equal(2, userInputParsed.Arguments.Count);

            userInput = new[] { "scAnMultiPlE", validPath, validPath2, "-V" };

            userInputParsed = argsParser.GetCommand(userInput);

            Assert.Equal(Command.ScanMultiple, userInputParsed.Command);
            Assert.Equal(validPath, userInputParsed.Arguments[0]);
            Assert.Equal(validPath2, userInputParsed.Arguments[1]);
            Assert.Equal(2, userInputParsed.Arguments.Count);

            userInput = new[] { "scan", validPath, validPath2 };
            // TODO: Uncomment Assert.
            // two arguments given to Scan command must throw exception
            // Assert.Throws<ArgumentException>(() => argsParser.GetCommand(userInput));
            // This will works when option parsing will throw an exception because currently, second path is storred as an option, but its validity is not verified.


            userInput = new[] { "exists", validMovie, validPath + "\\something.json", validPath2 + "\\somemovies.json" };

            // two files given to Scan command must throw exception (for now?)
            Assert.Throws<ArgumentException>(() => argsParser.GetCommand(userInput));

            // BUGBUG only works on my machine because it needs an actual json file due to use of Fileinformation class.
            // TODO: Add a valid json in Test project
            userInput = new[] { "exists", validMovie, validPath + "\\L_Movies.json" };

            userInputParsed = argsParser.GetCommand(userInput);

            Assert.Equal(Command.Exists, userInputParsed.Command);
            Assert.Equal(validMovie, userInputParsed.Arguments[0]);
            Assert.Equal(validPath + "\\L_Movies.json", userInputParsed.Arguments[1]);
            Assert.Equal(2, userInputParsed.Arguments.Count);

            userInput = new[] { "exists", validMovie, validPath + "\\something.txt",};

            // file given is not json:
            Assert.Throws<ArgumentException>(() => argsParser.GetCommand(userInput));

            userInput = new[] { "help", "scan" };

            userInputParsed = argsParser.GetCommand(userInput);

            Assert.Equal(Command.Help, userInputParsed.Command);
            Assert.Equal("scan", userInputParsed.Arguments[0]);
            Assert.Single(userInputParsed.Arguments);

            userInput = new[] { "help", "scan", "-V" };
            // Help doesn't accept any option
            Assert.Throws<ArgumentException>(() => argsParser.GetCommand(userInput));

            userInput = new[] { "help" };

            userInputParsed = argsParser.GetCommand(userInput);

            Assert.Equal(Command.Help, userInputParsed.Command);
            Assert.Empty(userInputParsed.Arguments);

            userInput = new[] { "help", "-V" };

            // Help doesn't accept any option
            Assert.Throws<ArgumentException>(() => argsParser.GetCommand(userInput));


            userInput = new[] { "help", "scan", "scanmultiple"};
            // Can't pass two arguments to help method
            Assert.Throws<ArgumentException>(() => argsParser.GetCommand(userInput));

        }
    }
}
