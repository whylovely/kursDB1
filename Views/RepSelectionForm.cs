using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Npgsql;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace kursDB1.Views
{
    public partial class ReportSelectionForm : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        public ReportSelectionForm()
        {
            InitializeComponent();
        }

        private void btnReportUserRating_Click(object sender, EventArgs e)
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

            GenerateAndSaveReport(query, "UserRatingReport.pdf", "Отчет по пользователям");
        }

        private void btnReportArt_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            art.name AS Название_произведения,
            genre.name AS Жанр,
            studio.name AS Студия,
            director.name AS Режиссёр,
            label.name AS Лейбл,
            artist.name AS Исполнитель,
            album.name AS Альбом,
            AVG(mark.mark) AS Средняя_оценка
        FROM 
            arts art
            JOIN genres genre ON art.id_genre = genre.id
            JOIN studios studio ON art.id_studio = studio.id
            JOIN directors director ON art.id_director = director.id
            JOIN labels label ON art.id_label = label.id
            JOIN artists artist ON art.id_artist = artist.id
            JOIN albums album ON art.id_album = album.id
            LEFT JOIN marks mark ON art.id = mark.id_art
        GROUP BY 
            art.id, genre.name, studio.name, director.name, label.name, artist.name, album.name";

            GenerateAndSaveReport(query, "ArtReport.pdf", "Отчет о произведениях");
        }

        private void btnReportGenre_Click(object sender, EventArgs e)
        {
            string query = @"
        SELECT 
            genre.name AS Жанр,
            COUNT(art.id) AS Количество_произведений,
            AVG(mark.mark) AS Средняя_оценка,
            MAX(art.name) AS Наиболее_популярное_произведение
        FROM 
            genres genre
            LEFT JOIN arts art ON art.id_genre = genre.id
            LEFT JOIN marks mark ON art.id = mark.id_art
        GROUP BY 
            genre.name";

            GenerateAndSaveReport(query, "GenreReport.pdf", "Отчет по жанрам");
        }

        private void GenerateAndSaveReport(string query, string fileName, string reportTitle)
        {
            try
            {
                DataTable reportData = GetDataFromDatabase(query);
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF файлы (*.pdf)|*.pdf";
                    saveFileDialog.FileName = fileName;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        GeneratePdfReport(reportData, saveFileDialog.FileName, reportTitle);
                        MessageBox.Show($"Отчет успешно сохранен: {saveFileDialog.FileName}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetDataFromDatabase(string query)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var adapter = new NpgsqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        private void GeneratePdfReport(DataTable data, string filePath, string reportTitle)
        {
            // Используем шрифт Arial
            BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10);
            iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

            // Создаем новый документ PDF
            using (iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4, 20f, 20f, 30f, 30f))
            {
                // Создаем поток для записи в файл PDF
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    // Вместо GetInstance используем новый конструктор
                    iText.Kernel.Pdf.PdfWriter writer = new iText.Kernel.Pdf.PdfWriter(fs);
                    doc.Open();

                    // Заголовок отчета
                    iTextSharp.text.Paragraph header = new iTextSharp.text.Paragraph(new Phrase(reportTitle, headerFont))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20f
                    };
                    doc.Add(header);

                    // Таблица
                    PdfPTable table = new PdfPTable(data.Columns.Count) { WidthPercentage = 100 };

                    // Заголовки таблицы
                    foreach (DataColumn column in data.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, font))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            BackgroundColor = BaseColor.LIGHT_GRAY
                        };
                        table.AddCell(cell);
                    }

                    // Данные таблицы
                    foreach (DataRow row in data.Rows)
                    {
                        foreach (var cellValue in row.ItemArray)
                        {
                            table.AddCell(new PdfPCell(new Phrase(cellValue?.ToString() ?? "", font)));
                        }
                    }

                    doc.Add(table);

                    // Дата генерации
                    iTextSharp.text.Paragraph footer = new iTextSharp.text.Paragraph(new Phrase($"Сгенерировано: {DateTime.Now:dd.MM.yyyy HH:mm}", font))
                    {
                        Alignment = Element.ALIGN_RIGHT,
                        SpacingBefore = 20f
                    };
                    doc.Add(footer);

                    doc.Close();
                }
            }
        }
    }
}
