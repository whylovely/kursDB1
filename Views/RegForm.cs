using System;
using System.Windows.Forms;
using kursDB1.Utils; // Для хэширования пароля
using kursDB1.Models; // Для модели пользователя
using kursDB1.Services; // Для сервиса добавления пользователя

namespace kursDB1.Views
{
    public partial class RegForm : Form
    {
        private readonly UserService _userService;

        public RegForm()
        {
            InitializeComponent();
            _userService = new UserService(); // Инициализация UserService для работы с пользователями
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Проверка, чтобы оба пароля совпадали
            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Хэшируем пароль перед сохранением
            string hashedPassword = PasswordHasher.HashPassword(password);

            try
            {
                // Создание нового пользователя
                var user = new User
                {
                    Name = username,
                    Password = hashedPassword
                };

                // Добавление пользователя в базу данных через сервис
                _userService.AddUser(user);

                MessageBox.Show("Пользователь успешно зарегистрирован.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Открытие формы входа после регистрации
                var loginForm = new LoginForm();
                this.Hide(); // Скрыть форму регистрации
                loginForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
