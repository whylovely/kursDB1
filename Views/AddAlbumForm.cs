using Npgsql;

namespace kursDB1.Views
{
    public partial class AddAlbumForm : Form
    {
        private readonly string _connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        public AddAlbumForm()
        {
            InitializeComponent();
        }

        private void AddAlbumForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, name FROM artists";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var artist = new { Id = reader["id"], Name = reader["name"] };
                                cmbArtists.Items.Add(artist); 
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке артистов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string countArtsText = txtCountArts.Text.Trim();
            DateTime dropDay = dtpDropDay.Value;
            string formattedBDay = dropDay.ToString("yyyy-MM-dd");

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(countArtsText) || !int.TryParse(countArtsText, out int countArts))
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedArtist = cmbArtists.SelectedItem as dynamic;
            if (selectedArtist == null)
            {
                MessageBox.Show("Пожалуйста, выберите артиста.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int artistId = selectedArtist.Id; 

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    string query = $"INSERT INTO Albums (name, count_arts, drop_day, id_artist) VALUES ('{name}', {countArts}, '{formattedBDay}', {artistId})";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@countArts", countArts);
                        command.Parameters.AddWithValue("@dropDay", dropDay);
                        command.Parameters.AddWithValue("@artistId", artistId); 

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
    }
}
