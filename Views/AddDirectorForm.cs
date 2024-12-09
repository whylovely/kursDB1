using Npgsql; 

namespace kursDB1.Views
{
    public partial class AddDirectorForm : Form
    {
        public AddDirectorForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string directorName = txtName.Text;

                string query = $"INSERT INTO directors (name) VALUES ('{directorName}')";

                string connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", directorName);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Режиссер добавлен!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении режиссера: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
