using kursDB1.Controllers;
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
        private readonly AdminController _adminController;
        public AdminPanelForm()
        {
            InitializeComponent();
            _adminController = new AdminController();
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


    }
}
