namespace kursDB1.Views
{
    partial class UserPanelForm
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            this.listBoxArts = new System.Windows.Forms.ListBox();
            this.btnRateArt = new System.Windows.Forms.Button();
            this.numericUpDownMark = new System.Windows.Forms.NumericUpDown();
            // Другие компоненты и их инициализация
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMark)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxArts
            // 
            this.listBoxArts.FormattingEnabled = true;
            this.listBoxArts.Location = new System.Drawing.Point(12, 12);
            this.listBoxArts.Name = "listBoxArts";
            this.listBoxArts.Size = new System.Drawing.Size(200, 95);
            this.listBoxArts.TabIndex = 0;
            // 
            // btnRateArt
            // 
            this.btnRateArt.Location = new System.Drawing.Point(12, 120);
            this.btnRateArt.Name = "btnRateArt";
            this.btnRateArt.Size = new System.Drawing.Size(75, 23);
            this.btnRateArt.TabIndex = 1;
            this.btnRateArt.Text = "Оценить";
            this.btnRateArt.UseVisualStyleBackColor = true;
            this.btnRateArt.Click += new System.EventHandler(this.btnRateArt_Click);
            // 
            // numericUpDownMark
            // 
            this.numericUpDownMark.Location = new System.Drawing.Point(93, 120);
            this.numericUpDownMark.Name = "numericUpDownMark";
            this.numericUpDownMark.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMark.TabIndex = 2;
            // 
            // UserPanelForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.numericUpDownMark);
            this.Controls.Add(this.btnRateArt);
            this.Controls.Add(this.listBoxArts);
            this.Name = "UserPanelForm";
            this.Load += new System.EventHandler(this.UserPanelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMark)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox listBoxArts;
        private System.Windows.Forms.Button btnRateArt;
        private System.Windows.Forms.NumericUpDown numericUpDownMark;
    }
}
