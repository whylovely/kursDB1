namespace kursDB1.Views
{
    partial class ReportSelectionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnReportArt;
        private System.Windows.Forms.Button btnReportGenre;
        private System.Windows.Forms.Button btnReportUserRating;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnReportArt = new Button();
            btnReportGenre = new Button();
            btnReportUserRating = new Button();
            SuspendLayout();
            // 
            // btnReportArt
            // 
            btnReportArt.Location = new Point(12, 22);
            btnReportArt.Name = "btnReportArt";
            btnReportArt.Size = new Size(200, 40);
            btnReportArt.TabIndex = 0;
            btnReportArt.Text = "Отчёт о произведениях";
            btnReportArt.UseVisualStyleBackColor = true;
            btnReportArt.Click += btnReportArt_Click;
            // 
            // btnReportGenre
            // 
            btnReportGenre.Location = new Point(12, 72);
            btnReportGenre.Name = "btnReportGenre";
            btnReportGenre.Size = new Size(200, 40);
            btnReportGenre.TabIndex = 1;
            btnReportGenre.Text = "Отчёт по жанрам";
            btnReportGenre.UseVisualStyleBackColor = true;
            btnReportGenre.Click += btnReportGenre_Click;
            // 
            // btnReportUserRating
            // 
            btnReportUserRating.Location = new Point(12, 122);
            btnReportUserRating.Name = "btnReportUserRating";
            btnReportUserRating.Size = new Size(200, 40);
            btnReportUserRating.TabIndex = 2;
            btnReportUserRating.Text = "Отчёт о рейтинге пользователей";
            btnReportUserRating.UseVisualStyleBackColor = true;
            btnReportUserRating.Click += btnReportUserRating_Click;
            // 
            // ReportSelectionForm
            // 
            ClientSize = new Size(224, 183);
            Controls.Add(btnReportUserRating);
            Controls.Add(btnReportGenre);
            Controls.Add(btnReportArt);
            Name = "ReportSelectionForm";
            Text = "Выбор отчёта";
            ResumeLayout(false);
        }
    }
}
