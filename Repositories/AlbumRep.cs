using System.Linq;
using System.Collections.Generic;
using kursDB1.Models;
using kursDB1.Utils;
using kursDB1.Controllers;
using Microsoft.EntityFrameworkCore;

namespace kursDB1.Repositories
{
    public class AlbumRepository
    {
        private readonly AppDbContext _dbContext;

        public AlbumRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1");

            _dbContext = new AppDbContext(optionsBuilder.Options);
        }

        public Album GetById(int albumId)
        {
            return _dbContext.Albums.FirstOrDefault(a => a.Id == albumId);
        }

        public List<Album> GetAll()
        {
            return _dbContext.Albums.ToList();
        }

        public void Add(Album album)
        {
            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();
        }

        public void Update(Album album)
        {
            _dbContext.Albums.Update(album);
            _dbContext.SaveChanges();
        }

        public void Delete(int albumId)
        {
            var album = _dbContext.Albums.Find(albumId);
            if (album != null)
            {
                _dbContext.Albums.Remove(album);
                _dbContext.SaveChanges();
            }
        }
    }
}
