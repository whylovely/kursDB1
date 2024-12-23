using System;
using System.Windows.Forms;

namespace kursDB1.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Hide();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            var regForm = new RegForm();
            regForm.ShowDialog();
            this.Hide();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Приветсвую вас в медийном сервисе";
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
