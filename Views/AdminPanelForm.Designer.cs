namespace kursDB1.Views
{
    partial class AdminPanelForm
    {
        private System.Windows.Forms.Button btnAddArt;
        private System.Windows.Forms.Button btnAddAlbum;
        private System.Windows.Forms.Button btnAddLabel;
        private System.Windows.Forms.Button btnAddStudio;
        private System.Windows.Forms.Button btnAddDirector;
        private System.Windows.Forms.Button btnAddGenre;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcome;

        private void InitializeComponent()
        {
            this.btnAddArt = new System.Windows.Forms.Button();
            this.btnAddAlbum = new System.Windows.Forms.Button();
            this.btnAddLabel = new System.Windows.Forms.Button();
            this.btnAddStudio = new System.Windows.Forms.Button();
            this.btnAddDirector = new System.Windows.Forms.Button();
            this.btnAddGenre = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // btnAddArt
            this.btnAddArt.Location = new System.Drawing.Point(12, 12);
            this.btnAddArt.Name = "btnAddArt";
            this.btnAddArt.Size = new System.Drawing.Size(200, 30);
            this.btnAddArt.TabIndex = 0;
            this.btnAddArt.Text = "Добавить произведение";
            this.btnAddArt.UseVisualStyleBackColor = true;
            this.btnAddArt.Click += new System.EventHandler(this.btnAddArt_Click);

            // btnAddAlbum
            this.btnAddAlbum.Location = new System.Drawing.Point(12, 48);
            this.btnAddAlbum.Name = "btnAddAlbum";
            this.btnAddAlbum.Size = new System.Drawing.Size(200, 30);
            this.btnAddAlbum.TabIndex = 1;
            this.btnAddAlbum.Text = "Добавить альбом";
            this.btnAddAlbum.UseVisualStyleBackColor = true;
            this.btnAddAlbum.Click += new System.EventHandler(this.btnAddAlbum_Click);

            // btnAddLabel
            this.btnAddLabel.Location = new System.Drawing.Point(12, 84);
            this.btnAddLabel.Name = "btnAddLabel";
            this.btnAddLabel.Size = new System.Drawing.Size(200, 30);
            this.btnAddLabel.TabIndex = 2;
            this.btnAddLabel.Text = "Добавить лейбл";
            this.btnAddLabel.UseVisualStyleBackColor = true;
            this.btnAddLabel.Click += new System.EventHandler(this.btnAddLabel_Click);

            // btnAddStudio
            this.btnAddStudio.Location = new System.Drawing.Point(12, 120);
            this.btnAddStudio.Name = "btnAddStudio";
            this.btnAddStudio.Size = new System.Drawing.Size(200, 30);
            this.btnAddStudio.TabIndex = 3;
            this.btnAddStudio.Text = "Добавить студию";
            this.btnAddStudio.UseVisualStyleBackColor = true;
            this.btnAddStudio.Click += new System.EventHandler(this.btnAddStudio_Click);

            // btnAddDirector
            this.btnAddDirector.Location = new System.Drawing.Point(12, 156);
            this.btnAddDirector.Name = "btnAddDirector";
            this.btnAddDirector.Size = new System.Drawing.Size(200, 30);
            this.btnAddDirector.TabIndex = 4;
            this.btnAddDirector.Text = "Добавить режиссера";
            this.btnAddDirector.UseVisualStyleBackColor = true;
            this.btnAddDirector.Click += new System.EventHandler(this.btnAddDirector_Click);

            // btnAddGenre
            this.btnAddGenre.Location = new System.Drawing.Point(12, 192);
            this.btnAddGenre.Name = "btnAddGenre";
            this.btnAddGenre.Size = new System.Drawing.Size(200, 30);
            this.btnAddGenre.TabIndex = 5;
            this.btnAddGenre.Text = "Добавить жанр";
            this.btnAddGenre.UseVisualStyleBackColor = true;
            this.btnAddGenre.Click += new System.EventHandler(this.btnAddGenre_Click);

            // btnLogout
            this.btnLogout.Location = new System.Drawing.Point(12, 228);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 30);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Выйти";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(12, 270);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(200, 20);
            this.lblWelcome.TabIndex = 7;
            this.lblWelcome.Text = "Добро пожаловать в панель администратора!";

            // AdminPanelForm
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.btnAddArt);
            this.Controls.Add(this.btnAddAlbum);
            this.Controls.Add(this.btnAddLabel);
            this.Controls.Add(this.btnAddStudio);
            this.Controls.Add(this.btnAddDirector);
            this.Controls.Add(this.btnAddGenre);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblWelcome);
            this.Name = "AdminPanelForm";
            this.Text = "Панель администратора";
            this.Load += new System.EventHandler(this.AdminPanelForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
