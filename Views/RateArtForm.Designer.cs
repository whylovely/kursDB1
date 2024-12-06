namespace kursDB1.Views
{
    partial class RateArtForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NumericUpDown numericUpDownMark;
        private System.Windows.Forms.Button btnSubmitRating;

        private void InitializeComponent()
        {
            this.numericUpDownMark = new System.Windows.Forms.NumericUpDown();
            this.btnSubmitRating = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMark)).BeginInit();
            this.SuspendLayout();

            // numericUpDownMark
            this.numericUpDownMark.Location = new System.Drawing.Point(12, 12);
            this.numericUpDownMark.Minimum = 1;
            this.numericUpDownMark.Maximum = 10;
            this.numericUpDownMark.Size = new System.Drawing.Size(120, 20);

            // btnSubmitRating
            this.btnSubmitRating.Location = new System.Drawing.Point(12, 50);
            this.btnSubmitRating.Text = "Оценить";
            this.btnSubmitRating.Click += new System.EventHandler(this.btnSubmitRating_Click);

            // RateArtForm
            this.ClientSize = new System.Drawing.Size(200, 100);
            this.Controls.Add(this.numericUpDownMark);
            this.Controls.Add(this.btnSubmitRating);
            this.Text = "Оценка произведения";

            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMark)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
