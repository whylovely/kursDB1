using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Npgsql.Internal;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace kursDB1.Views
{
    public partial class ReportUserRatingForm : Form
    {
        private string currentUser = "Admin"; 
        private DataTable reportData;

        public ReportUserRatingForm()
        {
            InitializeComponent();
            reportData = GetReportData();
            DisplayReport(reportData);
        }

        private DataTable GetReportData()
        {
            string query = @"
                SELECT 
                    user_.id AS ID_пользователя,
                    user_.name AS ФИО,
                    user_.role_id AS Уровень_доступа,
                    AVG(mark.mark) AS Средняя_оценка,
                    COUNT(mark.id) AS Количество_оценок
                FROM 
                    users user_
                    LEFT JOIN marks mark ON user_.id = mark.id_user
                GROUP BY 
                    user_.id, user_.name, user_.role_id";

            return GetDataFromDatabase(query);
        }

        private DataTable GetDataFromDatabase(string query)
        {
            string connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var dataAdapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        private void DisplayReport(DataTable reportData)
        {
            // Заголовок отчета
            Label reportTitle = new Label
            {
                Text = "Отчёт о рейтинге пользователей", // Название отчета
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Height = 40
            };
            this.Controls.Add(reportTitle);

            // DataGridView для отображения данных отчета
            DataGridView dataGridView = new DataGridView
            {
                DataSource = reportData,
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            this.Controls.Add(dataGridView);

            // Дата генерации отчета
            Label reportDate = new Label
            {
                Text = "Дата генерации: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Dock = DockStyle.Bottom,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Height = 30
            };
            this.Controls.Add(reportDate);

            // Имя пользователя, который сгенерировал отчет
            Label reportUser = new Label
            {
                Text = "Пользователь: " + currentUser, // Имя пользователя
                Dock = DockStyle.Bottom,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Height = 30
            };
            this.Controls.Add(reportUser);

            // Кнопка для сохранения отчета в PDF
            Button btnSavePdf = new Button
            {
                Text = "Сохранить в PDF",
                Dock = DockStyle.Bottom,
                Height = 40
            }; 
            btnSavePdf.Click += new EventHandler(SaveReportAsPdf);
            this.Controls.Add(btnSavePdf);
        }

        private void SaveReportAsPdf(object sender, EventArgs e)
        {
            // Логика сохранения отчета в PDF
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            string filePath = @"C:\users\viner\desktop\ReportUserRating.pdf";// Путь к файлу, куда будет сохранен отчет
            PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

            document.Open();

            // Заголовок отчета
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD);
            Paragraph title = new Paragraph("Отчёт о рейтинге пользователей", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            document.Add(title);

            // Дата и пользователь
            iTextSharp.text.Font dateFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
            Paragraph date = new Paragraph($"Дата генерации: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}", dateFont);
            date.Alignment = Element.ALIGN_CENTER;
            document.Add(date);

            Paragraph user = new Paragraph($"Пользователь: {currentUser}", dateFont);
            user.Alignment = Element.ALIGN_CENTER;
            document.Add(user);

            // Добавляем таблицу с данными из DataTable
            PdfPTable table = new PdfPTable(reportData.Columns.Count);
            table.WidthPercentage = 100;

            // Добавляем заголовки столбцов
            foreach (DataColumn column in reportData.Columns)
            {
                table.AddCell(new Phrase(column.ColumnName));
            }

            // Добавляем строки данных
            foreach (DataRow row in reportData.Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    table.AddCell(cell.ToString());
                }
            }

            document.Add(table);

            // Закрываем документ
            document.Close();

            MessageBox.Show("Отчет успешно сохранен как PDF: " + filePath);
        }
    }
}
