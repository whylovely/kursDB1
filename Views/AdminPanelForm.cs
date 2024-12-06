using kursDB1.Controllers;
using kursDB1.Utils;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursDB1.Views
{
    public partial class AdminPanelForm : Form
    {
        private DataGridView dgvArts;
        private readonly AdminController _adminController;
        private string connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        public AdminPanelForm()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1");

            _adminController = new AdminController(optionsBuilder.Options);
        }

        private void LoadArts()
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    var query = "SELECT id AS ID, name AS Название, duration AS Продолжительность, id_genre AS Жанр FROM arts";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        using (var adapter = new NpgsqlDataAdapter(command))
                        {
                            var dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dgvArts.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        private void btnDeleteArt_Click(object sender, EventArgs e)
        {
            var selectForm = new DeleteArtForm(connectionString, (selectedArtId) =>
            {
                DeleteArtFromDatabase(selectedArtId);
                LoadArts();
            });
            selectForm.ShowDialog();
        }

        private void DeleteArtFromDatabase(int artId)
        {
            try
            {
                using (var connection = new Npgsql.NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"DELETE FROM arts WHERE id = {artId}";
                    using (var command = new Npgsql.NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", artId);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Запись успешно удалена.");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось удалить запись.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEditArt_Click(object sender, EventArgs e)
        {
            using (var selectArtForm = new SelectArtForm())
            {
                if (selectArtForm.ShowDialog() == DialogResult.OK)
                {
                    int artId = selectArtForm.SelectedArtId;
                    using (var editArtForm = new EditArtForm(artId))
                    {
                        editArtForm.ShowDialog();
                        LoadArts(); // Перезагрузите список произведений после изменения
                    }
                }
            }
        }



        private void btnAddArt_Click(object sender, EventArgs e)
        {
            var addArtForm = new AddArtForm();
            addArtForm.ShowDialog();
        }

        private void btnAddAlbum_Click(object sender, EventArgs e)
        {
            var addAlbumForm = new AddAlbumForm();
            addAlbumForm.ShowDialog();
        }

        private void btnAddLabel_Click(object sender, EventArgs e)
        {
            var addLabelForm = new AddLabelForm();
            addLabelForm.ShowDialog();
        }

        private void btnAddStudio_Click(object sender, EventArgs e)
        {
            var addStudioForm = new AddStudioForm();
            addStudioForm.ShowDialog();
        }

        private void btnAddDirector_Click(object sender, EventArgs e)
        {
            var addDirectorForm = new AddDirectorForm();
            addDirectorForm.ShowDialog();
        }

        private void btnAddGenre_Click(object sender, EventArgs e)
        {
            var addGenreForm = new AddGenreForm();
            addGenreForm.ShowDialog();
        }

        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            var addArtistForm = new AddArtistForm(); 
            addArtistForm.ShowDialog();
        }
     
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportSelectionForm();
            reportForm.ShowDialog();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы вышли из системы.");
            this.Close();
            var loginForm = new LoginForm();
            loginForm.Show();
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Добро пожаловать в панель администратора!";
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
