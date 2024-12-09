using System;
using System.Windows.Forms;
using Npgsql; // Для работы с PostgreSQL

namespace kursDB1.Views
{
    public partial class AddStudioForm : Form
    {
        public AddStudioForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из формы
                string name = txtName.Text.Trim();
                DateTime bDay = dtpBDay.Value;
                string connectionString = "Host=localhost;Port=5433;Username=postgres;Password=2005;Database=db1;Include Error Detail=true";

                // Проверяем, не существует ли студия с таким именем
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM studios WHERE name = @Name";
                    using (var checkCommand = new NpgsqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Name", name);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Студия с таким именем уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // SQL-запрос для добавления студии
                    string query = "INSERT INTO studios (name, b_day) VALUES (@Name, @BDay)";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@BDay", NpgsqlTypes.NpgsqlDbType.Date, bDay);

                        // Выполняем команду
                        command.ExecuteNonQuery();
                    }
                }

                // Уведомляем пользователя о успешном добавлении студии
                MessageBox.Show("Студия успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Ошибка при добавлении студии: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}