using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesDb.Models
{
    public class Genre : IGenre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}