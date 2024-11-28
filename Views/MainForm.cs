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

        // Обработчик для кнопки входа
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Создание и отображение формы для входа
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        // Обработчик для загрузки формыb
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Установить текст для метки
            lblWelcome.Text = "Добро пожаловать в OnlineArtApp!";
        }
    }
}
