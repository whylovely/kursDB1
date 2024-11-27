using System;
using System.Text.RegularExpressions;

namespace kursDB1.Utils
{
    public static class Validator
    {
        // Проверка правильности email
        public static bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        // Проверка минимальной длины пароля
        public static bool IsValidPassword(string password)
        {
            return password.Length >= 6; // Минимальная длина пароля
        }

        // Проверка, что строка не пуста
        public static bool IsNotEmpty(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
    }
}
