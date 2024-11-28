using System;
using System.Windows.Forms;
using kursDB1.Controllers;
using kursDB1.Models;
using kursDB1.Utils;
using Microsoft.EntityFrameworkCore;

namespace kursDB1.Views
{
    public partial class AddAlbumForm : Form
    {
        private readonly AdminController _adminController;

        public AddAlbumForm()
        {
            InitializeComponent();

            // Создаем DbContextOptions для передачи в AdminController
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=2005;Database=db1");

            _adminController = new AdminController(optionsBuilder.Options);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var album = new Album
            {
                Name = txtName.Text,
                CountArts = int.Parse(txtCountArts.Text),
                DropDay = dtpDropDay.Value
            };

            _adminController.AddAlbum(album);
            MessageBox.Show("Альбом добавлен!");
            this.Close();
        }
    }
}
