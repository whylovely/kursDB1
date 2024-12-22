using kursDB1.Utils;
using kursDB1.Views;

namespace kursDB1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string connectionString = "Server=localhost;Database=db1;Trusted_Connection=True;";
            var dbInitializer = new DatabaseInitializer(connectionString);
            dbInitializer.EnsureDatabaseCreated();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}