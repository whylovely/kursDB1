namespace kursDB1.Views
{
    partial class AddAlbumForm
    {
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCountArts;
        private System.Windows.Forms.DateTimePicker dtpDropDay;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbArtists; // Новый ComboBox для выбора артиста

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtCountArts = new TextBox();
            dtpDropDay = new DateTimePicker();
            btnSave = new Button();
            cmbArtists = new ComboBox(); // Инициализация ComboBox

            SuspendLayout();

            // 
            // txtName
            // 
            txtName.Location = new Point(12, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 0;
            txtName.Text = "Название";

            // 
            // txtCountArts
            // 
            txtCountArts.Location = new Point(12, 41);
            txtCountArts.Name = "txtCountArts";
            txtCountArts.Size = new Size(200, 23);
            txtCountArts.TabIndex = 1;
            txtCountArts.Text = "Количество произведений";

            // 
            // dtpDropDay
            // 
            dtpDropDay.Location = new Point(12, 69);
            dtpDropDay.Name = "dtpDropDay";
            dtpDropDay.Size = new Size(200, 23);
            dtpDropDay.TabIndex = 2;

            // 
            // cmbArtists
            // 
            cmbArtists.DropDownStyle = ComboBoxStyle.DropDownList; // Устанавливаем выпадающий список
            cmbArtists.Location = new Point(12, 98);
            cmbArtists.Name = "cmbArtists";
            cmbArtists.Size = new Size(200, 23);
            cmbArtists.TabIndex = 3;

            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 127);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // 
            // AddAlbumForm
            // 
            ClientSize = new Size(232, 162);
            Controls.Add(txtName);
            Controls.Add(txtCountArts);
            Controls.Add(dtpDropDay);
            Controls.Add(cmbArtists); // Добавляем ComboBox в форму
            Controls.Add(btnSave);
            Name = "AddAlbumForm";
            Text = "Добавить Альбом";
            Load += AddAlbumForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
