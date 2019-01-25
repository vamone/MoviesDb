using System;

namespace MoviesDb.Models
{
    public interface IMovieRatingXhref
    {
        int Id { get; set; }

        int MovieId { get; set; }

        Movie Movie { get; set; }

        int Raiting { get; set; }

        Guid UserId { get; set; }
    }
}