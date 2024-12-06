namespace kursDB1.Views
{
    partial class UserPanelForm
    {
        private System.ComponentModel.IContainer components = null;

        //private System.Windows.Forms.DataGridView dgvArts;
        private System.Windows.Forms.Button btnRateArt;
        private System.Windows.Forms.Button btnViewMusic;
        private System.Windows.Forms.Button btnViewMovies;

        /// <summary>
        /// Освобождение ресурсов.
        /// </summary>
        /// <param name="disposing">True, если управляемые ресурсы должны быть освобождены, иначе False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный дизайнером форм Windows

        /// <summary>
        /// Метод инициализации компонентов формы.
        /// </summary>
        private void InitializeComponent()
        {
            dgvArts = new DataGridView();
            btnRateArt = new Button();
            btnViewMusic = new Button();
            btnViewMovies = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvArts).BeginInit();
            SuspendLayout();
            // 
            // dgvArts
            // 
            dgvArts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArts.Dock = DockStyle.Top;
            dgvArts.Location = new Point(450, 0);
            dgvArts.Name = "dgvArts";
            dgvArts.ReadOnly = true;
            dgvArts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArts.Size = new Size(869, 115);
            dgvArts.TabIndex = 0;
            dgvArts.CellContentClick += dgvArts_CellContentClick;
            // 
            // btnRateArt
            // 
            btnRateArt.Dock = DockStyle.Left;
            btnRateArt.Location = new Point(300, 0);
            btnRateArt.Name = "btnRateArt";
            btnRateArt.Size = new Size(150, 115);
            btnRateArt.TabIndex = 1;
            btnRateArt.Text = "Оценить произведение";
            btnRateArt.Click += btnRateArt_Click;
            // 
            // btnViewMusic
            // 
            btnViewMusic.Dock = DockStyle.Left;
            btnViewMusic.Location = new Point(150, 0);
            btnViewMusic.Name = "btnViewMusic";
            btnViewMusic.Size = new Size(150, 115);
            btnViewMusic.TabIndex = 2;
            btnViewMusic.Text = "Посмотреть музыку";
            btnViewMusic.Click += btnViewMusic_Click;
            // 
            // btnViewMovies
            // 
            btnViewMovies.Dock = DockStyle.Left;
            btnViewMovies.Location = new Point(0, 0);
            btnViewMovies.Name = "btnViewMovies";
            btnViewMovies.Size = new Size(150, 115);
            btnViewMovies.TabIndex = 3;
            btnViewMovies.Text = "Посмотреть фильмы";
            btnViewMovies.Click += btnViewMovies_Click;
            // 
            // UserPanelForm
            // 
            ClientSize = new Size(1319, 115);
            Controls.Add(dgvArts);
            Controls.Add(btnRateArt);
            Controls.Add(btnViewMusic);
            Controls.Add(btnViewMovies);
            Name = "UserPanelForm";
            Text = "Панель пользователя";
            Load += UserPanelForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvArts).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}
