using System.Linq;
using System.Collections.Generic;
using kursDB1.Models;
using kursDB1.Utils;

namespace kursDB1.Repositories
{
    public class StudioRepository
    {
        private readonly AppDbContext _dbContext;

        public StudioRepository()
        {
            _dbContext = new AppDbContext();
        }

        public Studio GetById(int studioId)
        {
            return _dbContext.Studios.FirstOrDefault(s => s.Id == studioId);
        }

        public List<Studio> GetAll()
        {
            return _dbContext.Studios.ToList();
        }

        public void Add(Studio studio)
        {
            _dbContext.Studios.Add(studio);
            _dbContext.SaveChanges();
        }

        public void Update(Studio studio)
        {
            _dbContext.Studios.Update(studio);
            _dbContext.SaveChanges();
        }

        public void Delete(int studioId)
        {
            var studio = _dbContext.Studios.Find(studioId);
            if (studio != null)
            {
                _dbContext.Studios.Remove(studio);
                _dbContext.SaveChanges();
            }
        }
    }
}
