using System;
using System.Windows.Forms;
using kursDB1.Utils;
using kursDB1.Views;

namespace kursDB1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Настройка конфигурации, если необходимо
            AppConfig.LoadConfiguration();

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
            using (var context = new AppDbContext())
            {
                // Можно добавить логику для создания базы данных или миграций, если они не существуют
                context.Database.EnsureCreated();
            }
        }
    }
}
