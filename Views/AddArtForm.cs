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
            // Загружаем жанры, режиссеров, студии, лейблы, артистов и альбомы
            LoadGenres();
            LoadDirectors();
            LoadStudios();
            LoadLabels();
            LoadArtists();
            LoadAlbums();
        }

        private void LoadGenres()
        {
            string query = "SELECT id, name FROM Genres"; // SQL-запрос для получения всех жанров

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        cmbGenres.Items.Clear();
                        cmbGenres.Items.Add(new { Id = 0, Name = "Не выбран" }); // Добавляем вариант "0" для пустого выбора
                        while (reader.Read())
                        {
                            int genreId = reader.GetInt32(0);
                            string genreName = reader.GetString(1);
                            cmbGenres.Items.Add(new { Id = genreId, Name = genreName });
                        }
                    }
                }
            }

            cmbGenres.DisplayMember = "Name";
            cmbGenres.ValueMember = "Id";
            cmbGenres.SelectedIndex = 0;
        }

        private void LoadDirectors()
        {
            string query = "SELECT id, name FROM Directors"; // SQL-запрос для получения всех режиссеров

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        cmbDirectors.Items.Clear();
                        cmbDirectors.Items.Add(new { Id = 0, Name = "Не выбран" }); // Добавляем вариант "0" для пустого выбора
                        while (reader.Read())
                        {
                            int directorId = reader.GetInt32(0);
                            string directorName = reader.GetString(1);
                            cmbDirectors.Items.Add(new { Id = directorId, Name = directorName });
                        }
                    }
                }
            }

            cmbDirectors.DisplayMember = "Name";
            cmbDirectors.ValueMember = "Id";
            cmbDirectors.SelectedIndex = 0;
        }

        private void LoadStudios()
        {
            string query = "SELECT id, name FROM Studios"; // SQL-запрос для получения всех студий

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        cmbStudios.Items.Clear();
                        cmbStudios.Items.Add(new { Id = 0, Name = "Не выбран" }); // Добавляем вариант "0" для пустого выбора
                        while (reader.Read())
                        {
                            int studioId = reader.GetInt32(0);
                            string studioName = reader.GetString(1);
                            cmbStudios.Items.Add(new { Id = studioId, Name = studioName });
                        }
                    }
                }
            }

            cmbStudios.DisplayMember = "Name";
            cmbStudios.ValueMember = "Id";
            cmbStudios.SelectedIndex = 0;
        }

        private void LoadLabels()
        {
            string query = "SELECT id, name FROM Labels"; // SQL-запрос для получения всех лейблов

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        cmbLabels.Items.Clear();
                        cmbLabels.Items.Add(new { Id = 0, Name = "Не выбран" }); // Добавляем вариант "0" для пустого выбора
                        while (reader.Read())
                        {
                            int labelId = reader.GetInt32(0);
                            string labelName = reader.GetString(1);
                            cmbLabels.Items.Add(new { Id = labelId, Name = labelName });
                        }
                    }
                }
            }

            cmbLabels.DisplayMember = "Name";
            cmbLabels.ValueMember = "Id";
            cmbLabels.SelectedIndex = 0;
        }

        private void LoadArtists()
        {
            string query = "SELECT id, name FROM Artists"; // SQL-запрос для получения всех артистов

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        cmbArtists.Items.Clear();
                        cmbArtists.Items.Add(new { Id = 0, Name = "Не выбран" }); // Добавляем вариант "0" для пустого выбора
                        while (reader.Read())
                        {
                            int artistId = reader.GetInt32(0);
                            string artistName = reader.GetString(1);
                            cmbArtists.Items.Add(new { Id = artistId, Name = artistName });
                        }
                    }
                }
            }

            cmbArtists.DisplayMember = "Name";
            cmbArtists.ValueMember = "Id";
            cmbArtists.SelectedIndex = 0;
        }

        private void LoadAlbums()
        {
            string query = "SELECT id, name FROM Albums"; // SQL-запрос для получения всех альбомов

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                using (var command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        cmbAlbums.Items.Clear();
                        cmbAlbums.Items.Add(new { Id = 0, Name = "Не выбран" }); // Добавляем вариант "0" для пустого выбора
                        while (reader.Read())
                        {
                            int albumId = reader.GetInt32(0);
                            string albumName = reader.GetString(1);
                            cmbAlbums.Items.Add(new { Id = albumId, Name = albumName });
                        }
                    }
                }
            }

            cmbAlbums.DisplayMember = "Name";
            cmbAlbums.ValueMember = "Id";
            cmbAlbums.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                int duration = int.Parse(txtDuration.Text);
                int genreId = (int)cmbGenres.SelectedValue;
                int directorId = (int)cmbDirectors.SelectedValue;
                int studioId = (int)cmbStudios.SelectedValue;
                int labelId = (int)cmbLabels.SelectedValue;
                int artistId = (int)cmbArtists.SelectedValue;
                int albumId = (int)cmbAlbums.SelectedValue;

                if (string.IsNullOrWhiteSpace(name) || duration <= 0 || genreId <= 0)
                {
                    MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // SQL-запрос для добавления произведения
                string query = $"INSERT INTO Arts (name, duration, id_genre, id_director, id_studio, id_label, id_artist, id_album) " +
                               $"VALUES ('{name}', '{duration}', {genreId}, {directorId}, {studioId}, {labelId}, {artistId}, {albumId})";

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@duration", duration);
                        command.Parameters.AddWithValue("@genreId", genreId);
                        command.Parameters.AddWithValue("@directorId", directorId);
                        command.Parameters.AddWithValue("@studioId", studioId);
                        command.Parameters.AddWithValue("@labelId", labelId);
                        command.Parameters.AddWithValue("@artistId", artistId);
                        command.Parameters.AddWithValue("@albumId", albumId);

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
    }
}
