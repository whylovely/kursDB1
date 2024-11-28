using kursDB1.Controllers;
using kursDB1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursDB1.Views
{
    public partial class AddArtForm : Form
    {
        private readonly AdminController _adminController;

        public AddArtForm()
        {
            InitializeComponent();
            _adminController = new AdminController();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем экземпляр произведения
                var art = new Art
                {
                    Name = txtName.Text,
                    Duration = int.Parse(txtDuration.Text),
                    GenreId = int.Parse(cmbGenres.SelectedValue.ToString()),
                    // Дополните остальные поля, если необходимо
                };

                // Добавляем произведение через контроллер
                _adminController.AddArt(art);

                // Уведомляем пользователя
                MessageBox.Show("Произведение успешно добавлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Закрываем форму
                this.Close();
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Ошибка при добавлении произведения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}