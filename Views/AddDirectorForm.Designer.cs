namespace kursDB1.Views
{
    partial class AddDirectorForm
    {
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtName
            this.txtName.Location = new System.Drawing.Point(12, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 22);
            this.txtName.TabIndex = 0;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(12, 40);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // AddDirectorForm
            this.ClientSize = new System.Drawing.Size(284, 81);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSave);
            this.Name = "AddDirectorForm";
            this.Text = "Добавить режиссера";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
