using System;
using System.Collections.Generic;

namespace MoviesDb.Models
{
    public class Movie : IMovie
    {
        public Movie()
        {
            this.Genres = this.Genres ?? new List<IGenre>();
            this.MovieRatingXhrefs = this.MovieRatingXhrefs ?? new List<IMovieRatingXhref>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseAt { get; set; }

        public virtual ICollection<IGenre> Genres { get; set; }

        public virtual ICollection<IMovieRatingXhref> MovieRatingXhrefs { get; set; }
    }
}
