using System;
using System.Windows.Forms;
using kursDB1.Controllers;
using kursDB1.Models;
using kursDB1.Utils;
using Microsoft.EntityFrameworkCore;

namespace kursDB1.Views
{
    public partial class AddLabelForm : Form
    {
        private readonly AdminController _adminController;

        public AddLabelForm()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=2005;Database=db1");

            _adminController = new AdminController(optionsBuilder.Options);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var label = new MusicLabel
            {
                Name = txtName.Text,
                CountArts = int.Parse(txtCountArts.Text),
                BDate = dtpBDate.Value
            };

            _adminController.AddLabel(label);
            MessageBox.Show("Лейбл добавлен!");
            this.Close();
        }
    }
}
