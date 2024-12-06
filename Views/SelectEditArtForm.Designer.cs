namespace kursDB1.Views
{
    partial class SelectArtForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvArts;
        private System.Windows.Forms.Button btnSelect;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvArts = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArts
            // 
            this.dgvArts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArts.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvArts.Location = new System.Drawing.Point(0, 0);
            this.dgvArts.Name = "dgvArts";
            this.dgvArts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArts.Size = new System.Drawing.Size(800, 300);
            this.dgvArts.TabIndex = 0;
            // 
            // btnSelect
            // 
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSelect.Location = new System.Drawing.Point(0, 310);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(800, 40);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Выбрать";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // SelectArtForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 350);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.dgvArts);
            this.Name = "SelectArtForm";
            this.Text = "Выбор произведения";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArts)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
