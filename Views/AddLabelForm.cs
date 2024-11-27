using System;
using System.Windows.Forms;
using kursDB1.Controllers;
using kursDB1.Models;

namespace kursDB1.Views
{
    public partial class AddLabelForm : Form
    {
        private readonly AdminController _adminController;

        public AddLabelForm()
        {
            InitializeComponent();
            _adminController = new AdminController();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var label = new Label
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
