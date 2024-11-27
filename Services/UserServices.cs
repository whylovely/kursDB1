using System.Collections.Generic;
using System.Linq;
using kursDB1.Models;
using kursDB1.Utils;

namespace kursDB1.Services
{
    public class UserService
    {
        private readonly AppDbContext _dbContext;

        public UserService()
        {
            _dbContext = new AppDbContext();
        }

        public List<Art> GetArts()
        {
            return _dbContext.Arts.ToList();
        }

        public void RateArt(int userId, int artId, int mark)
        {
            var userMark = new Mark
            {
                IdUser = userId,
                IdArt = artId,
                MarkValue = mark
            };

            _dbContext.Marks.Add(userMark);
            _dbContext.SaveChanges();
        }
    }
}
