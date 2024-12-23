using kursDB1.Utils;
using kursDB1.Views;

namespace kursDB1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";
            var dbInitializer = new DatabaseInitializer(connectionString);
            dbInitializer.EnsureDatabaseCreated();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}