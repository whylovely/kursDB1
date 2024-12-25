namespace kursDB1.Views
{
    public partial class RegForm : Form
    {
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

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Все поля должны быть заполнены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Некорректный формат электронной почты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            { 
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE email = @Email OR name = @Name";
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

                
                string query = "INSERT INTO Users (name, email, password, role_id) VALUES (@Name, @Email, @Password, 2)";

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

                        var loginForm = new LoginForm();
                        this.Hide(); 
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
