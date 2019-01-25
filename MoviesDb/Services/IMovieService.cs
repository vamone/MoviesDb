using MoviesDb.Models;

namespace MoviesDb.Services
{
    public interface IMovieService
    {
        IMovie FindByParameters(string title, string yearOfRelease = null, string genre = null);
    }
}