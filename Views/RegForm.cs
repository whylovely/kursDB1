using System;
using System.Windows.Forms;
using Npgsql; // Для работы с PostgreSQL
using kursDB1.Utils; // Для хэширования пароля

namespace kursDB1.Views
{
    public partial class RegForm : Form
    {
        // Строка подключения к базе данных PostgreSQL
        private readonly string _connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        public RegForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Проверка на заполненность полей
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Все поля должны быть заполнены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка формата почты
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Некорректный формат электронной почты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                // Проверка существования пользователя с таким email или username
                string checkQuery = $"SELECT COUNT(*) FROM Users WHERE email = '{email}' OR name = '{username}'";
                using (var connection = new Npgsql.NpgsqlConnection(_connectionString))
                {
                    var command = new Npgsql.NpgsqlCommand(checkQuery, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Name", username);

                    connection.Open();
                    int userCount = Convert.ToInt32(command.ExecuteScalar());

                    if (userCount > 0)
                    {
                        MessageBox.Show("Пользователь с таким именем или email уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // SQL-запрос для добавления пользователя
                string query = $"INSERT INTO Users (name, email, password, role_id) VALUES ('{username}', '{email}', '{password}', 2)";

                using (var connection = new Npgsql.NpgsqlConnection(_connectionString))
                {
                    var command = new Npgsql.NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", username);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Пользователь успешно зарегистрирован.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Открытие формы входа после регистрации
                        var loginForm = new LoginForm();
                        this.Hide(); // Скрыть форму регистрации
                        loginForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось зарегистрировать пользователя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Проверка формата email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void RegForm_Load(object sender, EventArgs e)
        {
        }
    }
}
