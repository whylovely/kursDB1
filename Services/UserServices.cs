using System.Collections.Generic;
using System.Linq;
using kursDB1.Models;
using kursDB1.Utils;
using Microsoft.EntityFrameworkCore;

namespace kursDB1.Services
{
    public class UserService
    {
        private readonly AppDbContext _dbContext;

        public UserService()
        {
            _dbContext = DbConnection.GetDbContext();
        }

        public void AddUser(User user)
        {
            // Проверка на существование пользователя с таким же именем
            if (_dbContext.Users.Any(u => u.Name == user.Name))
            {
                throw new Exception("Пользователь с таким именем уже существует.");
            }

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public List<Art> GetArts()
        {
            return _dbContext.Arts.ToList();
        }

        public void RateArt(int userId, int artId, int mark)
        {
            var userMark = new Mark
            {
                UserId = userId,
                ArtId = artId,
                MarkValue = mark
            };

            _dbContext.Marks.Add(userMark);
            _dbContext.SaveChanges();
        }
        public List<Mark> GetUserMarks(int userId)
        {
            return _dbContext.Marks
                .Where(m => m.UserId == userId)
                .ToList(); // Извлекаем все оценки для данного пользователя
        }

        public void AddMark(int userId, int artId, int mark)
        {
            var markEntity = new Mark
            {
                UserId = userId,
                ArtId = artId,
                MarkValue = mark
            };

            // Добавление записи оценки в базу данных
            _dbContext.Marks.Add(markEntity);
            _dbContext.SaveChanges(); // Сохранение изменений в базе данных
        }
    }
}
