using System;
using Npgsql;
using kursDB1.Models;
using kursDB1.Utils;

namespace kursDB1.Controllers
{
    public class AuthController
    {
        // Строка подключения к базе данных PostgreSQL
        private readonly string _connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        // Метод для аутентификации пользователя
        public User Login(string email, string password)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, name, email, password, role_id FROM Users WHERE email = @email";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Получение данных из базы
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string storedPassword = reader.GetString(3);
                                int roleId = reader.GetInt32(4);

                                // Проверка пароля
                                if (password == storedPassword)
                                {
                                    return new User
                                    {
                                        Id = id,
                                        Name = name,
                                        Email = email,
                                        RoleId = roleId
                                    };
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Console.WriteLine(ex.Message);
            }

            // Если пользователь не найден или пароль неверен
            return null;
        }
    }
}
