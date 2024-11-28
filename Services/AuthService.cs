using System.Linq;
using kursDB1.Models;
using kursDB1.Utils;

namespace kursDB1.Services
{
    public class AuthService
    {
        private readonly AppDbContext _dbContext;

        public AuthService()
        {
            _dbContext = DbConnection.GetDbContext();
        }

        public User Login(string email, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);

            if (user != null && VerifyPassword(password, user.Password))
            {
                return user;
            }

            return null;
        }

        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            // Проверка пароля (например, через хеширование)
            return inputPassword == storedPassword; // Для упрощения
        }
    }
}
