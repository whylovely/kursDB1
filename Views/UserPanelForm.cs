using System;
using System.Data;
using System.Windows.Forms;

namespace kursDB1.Views
{
    public partial class UserPanelForm : Form
    {
        private readonly int _userId;
        private DataGridView dgvArts;
        private Button btnReturn;

        private const string ConnectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        public UserPanelForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        public AddAlbumForm AddAlbumForm
        {
            get => default;
            set
            {
            }
        }

        public AddArtistForm AddArtistForm
        {
            get => default;
            set
            {
            }
        }

        private void LoadArts(string query)
        {
            try
            {
                using (var connection = new Npgsql.NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new Npgsql.NpgsqlCommand(query, connection))
                    {
                        using (var adapter = new Npgsql.NpgsqlDataAdapter(command))
                        {
                            DataTable arts = new DataTable();
                            adapter.Fill(arts);
                            dgvArts.DataSource = arts;

                            dgvArts.Columns["id"].HeaderText = "Номер";
                            dgvArts.Columns["name"].HeaderText = "Название";
                            dgvArts.Columns["genre_name"].HeaderText = "Жанр";
                            dgvArts.Columns["director_name"].HeaderText = "Режиссер";
                            dgvArts.Columns["artist_name"].HeaderText = "Артист";
                            dgvArts.Columns["album_name"].HeaderText = "Альбом";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void btnRateArt_Click(object sender, EventArgs e)
        {
            if (dgvArts.SelectedRows.Count > 0)
            {
                var selectedRow = dgvArts.SelectedRows[0];
                int artId = (int)selectedRow.Cells["id"].Value;

                using (var rateForm = new RateArtForm(artId, _userId))
                {
                    rateForm.ShowDialog();
                    LoadAllArts();
                }
            }
            else
            {
                MessageBox.Show("Выберите произведение для оценки.");
            }
        }

        private void btnViewMusic_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT 
                    arts.id, 
                    arts.name, 
                    genres.name AS genre_name, 
                    NULL AS director_name, 
                    artists.name AS artist_name, 
                    albums.name AS album_name
                FROM arts
                LEFT JOIN genres ON arts.id_genre = genres.id
                LEFT JOIN artists ON arts.id_artist = artists.id
                LEFT JOIN albums ON arts.id_album = albums.id
                WHERE arts.id_director = 7";
            LoadArts(query);
        }

        private void btnViewMovies_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT 
                    arts.id, 
                    arts.name, 
                    genres.name AS genre_name, 
                    directors.name AS director_name, 
                    NULL AS artist_name, 
                    NULL AS album_name
                FROM arts
                LEFT JOIN genres ON arts.id_genre = genres.id
                LEFT JOIN directors ON arts.id_director = directors.id
                WHERE arts.id_artist = 0";

            try
            {
                using (var connection = new Npgsql.NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new Npgsql.NpgsqlCommand(query, connection))
                    {
                        using (var adapter = new Npgsql.NpgsqlDataAdapter(command))
                        {
                            DataTable arts = new DataTable();
                            adapter.Fill(arts);
                            dgvArts.DataSource = arts;

                            dgvArts.Columns["id"].HeaderText = "Номер";
                            dgvArts.Columns["name"].HeaderText = "Название";
                            dgvArts.Columns["genre_name"].HeaderText = "Жанр";
                            dgvArts.Columns["director_name"].HeaderText = "Режиссер";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            LoadAllArts();
        }

        private void LoadAllArts()
        {
            string query = @"
                SELECT 
                    arts.id, 
                    arts.name, 
                    genres.name AS genre_name, 
                    directors.name AS director_name, 
                    artists.name AS artist_name, 
                    albums.name AS album_name
                FROM arts
                LEFT JOIN genres ON arts.id_genre = genres.id
                LEFT JOIN directors ON arts.id_director = directors.id
                LEFT JOIN artists ON arts.id_artist = artists.id
                LEFT JOIN albums ON arts.id_album = albums.id";

            try
            {
                using (var connection = new Npgsql.NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    using (var command = new Npgsql.NpgsqlCommand(query, connection))
                    {
                        using (var adapter = new Npgsql.NpgsqlDataAdapter(command))
                        {
                            DataTable arts = new DataTable();
                            adapter.Fill(arts);
                            dgvArts.DataSource = arts;

                            dgvArts.Columns["id"].HeaderText = "Номер";
                            dgvArts.Columns["name"].HeaderText = "Название";
                            dgvArts.Columns["genre_name"].HeaderText = "Жанр";
                            dgvArts.Columns["artist_name"].HeaderText = "Артист";
                            dgvArts.Columns["album_name"].HeaderText = "Альбом";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void UserPanelForm_Load(object sender, EventArgs e)
        {
            LoadAllArts();
        }

        private void dgvArts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
