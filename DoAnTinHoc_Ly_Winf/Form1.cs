using DoAnTinHoc_Ly_Winf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Linq;


namespace CsvReaderWriter
{
    public partial class Form1 : Form
    {
        AVLTree tree = new AVLTree();
        private List<string[]> TopRows = new List<string[]>();
        private string[] Headers;
        public Form1()
        {
            InitializeComponent();
        }
        private List<AVLNode> GetNodesAtLevel(AVLNode root, int level)
        {
            List<AVLNode> result = new List<AVLNode>();
            if (root == null || level < 0) return result;

            Queue<(AVLNode node, int lvl)> q = new Queue<(AVLNode, int)>();
            q.Enqueue((root, 0));

            while (q.Count > 0)
            {
                var (node, lvl) = q.Dequeue();
                if (lvl == level) result.Add(node);
                if (lvl < level)
                {
                    if (node.Left != null) q.Enqueue((node.Left, lvl + 1));
                    if (node.Right != null) q.Enqueue((node.Right, lvl + 1));
                }
            }
            return result;
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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


            string selectedOption = comboBox1.SelectedItem.ToString();
            string columnName = "";

            if (selectedOption == "Số lượng sách mua")
                columnName = "number of books purchased";
            else if (selectedOption == "Thời gian đọc 1 quyển sách")
                columnName = "Time to read a book";

            int keyColumnIndex = Array.FindIndex(headers, h =>
                h.Trim().Equals(columnName, StringComparison.OrdinalIgnoreCase));

            if (keyColumnIndex == -1)
            {
                MessageBox.Show($"Không tìm thấy cột '{columnName}' trong file CSV!");
                return;
            }
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

                if (values.Length <= keyColumnIndex) continue;

                string keyStr = values[keyColumnIndex].Trim();

                if (!int.TryParse(keyStr, out int key))
                    continue;

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
            MessageBox.Show($"Đã đọc và sắp xếp cột '{columnName}' bằng AVL Tree!");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAlgorithm = comboBox2.SelectedItem.ToString();
            string dataType = comboBox1.SelectedItem?.ToString();

            if (dataType == null)
            {
                MessageBox.Show("Vui lòng chọn kiểu dữ liệu ở ComboBox1 trước!");
                return;
            }

            switch (selectedAlgorithm)
            {
                case "Chiều cao cây":
                    MessageBox.Show($"Chiều cao của cây ({dataType}) là: " + tree.GetHeight());
                    break;

                case "Đếm node lá":
                    MessageBox.Show($"Số node lá ({dataType}) là: " + tree.CountLeafNodes());
                    break;

                case "Giá trị nhỏ nhất":
                    MessageBox.Show($"Giá trị nhỏ nhất ({dataType}) là: " + tree.FindMin());
                    break;

                case "Giá trị lớn nhất":
                    MessageBox.Show($"Giá trị lớn nhất ({dataType}) là: " + tree.FindMax());
                    break;

                case "Tìm giá trị X (người dùng nhập)":
                    string input = Microsoft.VisualBasic.Interaction.InputBox($"Nhập giá trị cần tìm ({dataType})", "Tìm giá trị X");

                    if (int.TryParse(input, out int key))
                    {
                        AVLNode foundNode = tree.Search(tree.Root, key);

                        if (foundNode != null)
                        {
                            string column1Value = foundNode.Data.Length > 1 ? foundNode.Data[0] : "(Không có dữ liệu)";

                            MessageBox.Show(
                                $" Tìm thấy giá trị X = {key}\n" +
                                $" Column1: {column1Value}",
                                "Kết quả tìm kiếm",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy giá trị trong cây!", "Kết quả tìm kiếm");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập số nguyên hợp lệ!");
                    }

                    break;
            }
        }
        //test----------------------------
        private void button1_Click_1(object sender, EventArgs e)
        {
            string filePath = "Reading Habbit Of Students.csv";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Không tìm thấy file CSV!");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length <= 1)
            {
                MessageBox.Show("File CSV rỗng hoặc không có dữ liệu!");
                return;
            }

            string inputN = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập số dòng muốn hiển thị:",
                "Chọn số dòng",
                "10");

            if (!int.TryParse(inputN, out int N) || N <= 0)
            {
                MessageBox.Show("Vui lòng nhập số nguyên dương hợp lệ!");
                return;
            }

            Headers = lines[0].Split(',');

            DataTable dt = new DataTable();
            foreach (string header in Headers)
                dt.Columns.Add(header.Trim());

            if (N > lines.Length - 1) N = lines.Length - 1;

            TopRows.Clear();
            for (int i = 1; i <= N; i++)
            {
                string[] values = lines[i].Split(',');
                TopRows.Add(values);

                object[] toAdd = new object[dt.Columns.Count];
                int copyLen = Math.Min(values.Length, dt.Columns.Count);
                for (int j = 0; j < copyLen; j++) toAdd[j] = values[j];
                for (int j = copyLen; j < dt.Columns.Count; j++) toAdd[j] = DBNull.Value;

                dt.Rows.Add(toAdd);
            }

            dataGridView1.DataSource = dt;
            MessageBox.Show($"Đã hiển thị {N} dòng đầu từ CSV!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TopRows == null || TopRows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu N dòng. Vui lòng chọn N dòng trước (nút 1).");
                return;
            }

            int keyIndex = Array.FindIndex(Headers, h => h.Trim().Equals("Time to read a book", StringComparison.OrdinalIgnoreCase));
            if (keyIndex == -1)
            {
                MessageBox.Show("Không tìm thấy cột 'Time to read a book' trong CSV!");
                return;
            }

            // Tạo cây AVL từ N dòng
            AVLTree tree = new AVLTree();
            foreach (var row in TopRows)
            {
                string keyStr = row[keyIndex].Trim();
                if (int.TryParse(keyStr, out int key))
                    tree.Root = tree.Insert(tree.Root, key, row);
            }

            string inputLevel = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tầng K muốn xem (root = 0):",
                "Chọn tầng",
                "0");

            if (!int.TryParse(inputLevel, out int level) || level < 0)
            {
                MessageBox.Show("Vui lòng nhập số tầng hợp lệ!");
                return;
            }

            List<AVLNode> nodesAtLevel = GetNodesAtLevel(tree.Root, level);
            List<string[]> rowsAtLevel = nodesAtLevel.Select(n => n.Data).ToList();

            DataTable dtLevel = new DataTable();
            foreach (string header in Headers)
                dtLevel.Columns.Add(header);

            foreach (var row in rowsAtLevel)
            {
                object[] toAdd = new object[dtLevel.Columns.Count];
                int copyLen = Math.Min(row.Length, dtLevel.Columns.Count);
                for (int j = 0; j < copyLen; j++) toAdd[j] = row[j];
                for (int j = copyLen; j < dtLevel.Columns.Count; j++) toAdd[j] = DBNull.Value;

                dtLevel.Rows.Add(toAdd);
            }

            dataGridView1.DataSource = dtLevel;
            MessageBox.Show($"Đã hiển thị {nodesAtLevel.Count} node ở tầng {level}!");
        }
    }
}



