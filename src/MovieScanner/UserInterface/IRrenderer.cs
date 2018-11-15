using MovieScanner.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieScanner.UserInterface
{
    public interface IRenderer
    {
        void RenderMovies(List<Movie> movies);
        
    }
}
