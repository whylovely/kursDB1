using System.Linq;
using System.Collections.Generic;
using kursDB1.Models;
using kursDB1.Utils;
using Microsoft.EntityFrameworkCore;

namespace kursDB1.Repositories
{
    public class MarkRepository
    {
        private readonly AppDbContext _dbContext;

        public MarkRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=2005;Database=db1");

            _dbContext = new AppDbContext(optionsBuilder.Options);
        }

        public List<Mark> GetMarksByArtId(int artId)
        {
            return _dbContext.Marks.Where(m => m.ArtId == artId).ToList();
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
