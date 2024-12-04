namespace kursDB1.Views
{
    partial class RegForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            lblConfirmPassword = new Label();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(150, 67);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(200, 23);
            txtEmail.TabIndex = 1;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(30, 67);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(116, 15);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Электронная почта:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(150, 30);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(200, 23);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(150, 101);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 1;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(150, 135);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(200, 23);
            txtConfirmPassword.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(30, 30);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(112, 15);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Имя пользователя:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(30, 101);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(52, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Пароль:";
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Location = new Point(30, 138);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(123, 15);
            lblConfirmPassword.TabIndex = 5;
            lblConfirmPassword.Text = "Подтвердите пароль:";
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(82, 173);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(200, 30);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Зарегистрироваться";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegForm
            // 
            ClientSize = new Size(400, 240);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(btnRegister);
            Name = "RegForm";
            Text = "Регистрация пользователя";
            Load += RegForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
