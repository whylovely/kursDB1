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
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnAddArtist;
        private System.Windows.Forms.Button btnDeleteArt;
        private System.Windows.Forms.Button btnEditArt;

        private void InitializeComponent()
        {
            btnAddArt = new Button();
            btnAddAlbum = new Button();
            btnAddLabel = new Button();
            btnAddStudio = new Button();
            btnAddDirector = new Button();
            btnAddGenre = new Button();
            btnLogout = new Button();
            btnGenerateReport = new Button();
            lblWelcome = new Label();
            btnAddArtist = new Button();
            btnDeleteArt = new Button();
            btnEditArt = new Button();
            SuspendLayout();
            // 
            // btnAddArt
            // 
            btnAddArt.Location = new Point(43, 12);
            btnAddArt.Name = "btnAddArt";
            btnAddArt.Size = new Size(200, 30);
            btnAddArt.TabIndex = 0;
            btnAddArt.Text = "Добавить произведение";
            btnAddArt.UseVisualStyleBackColor = true;
            btnAddArt.Click += btnAddArt_Click;
            // 
            // btnAddAlbum
            // 
            btnAddAlbum.Location = new Point(43, 48);
            btnAddAlbum.Name = "btnAddAlbum";
            btnAddAlbum.Size = new Size(200, 30);
            btnAddAlbum.TabIndex = 1;
            btnAddAlbum.Text = "Добавить альбом";
            btnAddAlbum.UseVisualStyleBackColor = true;
            btnAddAlbum.Click += btnAddAlbum_Click;
            // 
            // btnAddLabel
            // 
            btnAddLabel.Location = new Point(43, 84);
            btnAddLabel.Name = "btnAddLabel";
            btnAddLabel.Size = new Size(200, 30);
            btnAddLabel.TabIndex = 2;
            btnAddLabel.Text = "Добавить лейбл";
            btnAddLabel.UseVisualStyleBackColor = true;
            btnAddLabel.Click += btnAddLabel_Click;
            // 
            // btnAddStudio
            // 
            btnAddStudio.Location = new Point(43, 120);
            btnAddStudio.Name = "btnAddStudio";
            btnAddStudio.Size = new Size(200, 30);
            btnAddStudio.TabIndex = 3;
            btnAddStudio.Text = "Добавить студию";
            btnAddStudio.UseVisualStyleBackColor = true;
            btnAddStudio.Click += btnAddStudio_Click;
            // 
            // btnAddDirector
            // 
            btnAddDirector.Location = new Point(43, 156);
            btnAddDirector.Name = "btnAddDirector";
            btnAddDirector.Size = new Size(200, 30);
            btnAddDirector.TabIndex = 4;
            btnAddDirector.Text = "Добавить режиссера";
            btnAddDirector.UseVisualStyleBackColor = true;
            btnAddDirector.Click += btnAddDirector_Click;
            // 
            // btnAddGenre
            // 
            btnAddGenre.Location = new Point(250, 84);
            btnAddGenre.Name = "btnAddGenre";
            btnAddGenre.Size = new Size(200, 30);
            btnAddGenre.TabIndex = 5;
            btnAddGenre.Text = "Добавить жанр";
            btnAddGenre.UseVisualStyleBackColor = true;
            btnAddGenre.Click += btnAddGenre_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(142, 192);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 30);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(250, 156);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(200, 30);
            btnGenerateReport.TabIndex = 8;
            btnGenerateReport.Text = "Создать отчёт";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(109, 240);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(260, 15);
            lblWelcome.TabIndex = 9;
            lblWelcome.Text = "Добро пожаловать в панель администратора!";
            lblWelcome.Click += lblWelcome_Click;
            // 
            // btnAddArtist
            // 
            btnAddArtist.Location = new Point(250, 120);
            btnAddArtist.Name = "btnAddArtist";
            btnAddArtist.Size = new Size(200, 30);
            btnAddArtist.TabIndex = 7;
            btnAddArtist.Text = "Добавить артиста";
            btnAddArtist.UseVisualStyleBackColor = true;
            btnAddArtist.Click += btnAddArtist_Click;
            // 
            // btnDeleteArt
            // 
            btnDeleteArt.Location = new Point(250, 12);
            btnDeleteArt.Name = "btnDeleteArt";
            btnDeleteArt.Size = new Size(200, 30);
            btnDeleteArt.TabIndex = 10;
            btnDeleteArt.Text = "Удалить произведение";
            btnDeleteArt.UseVisualStyleBackColor = true;
            btnDeleteArt.Click += btnDeleteArt_Click;
            // 
            // btnEditArt
            // 
            btnEditArt.Location = new Point(250, 48);
            btnEditArt.Name = "btnEditArt";
            btnEditArt.Size = new Size(200, 30);
            btnEditArt.TabIndex = 11;
            btnEditArt.Text = "Изменить произведение";
            btnEditArt.UseVisualStyleBackColor = true;
            btnEditArt.Click += btnEditArt_Click;
            // 
            // AdminPanelForm
            // 
            ClientSize = new Size(486, 272);
            Controls.Add(btnDeleteArt);
            Controls.Add(btnEditArt);
            Controls.Add(btnAddArtist);
            Controls.Add(btnAddArt);
            Controls.Add(btnAddAlbum);
            Controls.Add(btnAddLabel);
            Controls.Add(btnAddStudio);
            Controls.Add(btnAddDirector);
            Controls.Add(btnAddGenre);
            Controls.Add(btnGenerateReport);
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
