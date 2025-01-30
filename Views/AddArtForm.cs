using System.Data;
using Npgsql;

namespace kursDB1.Views
{
    public partial class AddArtForm : Form
    {
        private readonly string _connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        public AddArtForm()
        {
            InitializeComponent();
        }

        public DeleteArtForm DeleteArtForm
        {
            get => default;
            set
            {
            }
        }

        public EditArtForm EditArtForm
        {
            get => default;
            set
            {
            }
        }

        public RateArtForm RateArtForm
        {
            get => default;
            set
            {
            }
        }

        public SelectArtForm SelectArtForm
        {
            get => default;
            set
            {
            }
        }

        private void AddArtForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBox(cmbGenre, "genres", "id", "name");
                LoadComboBox(cmbStudio, "studios", "id", "name");
                LoadComboBox(cmbDirector, "directors", "id", "name");
                LoadComboBox(cmbLabel, "labels", "id", "name");
                LoadComboBox(cmbArtist, "artists", "id", "name");
                LoadComboBox(cmbAlbum, "albums", "id", "name");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                if (!int.TryParse(txtDuration.Text.Trim(), out int duration) || duration <= 0)
                {
                    MessageBox.Show("Введите корректное значение продолжительности.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int genreId = GetSelectedComboBoxValue(cmbGenre);
                int studioId = GetSelectedComboBoxValue(cmbStudio);
                int directorId = GetSelectedComboBoxValue(cmbDirector);
                int labelId = GetSelectedComboBoxValue(cmbLabel);
                int artistId = GetSelectedComboBoxValue(cmbArtist);
                int albumId = GetSelectedComboBoxValue(cmbAlbum);

                if (genreId == -1 || studioId == -1 || directorId == -1 || labelId == -1 || artistId == -1 || albumId == -1)
                {
                    MessageBox.Show("Выберите все связанные сущности из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    string query = @"
                        INSERT INTO Arts (name, duration, id_genre, id_director, id_studio, id_label, id_artist, id_album) 
                        VALUES (@name, @duration, @genreId, @directorId, @studioId, @labelId, @artistId, @albumId)";

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

        /// <summary>
        /// Загрузка данных в ComboBox.
        /// </summary>
        /// <param name="comboBox">ComboBox для заполнения.</param>
        /// <param name="tableName">Имя таблицы в базе данных.</param>
        /// <param name="valueMember">Поле ID.</param>
        /// <param name="displayMember">Поле для отображения.</param>
        private void LoadComboBox(ComboBox comboBox, string tableName, string valueMember, string displayMember)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string query = $"SELECT {valueMember}, {displayMember} FROM {tableName}";
                using (var command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);
                        comboBox.DataSource = dataTable;
                        comboBox.DisplayMember = displayMember;
                        comboBox.ValueMember = valueMember;
                        comboBox.SelectedIndex = -1; 
                    }
                }
            }
        }

        /// <summary>
        /// Получает выбранное значение ID из ComboBox.
        /// </summary>
        /// <param name="comboBox">ComboBox с выбором.</param>
        /// <returns>ID или -1, если ничего не выбрано.</returns>
        private int GetSelectedComboBoxValue(ComboBox comboBox)
        {
            if (comboBox.SelectedItem is DataRowView rowView)
            {
                return Convert.ToInt32(rowView[comboBox.ValueMember]);
            }
            return -1; // Ничего не выбрано
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDirector_Click(object sender, EventArgs e)
        {

        }

        private void cmbLabel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
