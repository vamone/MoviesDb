using MoviesDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if(string.IsNullOrWhiteSpace(title))
            {
                return null;
            }

            string trimmedTitle = title.Trim();

            return this._context.Movies.FirstOrDefault(x => x.Title.StartsWith(trimmedTitle, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
