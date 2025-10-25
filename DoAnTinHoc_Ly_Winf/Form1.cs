using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CsvReaderWriter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            string filePath = "Reading Habbit Of Students.csv";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Không tìm thấy file CSV trong thư mục bin\\Debug!");
                return;
            }

            DataTable dt = new DataTable();
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length > 0)
            {
                string[] headers = lines[0].Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header.Trim());
                }
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] values = lines[i].Split(',');
                    while (values.Length < dt.Columns.Count)
                    {
                        Array.Resize(ref values, dt.Columns.Count);
                    }
                    if (values.Length > dt.Columns.Count)
                    {
                        Array.Resize(ref values, dt.Columns.Count);
                    }

                    dt.Rows.Add(values);
                }

                dataGridView1.DataSource = dt;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string filePath = "output.txt"; 
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    sw.Write(dataGridView1.Columns[i].HeaderText);
                    if (i < dataGridView1.Columns.Count - 1)
                        sw.Write("\t");
                }
                sw.WriteLine();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            sw.Write(row.Cells[i].Value);
                            if (i < row.Cells.Count - 1)
                                sw.Write("\t");
                        }
                        sw.WriteLine();
                    }
                }
            }

            MessageBox.Show("Đã lưu dữ liệu thành công ra file output.txt!");
        }
    }
}
