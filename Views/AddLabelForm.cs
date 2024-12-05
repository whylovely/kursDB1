using System;
using System.Windows.Forms;
using Npgsql; // Добавьте для работы с PostgreSQL
using System.Text;

namespace kursDB1.Views
{
    public partial class AddLabelForm : Form
    {
        public AddLabelForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из формы
                string labelName = txtName.Text;
                DateTime BDate = dtpBDate.Value;

                // SQL-запрос для добавления нового лейбла в базу данных
                string query = $"INSERT INTO music_labels (name, b_date) VALUES ('{labelName}', {BDate})";

                // Создаем строку подключения
                string connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

                // Открываем подключение к базе данных
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Выполняем команду
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Добавляем параметры для защиты от SQL-инъекций
                        command.Parameters.AddWithValue("@Name", labelName);
                        command.Parameters.AddWithValue("@BDate", BDate);

                        // Выполняем команду
                        command.ExecuteNonQuery();
                    }
                }

                // Уведомляем пользователя
                MessageBox.Show("Лейбл добавлен!");
                this.Close();
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Ошибка при добавлении лейбла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
