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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(12, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1040, 380);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(12, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(100, 30);
            this.btnRead.TabIndex = 1;
            this.btnRead.Text = "Đọc file CSV";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(130, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu TXT";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Số lượng sách mua",
            "Thời gian đọc 1 quyển sách"});
            this.comboBox1.Location = new System.Drawing.Point(325, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "AVL Tree";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Chiều cao cây",
            "Đếm node lá",
            "Giá trị nhỏ nhất",
            "Giá trị lớn nhất",
            "Tìm giá trị X (người dùng nhập)"});
            this.comboBox2.Location = new System.Drawing.Point(543, 18);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(467, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Thuật toán";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(697, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Chọn số dòng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(824, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "Chọn số tầng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1064, 461);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Đọc và lưu file CSV";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
