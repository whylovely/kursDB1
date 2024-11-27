using BCrypt.Net;

namespace kursDB1.Utils
{
    public static class PasswordHasher
    {
        // Хэширует пароль
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Проверяет правильность пароля
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
