using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GridSample
{
    public interface IMovieSource
    {
        event Action<Movie> MovieDBUpdated;
    }
}
