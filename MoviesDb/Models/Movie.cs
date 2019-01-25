using System;
using System.Collections.Generic;

namespace MoviesDb.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Genres = this.Genres ?? new List<Genre>();
            this.MovieRatingXhrefs = this.MovieRatingXhrefs ?? new List<MovieRatingXhref>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseAt { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<MovieRatingXhref> MovieRatingXhrefs { get; set; }
    }
}
