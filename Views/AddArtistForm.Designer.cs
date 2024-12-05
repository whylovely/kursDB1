namespace kursDB1.Views
{
    partial class AddArtistForm
    {
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblName;

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(12, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(260, 23);
            this.txtName.TabIndex = 0;
            this.txtName.Text = "Имя артиста";

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(260, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(109, 15);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Имя артиста:";

            // 
            // AddArtistForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 151);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Name = "AddArtistForm";
            this.Text = "Добавить артиста";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
