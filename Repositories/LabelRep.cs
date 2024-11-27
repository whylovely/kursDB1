using System.Linq;
using System.Collections.Generic;
using kursDB1.Models;
using kursDB1.Utils;

namespace kursDB1.Repositories
{
    public class LabelRepository
    {
        private readonly AppDbContext _dbContext;

        public LabelRepository()
        {
            _dbContext = new AppDbContext();
        }

        public Label GetById(int labelId)
        {
            return _dbContext.Labels.FirstOrDefault(l => l.Id == labelId);
        }

        public List<Label> GetAll()
        {
            return _dbContext.Labels.ToList();
        }

        public void Add(Label label)
        {
            _dbContext.Labels.Add(label);
            _dbContext.SaveChanges();
        }

        public void Update(Label label)
        {
            _dbContext.Labels.Update(label);
            _dbContext.SaveChanges();
        }

        public void Delete(int labelId)
        {
            var label = _dbContext.Labels.Find(labelId);
            if (label != null)
            {
                _dbContext.Labels.Remove(label);
                _dbContext.SaveChanges();
            }
        }
    }
}
