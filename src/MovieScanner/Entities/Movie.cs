using System;
using System.Collections.Generic;
using System.Text;

namespace MovieScanner.Entities
{
    public class Movie
    {
        public string Title { get; set; }
        public double Size { get; set; }
        public string Path { get; set; }
        public string HardDrive { get; set; }
        public Resolution Resolution { get; set; }

    }
}
