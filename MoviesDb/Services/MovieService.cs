using MoviesDb.Models;
using System;
using System.Collections.Generic;
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

        public IMovie AddOrUpdateMovieRaiting(int id, int rating, string userId)
        {
            Guid userUniqId = new Guid(userId);

            bool isUserIdValidId = !string.IsNullOrWhiteSpace(userId) && userUniqId != Guid.Empty;
            if (!isUserIdValidId)
            {
                throw new ArgumentOutOfRangeException();
            }

            var movie = this._context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return null;
            }

            movie.MovieRatingXhrefs.Add(new MovieRatingXhref { MovieId = movie.Id, Raiting = rating, UserId = userUniqId });

            this._context.SaveChanges();

            return movie;
        }

        public IMovie FindByParameters(string title = null, string yearOfRelease = null, string genre = null)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return null;
            }

            IQueryable<IMovie> movies = null;

            if (!string.IsNullOrWhiteSpace(title))
            {
                string trimmedTitle = title.Trim();
                movies = this._context.Movies.Where(x => x.Title.StartsWith(trimmedTitle, StringComparison.InvariantCultureIgnoreCase));

                //More filter logic on title as: StartsWith, EndsWith, Contains or Fuzzy Algorithm
            }

            if (!string.IsNullOrWhiteSpace(yearOfRelease))
            {
                string trimmedYear = yearOfRelease.Trim();

                int releaseYear = 0;

                bool isReleaseYearParsed = int.TryParse(trimmedYear, out releaseYear);
                if (!isReleaseYearParsed)
                {
                    throw new ArgumentOutOfRangeException();
                }

                movies = movies.Where(x => x.ReleaseAt.Year == releaseYear);
            }

            if (!string.IsNullOrWhiteSpace(genre))
            {
                string trimmedGenre = genre.Trim();
                movies = movies.Where(x => x.Genres.Any(y => y.Name.StartsWith(trimmedGenre, StringComparison.InvariantCultureIgnoreCase)));

                //More filter logic on genre as: StartsWith, EndsWith, Contains or Fuzzy Algorithm
            }

            if (movies == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            return movies.FirstOrDefault();
        }

        public ICollection<IMovie> GetTopMovies(int itemsCount, string userId = null)
        {
            IQueryable<IMovie> movies = this._context.Movies;

            Guid userUniqId = Guid.Empty;

            if (!string.IsNullOrWhiteSpace(userId))
            {
                userUniqId = new Guid(userId);

                bool isUserIdValidId = userUniqId != Guid.Empty;
                if (!isUserIdValidId)
                {
                    throw new ArgumentOutOfRangeException();
                }

                movies = movies.Where(x => x.MovieRatingXhrefs.Any(y => y.UserId == userUniqId));
            }

            movies = movies.Where(x => x.MovieRatingXhrefs.Any()).OrderByDescending(x => x.MovieRatingXhrefs.Average(y => y.Raiting)).ThenBy(x => x.Title);

            return movies.Take(itemsCount).ToList();
        }
    }
}
