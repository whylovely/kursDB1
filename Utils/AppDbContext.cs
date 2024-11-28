using Microsoft.EntityFrameworkCore;
using kursDB1.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace kursDB1.Utils
{
    public class AppDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=2005;Database=db1");
        }
    }
}
