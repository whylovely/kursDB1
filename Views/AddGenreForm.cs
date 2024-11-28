using kursDB1.Controllers;
using kursDB1.Models;
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
