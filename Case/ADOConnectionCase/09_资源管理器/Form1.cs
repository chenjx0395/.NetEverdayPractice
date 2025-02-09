using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09_资源管理器
{
    public partial class Form1 : Form
    {

        private Dictionary<string, string> _dictionary = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLevel1Directory();

        }

        private void LoadLevel1Directory()
        {
            //读取数据库的一级目录
            string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "SELECT * FROM type WHERE tParentId = -1;";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TreeNode node = treeView1.Nodes.Add(reader["tName"].ToString());
                        node.Tag = reader["tId"].ToString();
                    }
                }
            }
        }

        private void LoadSecondaryDirectory()
        {
            string tId = treeView1.SelectedNode.Tag.ToString();

            //读取数据库的二级目录
            string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "SELECT * FROM type WHERE tParentId = @tId;";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@tId", tId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var node = treeView1.SelectedNode.Nodes.Add(reader["tName"].ToString());
                        node.Tag = reader["tId"].ToString();
                    }
                }
            }
        }

        private void ShowFiles()
        {
            listBox1.Items.Clear();
            string tId = treeView1.SelectedNode.Tag.ToString();

            //读取数据库的二级目录
            string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "SELECT * FROM data WHERE dTypeId =  @tId;";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@tId", tId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["dName"]);
                        if (!_dictionary.ContainsKey(reader["dName"].ToString()))
                        {
                            _dictionary.Add(reader["dName"].ToString(), reader["dContent"].ToString());
                        }
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 防止重复添加子节点
            treeView1.SelectedNode?.Nodes.Clear();
            LoadSecondaryDirectory();
            ShowFiles();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = _dictionary[listBox1.SelectedItem.ToString()];
        }

        private void WriteData(string path, int parentId)
        {
            //将当前文件夹写入数据库
            string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            int newParentId;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "INSERT INTO type(tName,tParentId) VALUES(@tName,@tParentId) SELECT @@identity";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    // 获取当前目录的文件夹名
                    string fileName = Path.GetFileName(path);
                    command.Parameters.AddWithValue("@tName", fileName);
                    command.Parameters.AddWithValue("@tParentId", parentId);
                    newParentId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            //获取当前文件夹下的文件
            // 创建 DirectoryInfo 对象
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            // 遍历目录中的所有文件和子目录
            foreach (FileSystemInfo item in directoryInfo.GetFileSystemInfos())
            {
                if (item is DirectoryInfo)
                {
                    // 如果是文件夹，递归调用
                    WriteData(item.FullName, newParentId);
                }
                else if (item is FileInfo)
                {
                    // 如果是文件，则写入数据库
                    WriteTxtFile(item.FullName, newParentId);
                }
            }
        }

        private void WriteTxtFile(string filePath, int dTypeId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "INSERT INTO data(dTypeId,dName,dContent) VALUES(@dTypeId,@dName,@dContent) ";
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    // 获取当前目录的文件名
                    string fileName = Path.GetFileName(filePath);
                    command.Parameters.AddWithValue("@dName", fileName);
                    command.Parameters.AddWithValue("@dTypeId", dTypeId);
                    // 获取当前文件的内容
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string content = sr.ReadToEnd();
                        command.Parameters.AddWithValue("@dContent", content);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 选择一个文件夹
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                // 递归将文件夹和文件写入数据库
                WriteData(fbd.SelectedPath, -1);
            }
            else
            {
                MessageBox.Show("请选择文件夹！");
            }
            treeView1.Nodes.Clear();
            LoadLevel1Directory();
        }
    }
}
