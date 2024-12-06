namespace kursDB1.Views
{
    partial class EditArtForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Button btnSave;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">true, если управляемые ресурсы должны быть удалены; иначе — false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Инициализация компонентов.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            lblDescription = new Label();
            txtName = new TextBox();
            txtDuration = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(74, 20);
            lblName.Name = "lblName";
            lblName.Size = new Size(62, 15);
            lblName.TabIndex = 0;
            lblName.Text = "Название:";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 44);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(124, 15);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Продолжительность:";
            // 
            // txtName
            // 
            txtName.Location = new Point(142, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 1;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtDuration
            // 
            txtDuration.Location = new Point(142, 41);
            txtDuration.Multiline = true;
            txtDuration.Name = "txtDuration";
            txtDuration.Size = new Size(200, 24);
            txtDuration.TabIndex = 3;
            txtDuration.TextChanged += txtDuration_TextChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(252, 71);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 6;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // EditArtForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(357, 115);
            Controls.Add(btnSave);
            Controls.Add(txtDuration);
            Controls.Add(lblDescription);
            Controls.Add(txtName);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditArtForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редактирование записи";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
