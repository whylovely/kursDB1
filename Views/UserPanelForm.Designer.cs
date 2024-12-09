namespace kursDB1.Views
{
    partial class UserPanelForm
    {
        /// <summary>
        /// Объявление компонентов формы.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnViewMusic;
        private System.Windows.Forms.Button btnViewMovies;

        /// <summary>
        /// Освобождение ресурсов.
        /// </summary>
        /// <param name="disposing">true, если управляемые ресурсы должны быть освобождены; иначе false.</param>
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
            this.btnViewMusic = new System.Windows.Forms.Button();
            this.btnViewMovies = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArts)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvArts
            // 
            this.dgvArts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArts.Location = new System.Drawing.Point(12, 12);
            this.dgvArts.Name = "dgvArts";
            this.dgvArts.Size = new System.Drawing.Size(760, 400);
            this.dgvArts.TabIndex = 0;
            this.dgvArts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArts_CellContentClick);

            // 
            // btnViewMusic
            // 
            this.btnViewMusic.Location = new System.Drawing.Point(12, 420);
            this.btnViewMusic.Name = "btnViewMusic";
            this.btnViewMusic.Size = new System.Drawing.Size(100, 30);
            this.btnViewMusic.TabIndex = 1;
            this.btnViewMusic.Text = "Музыка";
            this.btnViewMusic.UseVisualStyleBackColor = true;
            this.btnViewMusic.Click += new System.EventHandler(this.btnViewMusic_Click);

            // 
            // btnViewMovies
            // 
            this.btnViewMovies.Location = new System.Drawing.Point(118, 420);
            this.btnViewMovies.Name = "btnViewMovies";
            this.btnViewMovies.Size = new System.Drawing.Size(100, 30);
            this.btnViewMovies.TabIndex = 2;
            this.btnViewMovies.Text = "Фильмы";
            this.btnViewMovies.UseVisualStyleBackColor = true;
            this.btnViewMovies.Click += new System.EventHandler(this.btnViewMovies_Click);

            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(224, 420);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 30);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "Вернуться";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);

            // 
            // UserPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnViewMovies);
            this.Controls.Add(this.btnViewMusic);
            this.Controls.Add(this.dgvArts);
            this.Name = "UserPanelForm";
            this.Text = "Панель пользователя";
            this.Load += new System.EventHandler(this.UserPanelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArts)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
