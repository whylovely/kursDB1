using System;
using System.Data;
using System.Windows.Forms;
using Npgsql; // Для работы с PostgreSQL

namespace kursDB1.Views
{
    public partial class AddArtForm : Form
    {
        // Строка подключения к базе данных PostgreSQL
        private readonly string _connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        public AddArtForm()
        {
            InitializeComponent();
        }

        private void AddArtForm_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                int duration;

                // Проверка, чтобы строка duration была числом
                if (!int.TryParse(txtDuration.Text, out duration) || duration <= 0)
                {
                    MessageBox.Show("Пожалуйста, укажите корректную продолжительность.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем вручную введённые данные
                string genreName = txtGenre.Text.Trim();
                string directorName = txtDirector.Text.Trim();
                string studioName = txtStudio.Text.Trim();
                string labelName = txtLabel.Text.Trim();
                string artistName = txtArtist.Text.Trim();
                string albumName = txtAlbum.Text.Trim();

                if (string.IsNullOrWhiteSpace(genreName) ||
                    string.IsNullOrWhiteSpace(directorName) ||
                    string.IsNullOrWhiteSpace(studioName) ||
                    string.IsNullOrWhiteSpace(labelName) ||
                    string.IsNullOrWhiteSpace(artistName) ||
                    string.IsNullOrWhiteSpace(albumName))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Получаем ID для каждого типа данных
                int genreId = GetEntityIdByName("Genres", genreName);
                int directorId = GetEntityIdByName("Directors", directorName);
                int studioId = GetEntityIdByName("Studios", studioName);
                int labelId = GetEntityIdByName("Labels", labelName);
                int artistId = GetEntityIdByName("Artists", artistName);
                int albumId = GetEntityIdByName("Albums", albumName);

                // Если какой-либо элемент не найден, возвращаем ошибку
                //if (genreId == -1 || directorId == -1 || studioId == -1 || labelId == -1 || artistId == -1 || albumId == -1)
                //{
                //    MessageBox.Show("Указанные данные не найдены в базе данных. Проверьте правильность ввода.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                // SQL-запрос для добавления произведения
                string query = "INSERT INTO Arts (name, duration, id_genre, id_director, id_studio, id_label, id_artist, id_album) " +
                               $"VALUES ('{name}', '{duration}', {genreId}, {directorId}, {studioId}, {labelId}, {artistId}, {albumId})";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Параметры для запроса
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@duration", duration);
                        command.Parameters.AddWithValue("@genreId", genreId);
                        command.Parameters.AddWithValue("@directorId", directorId);
                        command.Parameters.AddWithValue("@studioId", studioId);
                        command.Parameters.AddWithValue("@labelId", labelId);
                        command.Parameters.AddWithValue("@artistId", artistId);
                        command.Parameters.AddWithValue("@albumId", albumId);

                        // Открытие соединения и выполнение команды
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Произведение успешно добавлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось добавить произведение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении произведения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Метод для получения ID записи по её имени из указанной таблицы.
        /// </summary>
        /// <param name="tableName">Имя таблицы в базе данных.</param>
        /// <param name="entityName">Имя записи.</param>
        /// <returns>ID записи или -1, если запись не найдена.</returns>
        private int GetEntityIdByName(string tableName, string entityName)
        {
            string query = $"SELECT id FROM {tableName} WHERE name = '{entityName}'";

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@entityName", entityName);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0); // Возвращаем ID записи
                        }
                    }
                }
            }

            return -1; // Если запись не найдена
        }
    }
}
