using kursDB1.Utils;

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
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите email и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = _authController.Login(email, password);

            if (user != null)
            {
                MessageBox.Show($"Добро пожаловать, {user.Name}!");

                if (user.RoleId == 1) 
                {
                    var adminPanel = new AdminPanelForm();
                    adminPanel.Show();
                }
                else 
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
