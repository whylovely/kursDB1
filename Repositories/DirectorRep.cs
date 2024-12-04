using System.Linq;
using System.Collections.Generic;
using kursDB1.Models;
using kursDB1.Utils;
using Microsoft.EntityFrameworkCore;

namespace kursDB1.Repositories
{
    public class DirectorRepository
    {
        private readonly AppDbContext _dbContext;

        public DirectorRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1");

            _dbContext = new AppDbContext(optionsBuilder.Options);
        }

        public Director GetById(int directorId)
        {
            return _dbContext.Directors.FirstOrDefault(d => d.Id == directorId);
        }

        public List<Director> GetAll()
        {
            return _dbContext.Directors.ToList();
        }

        public void Add(Director director)
        {
            _dbContext.Directors.Add(director);
            _dbContext.SaveChanges();
        }

        public void Update(Director director)
        {
            _dbContext.Directors.Update(director);
            _dbContext.SaveChanges();
        }

        public void Delete(int directorId)
        {
            var director = _dbContext.Directors.Find(directorId);
            if (director != null)
            {
                _dbContext.Directors.Remove(director);
                _dbContext.SaveChanges();
            }
        }
    }
}
