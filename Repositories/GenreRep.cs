using System.Linq;
using System.Collections.Generic;
using kursDB1.Models;
using kursDB1.Utils;
using Microsoft.EntityFrameworkCore;

namespace kursDB1.Repositories
{
    public class GenreRepository
    {
        private readonly AppDbContext _dbContext;

        public GenreRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=2005;Database=db1");

            _dbContext = new AppDbContext(optionsBuilder.Options);
        }

        public Genre GetById(int genreId)
        {
            return _dbContext.Genres.FirstOrDefault(g => g.Id == genreId);
        }

        public List<Genre> GetAll()
        {
            return _dbContext.Genres.ToList();
        }

        public void Add(Genre genre)
        {
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }

        public void Update(Genre genre)
        {
            _dbContext.Genres.Update(genre);
            _dbContext.SaveChanges();
        }

        public void Delete(int genreId)
        {
            var genre = _dbContext.Genres.Find(genreId);
            if (genre != null)
            {
                _dbContext.Genres.Remove(genre);
                _dbContext.SaveChanges();
            }
        }
    }
}

