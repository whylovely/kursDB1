using System;
using System.Windows.Forms;
using Npgsql; // Для работы с PostgreSQL

namespace kursDB1.Views
{
    public partial class AddGenreForm : Form
    {
        public AddGenreForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из текстового поля
                string Name = txtName.Text;

                // SQL-запрос для добавления жанра в базу данных
                string query = $"INSERT INTO genres (name) VALUES ('{Name}')";

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

                        // Выполняем команду
                        command.ExecuteNonQuery();
                    }
                }

                // Уведомляем пользователя о успешном добавлении жанра
                MessageBox.Show("Жанр добавлен!");
                this.Close();
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Ошибка при добавлении жанра: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
