using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MovieScanner.Entities
{
    enum Resolution
    {
        [Description("Unknown")]
        Unknown = 0,
        [Description("SD")]
        SD = 1,
        [Description("HD")]
        HD = 2,
        [Description("Full HD")]
        FullHD = 3,
        [Description("2K")]
        TwoK = 4,
        [Description("UHD")]
        UHD = 5,
        [Description("4K")]
        FourK = 6,
        [Description("8K")]
        EightK = 7
    }
}
