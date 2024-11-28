namespace kursDB1.Views
{
    partial class AddArtForm
    {
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.ComboBox cmbGenres;
        private System.Windows.Forms.Button btnSave;

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.cmbGenres = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // txtName
            this.txtName.Location = new System.Drawing.Point(12, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 22);
            this.txtName.TabIndex = 0;

            // txtDuration
            this.txtDuration.Location = new System.Drawing.Point(12, 40);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(200, 22);
            this.txtDuration.TabIndex = 1;

            // cmbGenres
            this.cmbGenres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenres.Location = new System.Drawing.Point(12, 68);
            this.cmbGenres.Name = "cmbGenres";
            this.cmbGenres.Size = new System.Drawing.Size(200, 24);
            this.cmbGenres.TabIndex = 2;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(12, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // AddArtForm
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.cmbGenres);
            this.Controls.Add(this.btnSave);
            this.Name = "AddArtForm";
            this.Text = "Добавить произведение";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
