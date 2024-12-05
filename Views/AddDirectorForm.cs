using System;
using System.Windows.Forms;
using Npgsql; // Для работы с PostgreSQL

namespace kursDB1.Views
{
    public partial class AddDirectorForm : Form
    {
        public AddDirectorForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из текстового поля
                string directorName = txtName.Text;

                // SQL-запрос для добавления режиссера в базу данных
                string query = $"INSERT INTO directors (name) VALUES ('{directorName}')";

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
                        command.Parameters.AddWithValue("@Name", directorName);

                        // Выполняем команду
                        command.ExecuteNonQuery();
                    }
                }

                // Уведомляем пользователя о успешном добавлении режиссера
                MessageBox.Show("Режиссер добавлен!");
                this.Close();
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Ошибка при добавлении режиссера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
