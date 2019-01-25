using System;

namespace MoviesDb.Models
{
    public interface IMovieRatingXhref
    {
        int Id { get; set; }

        int MovieId { get; set; }

        decimal Raiting { get; set; }

        Guid UserId { get; set; }
    }
}