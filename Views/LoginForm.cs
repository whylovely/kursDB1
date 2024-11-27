using System;
using System.Windows.Forms;
using kursDB1.Controllers;

namespace kursDB1.Views
{
    public partial class LoginForm : Form
    {
        private readonly AuthController _authController;

        public LoginForm()
        {
            InitializeComponent();
            _authController = new AuthController();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            var user = _authController.Login(email, password);

            if (user != null)
            {
                MessageBox.Show($"Добро пожаловать, {user.Name}!");

                if (user.RoleId == 1) // Администратор
                {
                    var adminPanel = new AdminPanelForm();
                    adminPanel.Show();
                }
                else // Пользователь
                {
                    var userPanel = new UserPanelForm(user.Id);
                    userPanel.Show();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный email или пароль.");
            }
        }
    }
}
