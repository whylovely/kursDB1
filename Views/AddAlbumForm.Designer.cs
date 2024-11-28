namespace kursDB1.Views
{
    partial class AddAlbumForm
    {
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCountArts;
        private System.Windows.Forms.DateTimePicker dtpDropDay;
        private System.Windows.Forms.Button btnSave;

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCountArts = new System.Windows.Forms.TextBox();
            this.dtpDropDay = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // txtName
            this.txtName.Location = new System.Drawing.Point(12, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 22);
            this.txtName.TabIndex = 0;

            // txtCountArts
            this.txtCountArts.Location = new System.Drawing.Point(12, 40);
            this.txtCountArts.Name = "txtCountArts";
            this.txtCountArts.Size = new System.Drawing.Size(200, 22);
            this.txtCountArts.TabIndex = 1;

            // dtpDropDay
            this.dtpDropDay.Location = new System.Drawing.Point(12, 68);
            this.dtpDropDay.Name = "dtpDropDay";
            this.dtpDropDay.Size = new System.Drawing.Size(200, 22);
            this.dtpDropDay.TabIndex = 2;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(12, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // AddAlbumForm
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCountArts);
            this.Controls.Add(this.dtpDropDay);
            this.Controls.Add(this.btnSave);
            this.Name = "AddAlbumForm";
            this.Text = "Добавить Альбом";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
