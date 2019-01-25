using Microsoft.EntityFrameworkCore;
using MoviesDb.Models;

namespace MoviesDb
{
    public interface IDatabaseContext
    {
        DbSet<IMovie> Movies { get; set; }

        DbSet<IGenre> Genres { get; set; }

        DbSet<IMovieRatingXhref> MovieRatingXhrefs { get; set; }
    }
}