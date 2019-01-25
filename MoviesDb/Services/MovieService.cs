using MoviesDb.Models;
using System;
using System.Linq;

namespace MoviesDb.Services
{
    public class MovieService : IMovieService
    {
        private readonly IDatabaseContext _context;

        public MovieService(IDatabaseContext context)
        {
            this._context = context;
        }

        public IMovie FindByParameters(string title, string yearOfRelease = null, string genre = null)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return null;
            }

            string trimmedTitle = title.Trim();

            var movies = this._context.Movies.Where(x => x.Title.StartsWith(trimmedTitle, StringComparison.InvariantCultureIgnoreCase));

            if (!string.IsNullOrWhiteSpace(yearOfRelease))
            {
                string trimmedYear = yearOfRelease.Trim();

                int releaseYear = 0;
                int.TryParse(trimmedYear, out releaseYear);

                movies = movies.Where(x => x.ReleaseAt.Year == releaseYear);
            }

            if (!string.IsNullOrWhiteSpace(genre))
            {
                string trimmedGenre = genre.Trim();
                movies = movies.Where(x => x.Genres.Any(y => y.Name.Equals(trimmedGenre, StringComparison.InvariantCultureIgnoreCase)));
            }

            return movies.FirstOrDefault();
        }
    }
}
