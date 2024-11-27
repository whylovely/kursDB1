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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Добро пожаловать в OnlineArtApp!";
        }
    }
}
