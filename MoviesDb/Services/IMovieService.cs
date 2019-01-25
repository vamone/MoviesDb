using MoviesDb.Models;
using System.Collections.Generic;

namespace MoviesDb.Services
{
    public interface IMovieService
    {
        IMovie FindByParameters(string title, string yearOfRelease = null, string genre = null);

        ICollection<IMovie> GetTopMovies(int itemsCount, string userId = null);
    }
}