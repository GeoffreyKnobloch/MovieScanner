using System;
using System.Collections.Generic;
using System.Text;
using MovieScanner.Entities;

namespace MovieScanner.UserInterface
{
    interface IArgsParser
    {
        // Parse args to know what to do
        (Command command, List<string> arguments, UserOptions options) GetCommand(string[] userInput); // TODO : Define how arg parsing will work
    }
}
