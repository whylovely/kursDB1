using System.Data;
using Npgsql;

namespace kursDB1.Views
{
    public partial class DeleteArtForm : Form
    {
        private readonly string _connectionString;
        private readonly Action<int> _onArtSelected;

        public DeleteArtForm(string connectionString, Action<int> onArtSelected)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _onArtSelected = onArtSelected;

            LoadArts();
        }

        private void LoadArts()
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT id, name FROM arts";
                    using (var command = new NpgsqlCommand(query, connection))
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable artsTable = new DataTable();
                        adapter.Fill(artsTable);
                        dgvArts.DataSource = artsTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvArts.SelectedRows.Count > 0)
            {
                int selectedArtId = (int)dgvArts.SelectedRows[0].Cells["id"].Value;
                DeleteArt(selectedArtId);
                LoadArts();
            }
            else
            {
                MessageBox.Show("Выберите произведение для удаления.");
            }
        }

        private void DeleteArt(int artId)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        string deleteMarksQuery = "DELETE FROM marks WHERE id_art = @artId";
                        using (var deleteMarksCommand = new NpgsqlCommand(deleteMarksQuery, connection))
                        {
                            deleteMarksCommand.Parameters.AddWithValue("@artId", artId);
                            deleteMarksCommand.Transaction = transaction;
                            deleteMarksCommand.ExecuteNonQuery();
                        }

                        string deleteArtQuery = "DELETE FROM arts WHERE id = @artId";
                        using (var deleteArtCommand = new NpgsqlCommand(deleteArtQuery, connection))
                        {
                            deleteArtCommand.Parameters.AddWithValue("@artId", artId);
                            deleteArtCommand.Transaction = transaction;
                            deleteArtCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }

                    MessageBox.Show("Произведение успешно удалено.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления произведения: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
