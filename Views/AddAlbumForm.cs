using System;
using System.Data;
using System.Windows.Forms;
using Npgsql; // Для работы с PostgreSQL

namespace kursDB1.Views
{
    public partial class AddAlbumForm : Form
    {
        // Строка подключения к базе данных PostgreSQL
        private readonly string _connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        public AddAlbumForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string countArtsText = txtCountArts.Text.Trim();
            DateTime dropDay = dtpDropDay.Value;

            // Проверка на валидность введенных данных
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(countArtsText) || !int.TryParse(countArtsText, out int countArts))
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    // SQL-запрос для добавления альбома
                    string query = $"INSERT INTO Albums (name, count_arts, drop_day) VALUES ('{name}', '{countArts}', {dropDay})";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Параметры для предотвращения SQL-инъекций
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@countArts", countArts);
                        command.Parameters.AddWithValue("@dropDay", dropDay);

                        // Открытие соединения и выполнение команды
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Альбом успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить альбом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении альбома: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddAlbumForm_Load(object sender, EventArgs e)
        {
        }
    }
}