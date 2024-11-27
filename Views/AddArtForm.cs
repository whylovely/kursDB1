using System;
using System.Windows.Forms;
using kursDB1.Controllers;
using kursDB1.Models;

namespace kursDB1.Views
{
    public partial class AddArtForm : Form
    {
        private readonly AdminController _adminController;

        public AddArtForm()
        {
            InitializeComponent();
            _adminController = new AdminController();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var art = new Art
            {
                Name = txtName.Text,
                Duration = int.Parse(txtDuration.Text),
                IdGenre = int.Parse(cmbGenres.SelectedValue.ToString()),
                // Дополнить остальные поля
            };

            _adminController.AddArt(art);
            MessageBox.Show("Произведение добавлено!");
            this.Close();
        }
    }
}
