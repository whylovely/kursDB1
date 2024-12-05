namespace kursDB1.Views
{
    partial class AddGenreForm
    {
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;

        private void InitializeComponent()
        {
            txtName = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 0;
            txtName.Text = "Название";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 40);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 23);
            btnSave.TabIndex = 1;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // AddGenreForm
            // 
            ClientSize = new Size(224, 81);
            Controls.Add(txtName);
            Controls.Add(btnSave);
            Name = "AddGenreForm";
            Text = "Добавить жанр";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
