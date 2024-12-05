namespace kursDB1.Views
{
    partial class AddLabelForm
    {
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dtpBDate;
        private System.Windows.Forms.Button btnSave;

        private void InitializeComponent()
        {
            txtName = new TextBox();
            dtpBDate = new DateTimePicker();
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
            // dtpBDate
            // 
            dtpBDate.Location = new Point(12, 41);
            dtpBDate.Name = "dtpBDate";
            dtpBDate.Size = new Size(200, 23);
            dtpBDate.TabIndex = 2;
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
            // AddLabelForm
            // 
            ClientSize = new Size(222, 103);
            Controls.Add(txtName);
            Controls.Add(dtpBDate);
            Controls.Add(btnSave);
            Name = "AddLabelForm";
            Text = "Добавить лейбл";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
