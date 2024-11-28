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
    public partial class AddDirectorForm : Form
    {

        private readonly AdminController _adminController;

        public AddDirectorForm()
        {
            InitializeComponent();
            _adminController = new AdminController();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var director = new Director
            {
                Name = txtName.Text
            };

            _adminController.AddDirector(director);
            MessageBox.Show("Режиссер добавлен!");
            this.Close();
        }
    }
}
