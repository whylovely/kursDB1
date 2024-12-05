using System;
using System.Windows.Forms;
using System.Xml.Linq;
using Npgsql; // Для работы с PostgreSQL

namespace kursDB1.Views
{
    public partial class AddArtistForm : Form
    {
        public AddArtistForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из формы
                string Name = txtName.Text;

                // SQL-запрос для добавления артиста в базу данных
                string query = $"INSERT INTO artists (name) VALUES ('{Name}')";

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

                // Уведомляем пользователя о успешном добавлении артиста
                MessageBox.Show("Артист добавлен!");
                this.Close();
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Ошибка при добавлении артиста: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
