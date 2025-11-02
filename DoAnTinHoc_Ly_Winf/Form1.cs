using DoAnTinHoc_Ly_Winf;
using System;
using System.Collections.Generic;
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
            string filePath = "output.json";
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

            MessageBox.Show("Đã lưu dữ liệu thành công ra file output.json!");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAVLTree_Click(object sender, EventArgs e)
        {
            string filePath = "Reading Habbit Of Students.csv";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Không tìm thấy file CSV trong thư mục bin\\Debug!");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
            {
                MessageBox.Show("File CSV rỗng!");
                return;
            }

            string[] headers = lines[0].Split(',');
            DataTable dt = new DataTable();
            foreach (string header in headers)
                dt.Columns.Add(header.Trim());

            int keyColumnIndex = Array.FindIndex(headers, h =>
                h.Trim().Equals("Time to read a book", StringComparison.OrdinalIgnoreCase));

            if (keyColumnIndex == -1)
            {
                MessageBox.Show("Không tìm thấy cột 'Time to read a book' trong file CSV!");
                return;
            }
            AVLTree tree = new AVLTree();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

                
                if (values.Length <= keyColumnIndex) continue;

                string keyStr = values[keyColumnIndex].Trim();

                
                if (!int.TryParse(keyStr, out int key))
                {
                   
                }

                tree.Root = tree.Insert(tree.Root, key, values);
            }

            List<string[]> sorted = new List<string[]>();
            tree.InOrder(tree.Root, sorted);

            
            foreach (var row in sorted)
            {
                
                string[] values = row;
                object[] toAdd = new object[dt.Columns.Count];

                int copyLen = Math.Min(values.Length, dt.Columns.Count);
                for (int j = 0; j < copyLen; j++)
                    toAdd[j] = values[j];

                
                for (int j = copyLen; j < dt.Columns.Count; j++)
                    toAdd[j] = DBNull.Value;

                dt.Rows.Add(toAdd);
            }

            dataGridView1.DataSource = dt;
            MessageBox.Show("Đã đọc và sắp xếp cột 'Time to read a book' bằng AVL Tree!");
        }
    }
}

