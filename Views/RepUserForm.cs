using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace kursDB1.Views
{
    public partial class ReportUserRatingForm : Form
    {
        public ReportUserRatingForm()
        {
            InitializeComponent();
            DataTable reportData = GetReportData();
            DisplayReport(reportData);
        }

        private DataTable GetReportData()
        {
            string query = @"
                SELECT 
                    users.id AS ID_пользователя,
                    users.name AS ФИО,
                    users.role_id AS Уровень_доступа,
                    AVG(marks.mark) AS Средняя_оценка,
                    COUNT(marks.id) AS Количество_оценок
                FROM 
                    users user
                    LEFT JOIN marks mark ON users.id = marks.id_user
                GROUP BY 
                    users.id, users.name, users.role_id";

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
