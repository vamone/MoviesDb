using System;

namespace MoviesDb.Models
{
    public class MovieRatingXhref : IMovieRatingXhref
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public decimal Raiting { get; set; }

        public Guid UserId { get; set; }
    }
}
