using System;
using System.Collections.Generic;

namespace MoviesDb.Models
{
    public interface IMovie
    {

        int Id { get; set; }

        string Title { get; set; }

        DateTime ReleaseAt { get; set; }

        ICollection<Genre> Genres { get; set; }

        ICollection<MovieRatingXhref> MovieRatingXhrefs { get; set; }
    }
}