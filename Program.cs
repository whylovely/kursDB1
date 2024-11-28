using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using kursDB1.Utils;
using kursDB1.Views;

namespace kursDB1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Инициализация и настройка базы данных
            InitializeDatabase();

            // Настройка стиля приложения
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Запуск формы входа
            Application.Run(new MainForm());
        }

        private static void InitializeDatabase()
        {
            // Здесь добавьте строку подключения к уже существующей базе данных
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Убедитесь, что строка подключения правильная для вашей существующей базы данных
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=2005;Database=db1");

            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                // Проверка, подключение возможно
                try
                {
                    context.Database.OpenConnection(); // Открывает соединение с базой данных
                    Console.WriteLine("Подключение к базе данных успешно.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка подключения: {ex.Message}");
                }
            }
        }
    }
}
