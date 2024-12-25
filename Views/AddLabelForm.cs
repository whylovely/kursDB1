using Npgsql; 

namespace kursDB1.Views
{
    public partial class AddLabelForm : Form
    {
        public AddLabelForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string labelName = txtName.Text;
                DateTime BDate = dtpBDate.Value;
                string formattedBDay = BDate.ToString("yyyy-MM-dd");

                string query = "INSERT INTO labels (name, b_date) VALUES (@Name, @BDate)";

                string connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1";

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", labelName);
                        command.Parameters.AddWithValue("@BDate", BDate);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Лейбл добавлен!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении лейбла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
