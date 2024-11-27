using System;
using System.Windows.Forms;
using kursDB1.Controllers;
using kursDB1.Models;

namespace kursDB1.Views
{
    public partial class AddStudioForm : Form
    {
        private readonly AdminController _adminController;

        public AddStudioForm()
        {
            InitializeComponent();
            _adminController = new AdminController();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var studio = new Studio
            {
                Name = txtName.Text,
                CountArts = int.Parse(txtCountArts.Text),
                BDay = dtpBDay.Value
            };

            _adminController.AddStudio(studio);
            MessageBox.Show("Студия добавлена!");
            this.Close();
        }
    }
}
