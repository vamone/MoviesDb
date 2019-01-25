using System.Collections.Generic;

namespace MoviesDb.Models
{
    public interface IGenre
    {
        int Id { get; set; }

        string Name { get; set; }
    }
}