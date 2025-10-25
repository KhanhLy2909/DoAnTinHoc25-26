namespace CsvReaderWriter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnSave;

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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.Location = new System.Drawing.Point(12, 60);
            this.dataGridView1.Size = new System.Drawing.Size(760, 380);
            this.dataGridView1.TabIndex = 0;
            this.btnRead.Location = new System.Drawing.Point(12, 12);
            this.btnRead.Size = new System.Drawing.Size(100, 30);
            this.btnRead.Text = "Đọc file CSV";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            this.btnSave.Location = new System.Drawing.Point(130, 12);
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.Text = "Lưu TXT";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.dataGridView1);
            this.Text = "Đọc và lưu file CSV";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
