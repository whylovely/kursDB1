using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace kursDB1.Views
{
    public partial class SelectArtForm : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";
        public int SelectedArtId { get; private set; }

        public SelectArtForm()
        {
            InitializeComponent();
            LoadArts();
        }

        private void LoadArts()
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT id, name FROM arts";
                    using (var command = new NpgsqlCommand(query, connection))
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable arts = new DataTable();
                        adapter.Fill(arts);
                        dgvArts.DataSource = arts;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvArts.SelectedRows.Count > 0)
            {
                SelectedArtId = (int)dgvArts.SelectedRows[0].Cells["id"].Value;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Выберите произведение.");
            }
        }
    }
}
