using System.Collections.Generic;
using kursDB1.Models;
using kursDB1.Utils;

namespace kursDB1.Services
{
    public class AdminService
    {
        private readonly AppDbContext _dbContext;

        public AdminService()
        {
            _dbContext = new AppDbContext();
        }

        public void AddArt(Art art)
        {
            _dbContext.Arts.Add(art);
            _dbContext.SaveChanges();
        }

        public void AddAlbum(Album album)
        {
            _dbContext.Albums.Add(album);
            _dbContext.SaveChanges();
        }

        public void AddLabel(Label label)
        {
            _dbContext.Labels.Add(label);
            _dbContext.SaveChanges();
        }

        public void AddStudio(Studio studio)
        {
            _dbContext.Studios.Add(studio);
            _dbContext.SaveChanges();
        }

        public void AddDirector(Director director)
        {
            _dbContext.Directors.Add(director);
            _dbContext.SaveChanges();
        }

        public void AddGenre(Genre genre)
        {
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }

        public List<Art> GetAllArts()
        {
            return _dbContext.Arts.ToList();
        }
    }
}
