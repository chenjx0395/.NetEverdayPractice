using System;
using System.Windows.Forms;

namespace _6_TreeView树状控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // 添加根节点
        private void button1_Click(object sender, EventArgs e)
        {
            var treeNode = treeView1.Nodes.Add("新添加的根节点");
            // 给新添加的根节点添加一个子节点
            treeNode.Nodes.Add("一起添加的子节点");
        }
        // 添加子节点
        private void button2_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView1.SelectedNode;
            selectedNode.Nodes.Add("新添加的子节点");
        }
        // 获取节点文本
        private void button3_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView1.SelectedNode;
            MessageBox.Show(selectedNode.Text);
        }
        // 删除节点
        private void button4_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView1.SelectedNode;
            treeView1.Nodes.Remove(selectedNode);
        }
        // 展开所有节点
        private void button5_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }
        // 折叠所有节点
        private void button6_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }
        // 清空所有节点
        private void button7_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }
    }
}
