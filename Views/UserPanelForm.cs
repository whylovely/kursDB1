using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace kursDB1.Views
{
    public partial class UserPanelForm : Form
    {
        private readonly int _userId;
        private DataGridView dgvArts;

        private const string ConnectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        public UserPanelForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

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
            string query = "SELECT * FROM arts WHERE id_artist IS NOT NULL";
            LoadArts(query);
        }

        private void btnViewMovies_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM arts WHERE id_artist IS NULL";
            LoadArts(query);
        }

        private void LoadAllArts()
        {
            string query = "SELECT * FROM arts";
            LoadArts(query);
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
