using System;
using System.Windows.Forms;
using Npgsql; // Для работы с PostgreSQL
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

        // Обработчик события для кнопки входа
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // Проверка на заполненность полей
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите email и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Вызов метода аутентификации
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
                MessageBox.Show("Неверный email или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
