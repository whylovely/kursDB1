using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace kursDB1.Views
{
    public partial class ReportGenreForm : Form
    {
        public ReportGenreForm()
        {
            InitializeComponent();
            DataTable reportData = GetReportData();
            DisplayReport(reportData);
        }

        private DataTable GetReportData()
        {
            string query = @"
                SELECT 
                    genres.name AS Жанр,
                    COUNT(arts.id) AS Количество_произведений,
                    AVG(marks.mark) AS Средняя_оценка,
                    MAX(arts.name) AS Наиболее_популярное_произведение
                FROM 
                    genres genre
                    LEFT JOIN arts art ON arts.id_genre = genres.id
                    LEFT JOIN marks mark ON arts.id = marks.id_art
                GROUP BY 
                    genres.name";

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
