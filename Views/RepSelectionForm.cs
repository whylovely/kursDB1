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

namespace kursDB1.Views
{
    public partial class ReportSelectionForm : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        public ReportSelectionForm()
        {
            InitializeComponent();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        private void btnReportUserRating_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
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

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        using (SaveFileDialog sfd = new SaveFileDialog())
                        {
                            sfd.Filter = "PDF файлы (*.pdf)|*.pdf";
                            sfd.FileName = $"Отчет_по_пользователям_{DateTime.Now:yyyy-MM-dd}.pdf";

                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                using (iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4, 20f, 20f, 30f, 30f))
                                {
                                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                                    doc.Open();

                                    // Заголовок отчета
                                    BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12);
                                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

                                    iTextSharp.text.Paragraph header = new iTextSharp.text.Paragraph(new Phrase("Отчет по пользователям", headerFont));
                                    header.Alignment = Element.ALIGN_CENTER;
                                    header.SpacingAfter = 20f;
                                    doc.Add(header);

                                    // Создаем таблицу
                                    PdfPTable table = new PdfPTable(5); // 5 столбцов для вашего отчета
                                    table.WidthPercentage = 100;

                                    // Заголовки столбцов
                                    string[] headers = { "ID пользователя", "ФИО", "Уровень доступа", "Средняя оценка", "Количество оценок" };
                                    foreach (string columnHeader in headers)
                                    {
                                        PdfPCell cell = new PdfPCell(new Phrase(columnHeader, font));
                                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                                        table.AddCell(cell);
                                    }

                                    // Добавляем данные
                                    while (reader.Read())
                                    {
                                        table.AddCell(new PdfPCell(new Phrase(reader["ID_пользователя"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["ФИО"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Уровень_доступа"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Средняя_оценка"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Количество_оценок"].ToString(), font)));
                                    }

                                    doc.Add(table);

                                    // Добавляем дату генерации отчета
                                    iTextSharp.text.Paragraph footer = new iTextSharp.text.Paragraph(new Phrase($"\nОтчет сгенерирован: {DateTime.Now:dd.MM.yyyy HH:mm:ss}", font));
                                    footer.Alignment = Element.ALIGN_RIGHT;
                                    doc.Add(footer);

                                    doc.Close();
                                    MessageBox.Show("Отчет успешно сгенерирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при генерации отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReportArt_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
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

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        using (SaveFileDialog sfd = new SaveFileDialog())
                        {
                            sfd.Filter = "PDF файлы (*.pdf)|*.pdf";
                            sfd.FileName = $"Отчет_о_произведениях_{DateTime.Now:yyyy-MM-dd}.pdf";

                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                using (iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4, 20f, 20f, 30f, 30f))
                                {
                                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                                    doc.Open();

                                    // Заголовок отчета
                                    BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12);
                                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

                                    iTextSharp.text.Paragraph header = new iTextSharp.text.Paragraph(new Phrase("Отчет о произведениях", headerFont));
                                    header.Alignment = Element.ALIGN_CENTER;
                                    header.SpacingAfter = 20f;
                                    doc.Add(header);

                                    // Создаем таблицу
                                    PdfPTable table = new PdfPTable(8); // 8 столбцов для вашего отчета
                                    table.WidthPercentage = 100;

                                    // Заголовки столбцов
                                    string[] headers = { "Название произведения", "Жанр", "Студия", "Режиссёр", "Лейбл", "Исполнитель", "Альбом", "Средняя оценка" };
                                    foreach (string columnHeader in headers)
                                    {
                                        PdfPCell cell = new PdfPCell(new Phrase(columnHeader, font));
                                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                                        table.AddCell(cell);
                                    }

                                    // Добавляем данные
                                    while (reader.Read())
                                    {
                                        table.AddCell(new PdfPCell(new Phrase(reader["Название_произведения"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Жанр"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Студия"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Режиссёр"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Лейбл"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Исполнитель"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Альбом"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Средняя_оценка"].ToString(), font)));
                                    }

                                    doc.Add(table);

                                    // Добавляем дату генерации отчета
                                    iTextSharp.text.Paragraph footer = new iTextSharp.text.Paragraph(new Phrase($"\nОтчет сгенерирован: {DateTime.Now:dd.MM.yyyy HH:mm:ss}", font));
                                    footer.Alignment = Element.ALIGN_RIGHT;
                                    doc.Add(footer);

                                    doc.Close();
                                    MessageBox.Show("Отчет успешно сгенерирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при генерации отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReportGenre_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
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

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        using (SaveFileDialog sfd = new SaveFileDialog())
                        {
                            sfd.Filter = "PDF файлы (*.pdf)|*.pdf";
                            sfd.FileName = $"Отчет_по_жанрам_{DateTime.Now:yyyy-MM-dd}.pdf";

                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                using (iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4, 20f, 20f, 30f, 30f))
                                {
                                    iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                                    doc.Open();

                                    // Заголовок отчета
                                    BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                                    iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12);
                                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD);

                                    iTextSharp.text.Paragraph header = new iTextSharp.text.Paragraph(new Phrase("Отчет по жанрам", headerFont));
                                    header.Alignment = Element.ALIGN_CENTER;
                                    header.SpacingAfter = 20f;
                                    doc.Add(header);

                                    // Создаем таблицу
                                    PdfPTable table = new PdfPTable(4); // 4 столбца для вашего отчета
                                    table.WidthPercentage = 100;

                                    // Заголовки столбцов
                                    string[] headers = { "Жанр", "Количество произведений", "Средняя оценка", "Наиболее популярное произведение" };
                                    foreach (string columnHeader in headers)
                                    {
                                        PdfPCell cell = new PdfPCell(new Phrase(columnHeader, font));
                                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                                        table.AddCell(cell);
                                    }

                                    // Добавляем данные
                                    while (reader.Read())
                                    {
                                        table.AddCell(new PdfPCell(new Phrase(reader["Жанр"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Количество_произведений"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Средняя_оценка"].ToString(), font)));
                                        table.AddCell(new PdfPCell(new Phrase(reader["Наиболее_популярное_произведение"].ToString(), font)));
                                    }

                                    doc.Add(table);

                                    // Добавляем дату генерации отчета
                                    iTextSharp.text.Paragraph footer = new iTextSharp.text.Paragraph(new Phrase($"\nОтчет сгенерирован: {DateTime.Now:dd.MM.yyyy HH:mm:ss}", font));
                                    footer.Alignment = Element.ALIGN_RIGHT;
                                    doc.Add(footer);

                                    doc.Close();
                                    MessageBox.Show("Отчет успешно сгенерирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при генерации отчета: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}