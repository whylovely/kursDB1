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
                    arts.name AS Название_произведения,
                    genres.name AS Жанр,
                    studio.name AS Студия,
                    directors.name AS Режиссёр,
                    labels.name AS Лейбл,
                    artists.name AS Исполнитель,
                    albums.name AS Альбом,
                    AVG(marks.mark) AS Средняя_оценка
                FROM 
                    arts art
                    JOIN genres genre ON arts.id_genre = genres.id
                    JOIN studios studio ON arts.id_studio = studios.id
                    JOIN directors director ON arts.id_director = directors.id
                    JOIN labels label ON arts.id_label = labels.id
                    JOIN artists artist ON arts.id_artist = artists.id
                    JOIN albums album ON arts.id_album = albums.id
                    LEFT JOIN marks mark ON arts.id = marks.id_art
                GROUP BY 
                    arts.id, genres.name, studios.name, directors.name, labels.name, artists.name, albums.name";

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
