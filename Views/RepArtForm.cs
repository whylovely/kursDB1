using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace kursDB1.Views
{
    public partial class ReportArtForm : Form
    {
        public ReportArtForm()
        {
            InitializeComponent();
            DataTable reportData = GetReportData();
            DisplayReport(reportData);
        }

        private DataTable GetReportData()
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
            DataGridView dataGridView = new DataGridView
            {
                DataSource = reportData,
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            this.Controls.Add(dataGridView);
        }
    }
}
