using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace kursDB1.Views
{
    public partial class RateArtForm : Form
    {
        private readonly int _artId;
        private readonly int _userId;

        private const string ConnectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

        public RateArtForm(int artId, int userId)
        {
            InitializeComponent();
            _artId = artId;
            _userId = userId;
        }

        private void btnSubmitRating_Click(object sender, EventArgs e)
        {
            int mark = (int)numericUpDownMark.Value;

            try
            {
                using (var connection = new Npgsql.NpgsqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = @"
                        INSERT INTO marks (id_user, id_art, mark) 
                        VALUES (@userId, @artId, @mark)
                        ON CONFLICT (id_user, id_art) 
                        DO UPDATE SET mark = EXCLUDED.mark";

                    using (var command = new Npgsql.NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", _userId);
                        command.Parameters.AddWithValue("@artId", _artId);
                        command.Parameters.AddWithValue("@mark", mark);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Оценка успешно сохранена.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения оценки: {ex.Message}");
            }
        }
    }
}
