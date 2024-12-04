using System.Linq;
using System.Collections.Generic;
using kursDB1.Models;
using kursDB1.Utils;
using Microsoft.EntityFrameworkCore;

namespace kursDB1.Repositories
{
    public class ArtRepository
    {
        private readonly AppDbContext _dbContext;

        public ArtRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1");

            _dbContext = new AppDbContext(optionsBuilder.Options);
        }

        public Art GetById(int artId)
        {
            return _dbContext.Arts.FirstOrDefault(a => a.Id == artId);
        }

        public List<Art> GetAll()
        {
            return _dbContext.Arts.ToList();
        }

        public void Add(Art art)
        {
            _dbContext.Arts.Add(art);
            _dbContext.SaveChanges();
        }

        public void Update(Art art)
        {
            _dbContext.Arts.Update(art);
            _dbContext.SaveChanges();
        }

        public void Delete(int artId)
        {
            var art = _dbContext.Arts.Find(artId);
            if (art != null)
            {
                _dbContext.Arts.Remove(art);
                _dbContext.SaveChanges();
            }
        }
    }
}
