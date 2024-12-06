namespace kursDB1.Views
{
    partial class AddArtForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.TextBox txtStudio;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.TextBox txtAlbum;
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
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.txtStudio = new System.Windows.Forms.TextBox();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.txtAlbum = new System.Windows.Forms.TextBox();
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
            this.txtDuration.Text = "Продолжительность (введите минуты)";

            // txtGenre
            this.txtGenre.Location = new System.Drawing.Point(12, 68);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(260, 23);
            this.txtGenre.TabIndex = 2;
            this.txtGenre.Text = "Жанр";

            // txtDirector
            this.txtDirector.Location = new System.Drawing.Point(12, 96);
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(260, 23);
            this.txtDirector.TabIndex = 3;
            this.txtDirector.Text = "Режиссер";

            // txtStudio
            this.txtStudio.Location = new System.Drawing.Point(12, 124);
            this.txtStudio.Name = "txtStudio";
            this.txtStudio.Size = new System.Drawing.Size(260, 23);
            this.txtStudio.TabIndex = 4;
            this.txtStudio.Text = "Студия";

            // txtLabel
            this.txtLabel.Location = new System.Drawing.Point(12, 152);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(260, 23);
            this.txtLabel.TabIndex = 5;
            this.txtLabel.Text = "Лейбл";

            // txtArtist
            this.txtArtist.Location = new System.Drawing.Point(12, 180);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(260, 23);
            this.txtArtist.TabIndex = 6;
            this.txtArtist.Text = "Артист";

            // txtAlbum
            this.txtAlbum.Location = new System.Drawing.Point(12, 208);
            this.txtAlbum.Name = "txtAlbum";
            this.txtAlbum.Size = new System.Drawing.Size(260, 23);
            this.txtAlbum.TabIndex = 7;
            this.txtAlbum.Text = "Альбом";

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
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.txtDirector);
            this.Controls.Add(this.txtStudio);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.txtArtist);
            this.Controls.Add(this.txtAlbum);
            this.Controls.Add(this.btnSave);
            this.Name = "AddArtForm";
            this.Text = "Добавить произведение";
            this.Load += new System.EventHandler(this.AddArtForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
