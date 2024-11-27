using System.Linq;
using System.Collections.Generic;
using kursDB1.Models;
using kursDB1.Utils;

namespace kursDB1.Repositories
{
    public class AlbumRepository
    {
        private readonly AppDbContext _dbContext;

        public AlbumRepository()
        {
            _dbContext = new AppDbContext();
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
