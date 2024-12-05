namespace kursDB1.Views
{
    partial class AddArtForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.ComboBox cmbGenres;
        private System.Windows.Forms.ComboBox cmbDirectors;
        private System.Windows.Forms.ComboBox cmbStudios;
        private System.Windows.Forms.ComboBox cmbLabels;
        private System.Windows.Forms.ComboBox cmbArtists;
        private System.Windows.Forms.ComboBox cmbAlbums;
        private System.Windows.Forms.Button btnSave;

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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.cmbGenres = new System.Windows.Forms.ComboBox();
            this.cmbDirectors = new System.Windows.Forms.ComboBox();
            this.cmbStudios = new System.Windows.Forms.ComboBox();
            this.cmbLabels = new System.Windows.Forms.ComboBox();
            this.cmbArtists = new System.Windows.Forms.ComboBox();
            this.cmbAlbums = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtName
            this.txtName.Location = new System.Drawing.Point(12, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(260, 23);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "Название";

            // txtDuration
            this.txtDuration.Location = new System.Drawing.Point(12, 40);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(260, 23);
            this.txtDuration.TabIndex = 1;
            this.txtDuration.Text = "Продолжительность (введите как текст)";

            // cmbGenres
            this.cmbGenres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenres.FormattingEnabled = true;
            this.cmbGenres.Location = new System.Drawing.Point(12, 68);
            this.cmbGenres.Name = "cmbGenres";
            this.cmbGenres.Size = new System.Drawing.Size(260, 23);
            this.cmbGenres.TabIndex = 2;
            this.cmbGenres.Text = "Жанр";

            // cmbDirectors
            this.cmbDirectors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirectors.FormattingEnabled = true;
            this.cmbDirectors.Location = new System.Drawing.Point(12, 96);
            this.cmbDirectors.Name = "cmbDirectors";
            this.cmbDirectors.Size = new System.Drawing.Size(260, 23);
            this.cmbDirectors.TabIndex = 3;
            this.cmbDirectors.Text = "Режиссер";

            // cmbStudios
            this.cmbStudios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudios.FormattingEnabled = true;
            this.cmbStudios.Location = new System.Drawing.Point(12, 124);
            this.cmbStudios.Name = "cmbStudios";
            this.cmbStudios.Size = new System.Drawing.Size(260, 23);
            this.cmbStudios.TabIndex = 4;
            this.cmbStudios.Text = "Студия";

            // cmbLabels
            this.cmbLabels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLabels.FormattingEnabled = true;
            this.cmbLabels.Location = new System.Drawing.Point(12, 152);
            this.cmbLabels.Name = "cmbLabels";
            this.cmbLabels.Size = new System.Drawing.Size(260, 23);
            this.cmbLabels.TabIndex = 5;
            this.cmbLabels.Text = "Лейбл";

            // cmbArtists
            this.cmbArtists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArtists.FormattingEnabled = true;
            this.cmbArtists.Location = new System.Drawing.Point(12, 180);
            this.cmbArtists.Name = "cmbArtists";
            this.cmbArtists.Size = new System.Drawing.Size(260, 23);
            this.cmbArtists.TabIndex = 6;
            this.cmbArtists.Text = "Артист";

            // cmbAlbums
            this.cmbAlbums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlbums.FormattingEnabled = true;
            this.cmbAlbums.Location = new System.Drawing.Point(12, 208);
            this.cmbAlbums.Name = "cmbAlbums";
            this.cmbAlbums.Size = new System.Drawing.Size(260, 23);
            this.cmbAlbums.TabIndex = 7;
            this.cmbAlbums.Text = "Альбом";

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(12, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(260, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // AddArtForm
            this.ClientSize = new System.Drawing.Size(284, 271);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.cmbGenres);
            this.Controls.Add(this.cmbDirectors);
            this.Controls.Add(this.cmbStudios);
            this.Controls.Add(this.cmbLabels);
            this.Controls.Add(this.cmbArtists);
            this.Controls.Add(this.cmbAlbums);
            this.Controls.Add(this.btnSave);
            this.Name = "AddArtForm";
            this.Text = "Добавить произведение";
            this.Load += new System.EventHandler(this.AddArtForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
