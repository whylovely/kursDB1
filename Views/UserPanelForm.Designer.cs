namespace kursDB1.Views
{
    partial class UserPanelForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnRateArt;
        private System.Windows.Forms.Button btnViewMusic;
        private System.Windows.Forms.Button btnViewMovies;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемые ресурсы должны быть удалены; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Инициализация компонентов формы.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvArts = new System.Windows.Forms.DataGridView();
            this.btnRateArt = new System.Windows.Forms.Button();
            this.btnViewMusic = new System.Windows.Forms.Button();
            this.btnViewMovies = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvArts)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvArts
            // 
            this.dgvArts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArts.Location = new System.Drawing.Point(20, 20);
            this.dgvArts.Name = "dgvArts";
            this.dgvArts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArts.Size = new System.Drawing.Size(760, 200);
            this.dgvArts.TabIndex = 0;

            // 
            // btnRateArt
            // 
            this.btnRateArt.Location = new System.Drawing.Point(20, 240);
            this.btnRateArt.Name = "btnRateArt";
            this.btnRateArt.Size = new System.Drawing.Size(200, 40);
            this.btnRateArt.TabIndex = 1;
            this.btnRateArt.Text = "Оценить произведение";
            this.btnRateArt.UseVisualStyleBackColor = true;
            this.btnRateArt.Click += new System.EventHandler(this.btnRateArt_Click);

            // 
            // btnViewMusic
            // 
            this.btnViewMusic.Location = new System.Drawing.Point(240, 240);
            this.btnViewMusic.Name = "btnViewMusic";
            this.btnViewMusic.Size = new System.Drawing.Size(200, 40);
            this.btnViewMusic.TabIndex = 2;
            this.btnViewMusic.Text = "Просмотреть музыку";
            this.btnViewMusic.UseVisualStyleBackColor = true;
            this.btnViewMusic.Click += new System.EventHandler(this.btnViewMusic_Click);

            // 
            // btnViewMovies
            // 
            this.btnViewMovies.Location = new System.Drawing.Point(460, 240);
            this.btnViewMovies.Name = "btnViewMovies";
            this.btnViewMovies.Size = new System.Drawing.Size(200, 40);
            this.btnViewMovies.TabIndex = 3;
            this.btnViewMovies.Text = "Просмотреть фильмы";
            this.btnViewMovies.UseVisualStyleBackColor = true;
            this.btnViewMovies.Click += new System.EventHandler(this.btnViewMovies_Click);

            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(680, 240);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 40);
            this.btnReturn.TabIndex = 4;
            this.btnReturn.Text = "Вернуться";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);

            // 
            // UserPanelForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 300);
            this.Controls.Add(this.dgvArts);
            this.Controls.Add(this.btnRateArt);
            this.Controls.Add(this.btnViewMusic);
            this.Controls.Add(this.btnViewMovies);
            this.Controls.Add(this.btnReturn);
            this.Name = "UserPanelForm";
            this.Text = "Панель пользователя";
            this.Load += new System.EventHandler(this.UserPanelForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvArts)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
