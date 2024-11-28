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
            Application.Run(new LoginForm());
        }

        private static void InitializeDatabase()
        {
            // Здесь добавьте строку подключения к базе данных
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=2005;Database=db1");

            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                // Можно добавить логику для создания базы данных или миграций, если они не существуют
                context.Database.EnsureCreated();
            }
        }
    }
}