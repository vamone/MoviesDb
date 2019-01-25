using System;
using System.Collections.Generic;

namespace MoviesDb.Models
{
    public interface IMovie
    {

        int Id { get; set; }

        string Title { get; set; }

        DateTime ReleaseAt { get; set; }

        ICollection<IGenre> Genres { get; set; }

        ICollection<IMovieRatingXhref> MovieRatingXhrefs { get; set; }
    }
}