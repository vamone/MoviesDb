using System.Collections.Generic;

namespace MoviesDb.Models
{
    public class Genre : IGenre
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}