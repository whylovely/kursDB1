using System;
using System.Windows.Forms;
using kursDB1.Controllers;
using kursDB1.Models;

namespace kursDB1.Views
{
    public partial class AddGenreForm : Form
    {
        private readonly AdminController _adminController;

        public AddGenreForm()
        {
            InitializeComponent();
            _adminController = new AdminController();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var genre = new Genre
            {
                Name = txtName.Text
            };

            _adminController.AddGenre(genre);
            MessageBox.Show("Жанр добавлен!");
            this.Close();
        }
    }
}
