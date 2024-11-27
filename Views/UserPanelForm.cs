using System;
using System.Windows.Forms;
using kursDB1.Controllers;

namespace kursDB1.Views
{
    public partial class UserPanelForm : Form
    {
        private readonly UserController _userController;

        public UserPanelForm(int userId)
        {
            InitializeComponent();
            _userController = new UserController();
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

            _userController.RateArt(selectedArt.Id, mark);

            MessageBox.Show("Оценка сохранена.");
        }
    }
}
