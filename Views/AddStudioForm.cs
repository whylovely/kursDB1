using System;
using System.Windows.Forms;
using Npgsql; // Для работы с PostgreSQL

namespace kursDB1.Views
{
    public partial class AddStudioForm : Form
    {
        public AddStudioForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из формы
                string Name = txtName.Text;
                DateTime BDay = dtpBDay.Value;
                string formattedBDay = BDay.ToString("yyyy-MM-dd");

                // SQL-запрос для добавления студии в базу данных
                string query = $"INSERT INTO studios (name, b_day) VALUES ('{Name}', '{formattedBDay}')";

                // Строка подключения к базе данных
                string connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

                // Открываем подключение к базе данных
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Создаем команду для выполнения SQL-запроса
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Добавляем параметры для защиты от SQL-инъекций
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@BDay", NpgsqlTypes.NpgsqlDbType.Date, BDay);

                        // Выполняем команду
                        command.ExecuteNonQuery();
                    }
                }

                // Уведомляем пользователя о успешном добавлении студии
                MessageBox.Show("Студия добавлена!");
                this.Close();
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Ошибка при добавлении студии: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}