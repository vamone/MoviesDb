using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesDb.Models
{
    public class Movie : IMovie
    {
        public Movie()
        {
            this.Genres = this.Genres ?? new List<IGenre>();
            this.MovieRatingXhrefs = this.MovieRatingXhrefs ?? new List<IMovieRatingXhref>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseAt { get; set; }

        public virtual ICollection<IGenre> Genres { get; set; }

        public virtual ICollection<IMovieRatingXhref> MovieRatingXhrefs { get; set; }
    }
}
