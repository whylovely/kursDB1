using Npgsql; 

namespace kursDB1.Views
{
    public partial class AddGenreForm : Form
    {
        public AddGenreForm()
        {
            InitializeComponent();
        }

        public AdminPanelForm AdminPanelForm
        {
            get => default;
            set
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = txtName.Text;

                string query = "INSERT INTO genres (name) VALUES (@Name)";

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

                MessageBox.Show("Жанр добавлен!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении жанра: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
