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
                Title = "The Christmas Chronicles",
                ReleaseAt = DateTime.UtcNow.AddYears(-1),
                Genres = GetGenres().ToList()
            };

            yield return new Movie
            {
                Id = 2,
                Title = "Bumblebee",
                ReleaseAt = DateTime.UtcNow.AddYears(-2),
                Genres = GetGenres().ToList(),
                MovieRatingXhrefs = GetMovieRatingXhrefsSpecificMovie().ToList()
            };

            yield return new Movie
            {
                Id = 3,
                Title = "Papillon",
                ReleaseAt = DateTime.UtcNow.AddYears(-3),
                Genres = GetGenres().ToList()
            };

            yield return new Movie
            {
                Id = 4,
                Title = "The Girl in the Spider's Web",
                ReleaseAt = DateTime.UtcNow.AddYears(-1)
            };

            yield return new Movie
            {
                Id = 4,
                Title = "The Girl in the Spider's Web 2",
                ReleaseAt = DateTime.UtcNow.AddYears(-1),
                Genres = GetGenres().ToList(),
                MovieRatingXhrefs = GetMovieRatingXhrefsSpecificMovie().ToList()
            };

            yield return new Movie
            {
                Id = 5,
                Title = "A Simple Favor",
                ReleaseAt = DateTime.UtcNow.AddYears(-2)
            };

            yield return new Movie
            {
                Id = 5,
                Title = "Sicario 2: Day of the Soldado",
                ReleaseAt = DateTime.UtcNow.AddYears(-3),
                Genres = GetGenres().ToList()
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
                Raiting = (decimal)8.9,
                UserId = new Guid("fdd0cb9a-1591-4490-b5ff-72ed471b6985")
            };

            yield return new MovieRatingXhref
            {
                Id = 2,
                MovieId = 2,
                Raiting = 5,
                UserId = new Guid("30cab31b-4001-49b4-88c7-af466343a022")
            };

            yield return new MovieRatingXhref
            {
                Id = 3,
                MovieId = 3,
                Raiting = 6,
                UserId = new Guid("30cab31b-4001-49b4-88c7-af466343a022")
            };
        }

        private static IEnumerable<IMovieRatingXhref> GetMovieRatingXhrefsSpecificMovie()
        {
            yield return new MovieRatingXhref
            {
                Id = 1,
                MovieId = 1,
                Raiting = (decimal)8,
                UserId = new Guid("30cab31b-4001-49b4-88c7-af466343a022")
            };

            yield return new MovieRatingXhref
            {
                Id = 2,
                MovieId = 3,
                Raiting = (decimal)8,
                UserId = new Guid("30cab31b-4001-49b4-88c7-af466343a022")
            };
        }
    }
}
