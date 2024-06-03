using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Libreria
{
    public class Libro
    {
        [Key]
        public string genere { get; set; }
        public string isbn { get; set; }
        public string titolo { get; set; }
        public string autore { get; set; } 
        public int anno { get; set; }
    }

    public class LibroDB : DbContext
    {
        public LibroDB(DbContextOptions<LibroDB> options) : base(options) { }

        public DbSet<Libro> Libri { get; set; }
    }
}