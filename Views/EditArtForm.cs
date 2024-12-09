using Npgsql;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace kursDB1.Views
{
    public partial class EditArtForm : Form
    {
        private int _artId;
        private readonly string _artName;
        private readonly string _connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        public EditArtForm(int artId)
        {
            InitializeComponent();
            LoadArtDetails(artId);
            _artId = artId;
        }

        private void LoadArtDetails(int artId)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = $"SELECT * FROM arts WHERE id = {artId}";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", artId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["name"].ToString();
                                txtDuration.Text = reader["duration"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string duration = txtDuration.Text.Trim();

                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    var query = $"UPDATE arts SET name = '{name}', duration = '{duration}' WHERE id = {_artId}";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", _artId);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@duration", duration);

                        var result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Запись успешно обновлена.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при обновлении записи.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private void txtDuration_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
