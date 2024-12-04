using System.Linq;
using System.Collections.Generic;
using kursDB1.Models;
using kursDB1.Utils;
using Microsoft.EntityFrameworkCore;

namespace kursDB1.Repositories
{
    public class LabelRepository
    {
        private readonly AppDbContext _dbContext;

        public LabelRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1");

            _dbContext = new AppDbContext(optionsBuilder.Options);
        }

        public MusicLabel GetById(int labelId)
        {
            return _dbContext.MusicLabels.FirstOrDefault(l => l.Id == labelId);
        }

        public List<MusicLabel> GetAll()
        {
            return _dbContext.MusicLabels.ToList();
        }

        public void Add(MusicLabel label)
        {
            _dbContext.MusicLabels.Add(label);
            _dbContext.SaveChanges();
        }

        public void Update(MusicLabel label)
        {
            _dbContext.MusicLabels.Update(label);
            _dbContext.SaveChanges();
        }

        public void Delete(int labelId)
        {
            var label = _dbContext.MusicLabels.Find(labelId);
            if (label != null)
            {
                _dbContext.MusicLabels.Remove(label);
                _dbContext.SaveChanges();
            }
        }
    }
}
