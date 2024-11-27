using Microsoft.EntityFrameworkCore;
using System;

namespace kursDB1.Utils
{
    public static class DbConnection
    {
        private static readonly string _connectionString = "your_connection_string_here";
        //  private static readonly string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=password123;Database=online_art_db";

        public static AppDbContext GetDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(_connectionString); // Используем PostgreSQL, например

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
