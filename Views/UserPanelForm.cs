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
    public partial class UserPanelForm : Form
    {
        private readonly UserController _userController;
        private readonly int _userId;

        public UserPanelForm(int userId)
        {
            InitializeComponent();
            _userController = new UserController();
            _userId = userId;
        }

        private void UserPanelForm_Load(object sender, EventArgs e)
        {
            var arts = _userController.GetArts();
            listBoxArts.DataSource = arts;
            listBoxArts.DisplayMember = "Name";
        }

        private void btnRateArt_Click(object sender, EventArgs e)
        {
            var selectedArt = (Art)listBoxArts.SelectedItem;
            int mark = (int)numericUpDownMark.Value;

            _userController.RateArt(_userId, selectedArt.Id, mark);

            MessageBox.Show("Оценка сохранена.");
        }
    }
}
