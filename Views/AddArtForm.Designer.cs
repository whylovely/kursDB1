namespace kursDB1.Views
{
    partial class AddArtForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.ComboBox cmbDirector;
        private System.Windows.Forms.ComboBox cmbStudio;
        private System.Windows.Forms.ComboBox cmbLabel;
        private System.Windows.Forms.ComboBox cmbArtist;
        private System.Windows.Forms.ComboBox cmbAlbum;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label lblStudio;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblAlbum;

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
            txtName = new TextBox();
            txtDuration = new TextBox();
            cmbGenre = new ComboBox();
            cmbDirector = new ComboBox();
            cmbStudio = new ComboBox();
            cmbLabel = new ComboBox();
            cmbArtist = new ComboBox();
            cmbAlbum = new ComboBox();
            btnSave = new Button();
            lblName = new Label();
            lblDuration = new Label();
            lblGenre = new Label();
            lblDirector = new Label();
            lblStudio = new Label();
            lblLabel = new Label();
            lblArtist = new Label();
            lblAlbum = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(145, 15);
            txtName.Name = "txtName";
            txtName.Size = new Size(260, 23);
            txtName.TabIndex = 1;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtDuration
            // 
            txtDuration.Location = new Point(145, 47);
            txtDuration.Name = "txtDuration";
            txtDuration.Size = new Size(260, 23);
            txtDuration.TabIndex = 3;
            // 
            // cmbGenre
            // 
            cmbGenre.Location = new Point(145, 76);
            cmbGenre.Name = "cmbGenre";
            cmbGenre.Size = new Size(260, 23);
            cmbGenre.TabIndex = 5;
            // 
            // cmbDirector
            // 
            cmbDirector.Location = new Point(145, 105);
            cmbDirector.Name = "cmbDirector";
            cmbDirector.Size = new Size(260, 23);
            cmbDirector.TabIndex = 7;
            // 
            // cmbStudio
            // 
            cmbStudio.Location = new Point(145, 134);
            cmbStudio.Name = "cmbStudio";
            cmbStudio.Size = new Size(260, 23);
            cmbStudio.TabIndex = 9;
            // 
            // cmbLabel
            // 
            cmbLabel.Location = new Point(145, 163);
            cmbLabel.Name = "cmbLabel";
            cmbLabel.Size = new Size(260, 23);
            cmbLabel.TabIndex = 11;
            cmbLabel.SelectedIndexChanged += cmbLabel_SelectedIndexChanged;
            // 
            // cmbArtist
            // 
            cmbArtist.Location = new Point(145, 192);
            cmbArtist.Name = "cmbArtist";
            cmbArtist.Size = new Size(260, 23);
            cmbArtist.TabIndex = 13;
            // 
            // cmbAlbum
            // 
            cmbAlbum.Location = new Point(145, 221);
            cmbAlbum.Name = "cmbAlbum";
            cmbAlbum.Size = new Size(260, 23);
            cmbAlbum.TabIndex = 15;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(145, 250);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(260, 30);
            btnSave.TabIndex = 16;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // lblName
            // 
            lblName.Location = new Point(12, 18);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Название:";
            // 
            // lblDuration
            // 
            lblDuration.Location = new Point(12, 47);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(127, 23);
            lblDuration.TabIndex = 2;
            lblDuration.Text = "Продолжительность:";
            // 
            // lblGenre
            // 
            lblGenre.Location = new Point(12, 79);
            lblGenre.Name = "lblGenre";
            lblGenre.Size = new Size(100, 23);
            lblGenre.TabIndex = 4;
            lblGenre.Text = "Жанр:";
            // 
            // lblDirector
            // 
            lblDirector.Location = new Point(12, 108);
            lblDirector.Name = "lblDirector";
            lblDirector.Size = new Size(100, 23);
            lblDirector.TabIndex = 6;
            lblDirector.Text = "Режиссер:";
            lblDirector.Click += lblDirector_Click;
            // 
            // lblStudio
            // 
            lblStudio.Location = new Point(12, 137);
            lblStudio.Name = "lblStudio";
            lblStudio.Size = new Size(100, 23);
            lblStudio.TabIndex = 8;
            lblStudio.Text = "Студия:";
            // 
            // lblLabel
            // 
            lblLabel.Location = new Point(12, 166);
            lblLabel.Name = "lblLabel";
            lblLabel.Size = new Size(100, 23);
            lblLabel.TabIndex = 10;
            lblLabel.Text = "Лейбл:";
            // 
            // lblArtist
            // 
            lblArtist.Location = new Point(12, 195);
            lblArtist.Name = "lblArtist";
            lblArtist.Size = new Size(100, 23);
            lblArtist.TabIndex = 12;
            lblArtist.Text = "Артист:";
            // 
            // lblAlbum
            // 
            lblAlbum.Location = new Point(12, 224);
            lblAlbum.Name = "lblAlbum";
            lblAlbum.Size = new Size(100, 23);
            lblAlbum.TabIndex = 14;
            lblAlbum.Text = "Альбом:";
            // 
            // AddArtForm
            // 
            ClientSize = new Size(423, 297);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblDuration);
            Controls.Add(txtDuration);
            Controls.Add(lblGenre);
            Controls.Add(cmbGenre);
            Controls.Add(lblDirector);
            Controls.Add(cmbDirector);
            Controls.Add(lblStudio);
            Controls.Add(cmbStudio);
            Controls.Add(lblLabel);
            Controls.Add(cmbLabel);
            Controls.Add(lblArtist);
            Controls.Add(cmbArtist);
            Controls.Add(lblAlbum);
            Controls.Add(cmbAlbum);
            Controls.Add(btnSave);
            Name = "AddArtForm";
            Text = "Добавить произведение";
            Load += AddArtForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
