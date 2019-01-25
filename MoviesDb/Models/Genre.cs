using System.Collections.Generic;

namespace MoviesDb.Models
{
    public class Genre : IGenre
    {
        public Genre()
        {
            this.Movies = this.Movies ?? new List<Movie>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}