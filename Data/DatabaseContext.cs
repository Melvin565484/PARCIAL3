using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {}
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<Bibliotec> Bibliotecs {get; set;}

        public DbSet<Author> Authors {get; set;}
        
    }
}