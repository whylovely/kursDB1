using Microsoft.EntityFrameworkCore;
using System;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace kursDB1.Utils
{
    public static class DbConnection
    {
        private static readonly string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=2005;Database=db1";
        //  private static readonly string _connectionString = "Host=localhost;Port=5432;Username=postgres;Password=password123;Database=online_art_db";

        public static AppDbContext GetDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(_connectionString); 

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
