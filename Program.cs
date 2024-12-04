using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using kursDB1.Utils;  // Ваш DbContext
using kursDB1.Views;  // Ваши формы

namespace kursDB1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Настройка сервисов, включая DbContext
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Server=localhost;Database=db1;Trusted_Connection=True;"));

            // Регистрируем формы и другие сервисы
            services.AddSingleton<MainForm>();

            var serviceProvider = services.BuildServiceProvider();

            // Запуск формы
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }
    }
}
