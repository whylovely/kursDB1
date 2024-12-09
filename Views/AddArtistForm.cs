using Npgsql; 

namespace kursDB1.Views
{
    public partial class AddArtistForm : Form
    {
        public AddArtistForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = txtName.Text;

                string query = $"INSERT INTO artists (name) VALUES ('{Name}')";

                string connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Артист добавлен!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении артиста: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
