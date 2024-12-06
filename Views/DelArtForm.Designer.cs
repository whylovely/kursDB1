namespace kursDB1.Views
{
    partial class DeleteArtForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvArts;
        private Button btnDelete;
        private Button btnCancel;

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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArts
            // 
            this.dgvArts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArts.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvArts.Location = new System.Drawing.Point(0, 0);
            this.dgvArts.Name = "dgvArts";
            this.dgvArts.ReadOnly = true;
            this.dgvArts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvArts.Size = new System.Drawing.Size(484, 300);
            this.dgvArts.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(80, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 30);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(280, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SelectArtToDeleteForm
            // 
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvArts);
            this.Name = "SelectArtToDeleteForm";
            this.Text = "Выберите произведение";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArts)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
