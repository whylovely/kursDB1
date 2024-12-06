namespace kursDB1.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogin;

        // Необходимо для правильной очистки ресурсов
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Метод для инициализации компонентов
        private void InitializeComponent()
        {
            btnLogin = new Button();
            lblWelcome = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(131, 27);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(100, 23);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(18, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(213, 15);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Приветсвую вас в медийном сервисе";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 27);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 2;
            button1.Text = "Регистрация";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnReg_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(245, 66);
            Controls.Add(button1);
            Controls.Add(lblWelcome);
            Controls.Add(btnLogin);
            Name = "MainForm";
            Text = "Главная";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button button1;
    }
}
