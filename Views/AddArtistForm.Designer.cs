namespace kursDB1.Views
{
    partial class AddArtistForm
    {
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblName;

        private void InitializeComponent()
        {
            txtName = new TextBox();
            btnSave = new Button();
            lblName = new Label();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(12, 32);
            txtName.Name = "txtName";
            txtName.Size = new Size(260, 23);
            txtName.TabIndex = 0;
            txtName.Text = "Имя артиста";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 112);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(260, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(12, 16);
            lblName.Name = "lblName";
            lblName.Size = new Size(79, 15);
            lblName.TabIndex = 3;
            lblName.Text = "Имя артиста:";
            // 
            // AddArtistForm
            // 
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.Control;
            ClientSize = new Size(284, 151);
            Controls.Add(lblName);
            Controls.Add(btnSave);
            Controls.Add(txtName);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            ImeMode = ImeMode.NoControl;
            MaximizeBox = false;
            Name = "AddArtistForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавить артиста";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
