using Microsoft.EntityFrameworkCore;
using kursDB1.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.IO;

namespace kursDB1.Utils
{
    public class AppDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet<Art> Arts { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=2005;Database=db1");
        }
    }
}
