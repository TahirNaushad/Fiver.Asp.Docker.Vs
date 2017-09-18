using Fiver.Asp.Docker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fiver.Asp.Docker.Data
{
    public class Database : DbContext
    {
        public Database(
            DbContextOptions<Database> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
