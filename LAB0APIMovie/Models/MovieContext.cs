using Microsoft.EntityFrameworkCore;

namespace LAB0APIMovie.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext>options)
            :base (options)
        {

        }
        public DbSet<Movie> movies { get; set; }
    }
}
