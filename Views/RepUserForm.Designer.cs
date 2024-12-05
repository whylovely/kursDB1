namespace kursDB1.Views
{
    partial class ReportUserRatingForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnSavePdf;

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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnSavePdf = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Height = 40;
            this.lblTitle.Text = "Отчёт о рейтинге пользователей";

            // dataGridView
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 40); // Сдвигаем вниз после заголовка
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(800, 330); // Размер для DataGridView
            this.dataGridView.TabIndex = 0;

            // lblDate
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDate.Height = 30;
            this.lblDate.Text = "Дата генерации: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // lblUser
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUser.Height = 30;
            this.lblUser.Text = "Пользователь: Admin"; // Имя текущего пользователя можно задать динамически

            // btnSavePdf
            this.btnSavePdf.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSavePdf.Text = "Сохранить в PDF";
            this.btnSavePdf.Height = 40;
            btnSavePdf.Click += new EventHandler(SaveReportAsPdf);

            // ReportUserRatingForm
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSavePdf);
            this.Name = "ReportUserRatingForm";
            this.Text = "Отчёт о рейтинге пользователей";

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
