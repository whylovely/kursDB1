namespace kursDB1.Views
{
    partial class ReportSelectionForm
    {
        private System.ComponentModel.IContainer components = null;

        // Кнопки для формы
        private System.Windows.Forms.Button btnReportUserRating;
        private System.Windows.Forms.Button btnReportArt;
        private System.Windows.Forms.Button btnReportGenre;

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
            this.btnReportUserRating = new System.Windows.Forms.Button();
            this.btnReportArt = new System.Windows.Forms.Button();
            this.btnReportGenre = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // btnReportUserRating
            // 
            this.btnReportUserRating.Location = new System.Drawing.Point(50, 30);
            this.btnReportUserRating.Name = "btnReportUserRating";
            this.btnReportUserRating.Size = new System.Drawing.Size(200, 40);
            this.btnReportUserRating.TabIndex = 0;
            this.btnReportUserRating.Text = "Отчет по пользователям";
            this.btnReportUserRating.UseVisualStyleBackColor = true;
            this.btnReportUserRating.Click += new System.EventHandler(this.btnReportUserRating_Click);

            // 
            // btnReportArt
            // 
            this.btnReportArt.Location = new System.Drawing.Point(50, 90);
            this.btnReportArt.Name = "btnReportArt";
            this.btnReportArt.Size = new System.Drawing.Size(200, 40);
            this.btnReportArt.TabIndex = 1;
            this.btnReportArt.Text = "Отчет о произведениях";
            this.btnReportArt.UseVisualStyleBackColor = true;
            this.btnReportArt.Click += new System.EventHandler(this.btnReportArt_Click);

            // 
            // btnReportGenre
            // 
            this.btnReportGenre.Location = new System.Drawing.Point(50, 150);
            this.btnReportGenre.Name = "btnReportGenre";
            this.btnReportGenre.Size = new System.Drawing.Size(200, 40);
            this.btnReportGenre.TabIndex = 2;
            this.btnReportGenre.Text = "Отчет по жанрам";
            this.btnReportGenre.UseVisualStyleBackColor = true;
            this.btnReportGenre.Click += new System.EventHandler(this.btnReportGenre_Click);

            // 
            // ReportSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 230);
            this.Controls.Add(this.btnReportUserRating);
            this.Controls.Add(this.btnReportArt);
            this.Controls.Add(this.btnReportGenre);
            this.Name = "ReportSelectionForm";
            this.Text = "Генерация отчетов";
            this.ResumeLayout(false);
        }
    }
}
