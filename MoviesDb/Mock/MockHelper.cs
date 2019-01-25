using Microsoft.EntityFrameworkCore;
using Moq;
using MoviesDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesDb.Mock
{
    public static class MockHelper
    {
        public static DatabaseContext MockDatabaseContext()
        {

            var mockContext = new Mock<DatabaseContext>();

            mockContext.Setup(m => m.Movies).Returns(MockMovieDbSet(GetMovies()));
            mockContext.Setup(m => m.Genres).Returns(MockGenreDbSet(GetGenres()));
            mockContext.Setup(m => m.MovieRatingXhrefs).Returns(MockMovieRatingXhrefDbSet(GetMovieRatingXhrefs()));

            return mockContext.Object;
        }

        private static DbSet<IMovie> MockMovieDbSet(IEnumerable<IMovie> items)
        {
            var data = items.AsQueryable();

            var mockSet = new Mock<DbSet<IMovie>>();
            mockSet.As<IQueryable<IMovie>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<IMovie>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<IMovie>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<IMovie>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet.Object;
        }

        private static DbSet<IGenre> MockGenreDbSet(IEnumerable<IGenre> items)
        {
            var data = items.AsQueryable();

            var mockSet = new Mock<DbSet<IGenre>>();
            mockSet.As<IQueryable<IGenre>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<IGenre>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<IGenre>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<IGenre>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet.Object;
        }

        private static DbSet<IMovieRatingXhref> MockMovieRatingXhrefDbSet(IEnumerable<IMovieRatingXhref> items)
        {
            var data = items.AsQueryable();

            var mockSet = new Mock<DbSet<IMovieRatingXhref>>();
            mockSet.As<IQueryable<IMovieRatingXhref>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<IMovieRatingXhref>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<IMovieRatingXhref>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<IMovieRatingXhref>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet.Object;
        }

        private static IEnumerable<IMovie> GetMovies()
        {
            yield return new Movie
            {
                Id = 1,
                Title = "Santa",
                ReleaseAt = DateTime.UtcNow.AddYears(-1)
            };
        }

        private static IEnumerable<IGenre> GetGenres()
        {
            yield return new Genre
            {
                Id = 1,
                Name = "Comedy"
            };
        }

        private static IEnumerable<IMovieRatingXhref> GetMovieRatingXhrefs()
        {
            yield return new MovieRatingXhref
            {
                Id = 1,
                MovieId = 1,
                Raiting = 5,
                UserId = Guid.NewGuid()
            };
        }
    }
}
