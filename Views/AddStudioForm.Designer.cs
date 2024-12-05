namespace kursDB1.Views
{
    partial class AddStudioForm
    {
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dtpBDay;
        private System.Windows.Forms.Button btnSave;

        private void InitializeComponent()
        {
            txtName = new TextBox();
            dtpBDay = new DateTimePicker();
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
            // dtpBDay
            // 
            dtpBDay.Location = new Point(12, 41);
            dtpBDay.Name = "dtpBDay";
            dtpBDay.Size = new Size(200, 23);
            dtpBDay.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 69);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // AddStudioForm
            // 
            ClientSize = new Size(229, 104);
            Controls.Add(txtName);
            Controls.Add(dtpBDay);
            Controls.Add(btnSave);
            Name = "AddStudioForm";
            Text = "Добавить студию";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
