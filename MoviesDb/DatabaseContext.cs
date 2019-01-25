using Microsoft.EntityFrameworkCore;
using MoviesDb.Models;

namespace MoviesDb
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public virtual DbSet<IMovie> Movies { get; set; }

        public virtual DbSet<IGenre> Genres { get; set; }

        public virtual DbSet<IMovieRatingXhref> MovieRatingXhrefs { get; set; }

        public void SaveChanges()
        {
        }
    }
}
