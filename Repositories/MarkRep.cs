using System.Linq;
using System.Collections.Generic;
using kursDB1.Models;
using kursDB1.Utils;

namespace kursDB1.Repositories
{
    public class MarkRepository
    {
        private readonly AppDbContext _dbContext;

        public MarkRepository()
        {
            _dbContext = new AppDbContext();
        }

        public List<Mark> GetMarksByArtId(int artId)
        {
            return _dbContext.Marks.Where(m => m.IdArt == artId).ToList();
        }

        public void Add(Mark mark)
        {
            _dbContext.Marks.Add(mark);
            _dbContext.SaveChanges();
        }

        public void Update(Mark mark)
        {
            _dbContext.Marks.Update(mark);
            _dbContext.SaveChanges();
        }

        public void Delete(int markId)
        {
            var mark = _dbContext.Marks.Find(markId);
            if (mark != null)
            {
                _dbContext.Marks.Remove(mark);
                _dbContext.SaveChanges();
            }
        }
    }
}
