using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MovieScanner.Rules
{
    public static class GeneralRules
    {
        public static string GetHardDrive(string path)
        {
            return Path.GetPathRoot(path).Trim(new char[] {'\\', ':'});
        }
    }
}
