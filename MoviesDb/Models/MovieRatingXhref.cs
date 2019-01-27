using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesDb.Models
{
    public class MovieRatingXhref : IMovieRatingXhref
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public decimal Raiting { get; set; }

        public Guid UserId { get; set; }
    }
}
