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
        private System.Windows.Forms.Button btnAddArtist;


        private void InitializeComponent()
        {
            btnAddArt = new Button();
            btnAddAlbum = new Button();
            btnAddLabel = new Button();
            btnAddStudio = new Button();
            btnAddDirector = new Button();
            btnAddGenre = new Button();
            btnLogout = new Button();
            lblWelcome = new Label();
            btnAddArtist = new Button();
            SuspendLayout();
            // 
            // btnAddArt
            // 
            btnAddArt.Location = new Point(12, 12);
            btnAddArt.Name = "btnAddArt";
            btnAddArt.Size = new Size(200, 30);
            btnAddArt.TabIndex = 0;
            btnAddArt.Text = "Добавить произведение";
            btnAddArt.UseVisualStyleBackColor = true;
            btnAddArt.Click += btnAddArt_Click;
            // 
            // btnAddAlbum
            // 
            btnAddAlbum.Location = new Point(12, 48);
            btnAddAlbum.Name = "btnAddAlbum";
            btnAddAlbum.Size = new Size(200, 30);
            btnAddAlbum.TabIndex = 1;
            btnAddAlbum.Text = "Добавить альбом";
            btnAddAlbum.UseVisualStyleBackColor = true;
            btnAddAlbum.Click += btnAddAlbum_Click;
            // 
            // btnAddLabel
            // 
            btnAddLabel.Location = new Point(12, 84);
            btnAddLabel.Name = "btnAddLabel";
            btnAddLabel.Size = new Size(200, 30);
            btnAddLabel.TabIndex = 2;
            btnAddLabel.Text = "Добавить лейбл";
            btnAddLabel.UseVisualStyleBackColor = true;
            btnAddLabel.Click += btnAddLabel_Click;
            // 
            // btnAddStudio
            // 
            btnAddStudio.Location = new Point(12, 120);
            btnAddStudio.Name = "btnAddStudio";
            btnAddStudio.Size = new Size(200, 30);
            btnAddStudio.TabIndex = 3;
            btnAddStudio.Text = "Добавить студию";
            btnAddStudio.UseVisualStyleBackColor = true;
            btnAddStudio.Click += btnAddStudio_Click;
            // 
            // btnAddDirector
            // 
            btnAddDirector.Location = new Point(12, 156);
            btnAddDirector.Name = "btnAddDirector";
            btnAddDirector.Size = new Size(200, 30);
            btnAddDirector.TabIndex = 4;
            btnAddDirector.Text = "Добавить режиссера";
            btnAddDirector.UseVisualStyleBackColor = true;
            btnAddDirector.Click += btnAddDirector_Click;
            // 
            // btnAddGenre
            // 
            btnAddGenre.Location = new Point(12, 192);
            btnAddGenre.Name = "btnAddGenre";
            btnAddGenre.Size = new Size(200, 30);
            btnAddGenre.TabIndex = 5;
            btnAddGenre.Text = "Добавить жанр";
            btnAddGenre.UseVisualStyleBackColor = true;
            btnAddGenre.Click += btnAddGenre_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 264);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 30);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(12, 307);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(260, 15);
            lblWelcome.TabIndex = 7;
            lblWelcome.Text = "Добро пожаловать в панель администратора!";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // btnAddArtist
            // 
            btnAddArtist.Location = new Point(12, 228);
            btnAddArtist.Name = "btnAddArtist";
            btnAddArtist.Size = new Size(200, 30);
            btnAddArtist.TabIndex = 7;
            btnAddArtist.Text = "Добавить артиста";
            btnAddArtist.UseVisualStyleBackColor = true;
            btnAddArtist.Click += btnAddArtist_Click;
            // 
            // AdminPanelForm
            // 
            ClientSize = new Size(284, 350);
            Controls.Add(btnAddArtist);
            Controls.Add(btnAddArt);
            Controls.Add(btnAddAlbum);
            Controls.Add(btnAddLabel);
            Controls.Add(btnAddStudio);
            Controls.Add(btnAddDirector);
            Controls.Add(btnAddGenre);
            Controls.Add(btnLogout);
            Controls.Add(lblWelcome);
            Name = "AdminPanelForm";
            Text = "Панель администратора";
            Load += AdminPanelForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
