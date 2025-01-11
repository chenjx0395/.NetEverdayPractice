using System;
using System.IO;
using System.Windows.Forms;

namespace _7_递归资源管理器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string _path = "C:\\Program Files\\Docker\\Docker";
        private void Form1_Load(object sender, EventArgs e)
        {
            Recursion(treeView1.Nodes, _path);
        }

        //递归生成指定路径的资源管理器
        private void Recursion(TreeNodeCollection nodes,string path)
        {
            //获取当前路径下的目录
            var dirs = Directory.GetDirectories(path);
            foreach (var item in dirs)
            {
                var node = nodes.Add(Path.GetFileName(item));
                Recursion(node.Nodes, item);
            }
            // 获取当前路径下的文件
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                nodes.Add(Path.GetFileName(file));
            }
        }

    }
}
