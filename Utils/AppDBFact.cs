using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace kursDB1.Utils
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
 