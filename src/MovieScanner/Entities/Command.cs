using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MovieScanner.Entities
{
    public enum Command
    {
        [Description("Unknown")]
        Unknown = 0,
        [Description("Scan")]
        Scan = 1,
        [Description("Multiple scan")]
        ScanMultiple = 2,
        [Description("Exists")]
        Exists = 3,
        [Description("Help")]
        Help = -1
        // TODO

    }
}
