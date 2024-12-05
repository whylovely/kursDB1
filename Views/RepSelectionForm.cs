using System;
using System.Windows.Forms;

namespace kursDB1.Views
{
    public partial class ReportSelectionForm : Form
    {
        public ReportSelectionForm()
        {
            InitializeComponent();
        }

        private void btnReportArt_Click(object sender, EventArgs e)
        {
            // Генерация отчета о произведениях
            var reportForm = new ReportArtForm();
            reportForm.ShowDialog();
        }

        private void btnReportGenre_Click(object sender, EventArgs e)
        {
            // Генерация отчета по жанрам
            var reportForm = new ReportGenreForm();
            reportForm.ShowDialog();
        }

        private void btnReportUserRating_Click(object sender, EventArgs e)
        {
            // Генерация отчета о рейтинге пользователей
            var reportForm = new ReportUserRatingForm();
            reportForm.ShowDialog();
        }
    }
}
