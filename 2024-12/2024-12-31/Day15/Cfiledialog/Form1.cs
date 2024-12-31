using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Cfiledialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. 创建文件对话框对象
            var fileDialog = new OpenFileDialog();
            // 1.1 设置文件对话框标题
            fileDialog.Title = "请选择打开的文件";
            // 1.2 设置是否允许选择多个文件
            fileDialog.Multiselect = false;
            // 1.3 设置访问文件夹的地址
            fileDialog.InitialDirectory = "D:\\";
            // 1.4 设置文件过滤器
            fileDialog.Filter = "文本文件|*.txt|视频|*.mp4|图片|*.png";

            // 2. 打开文件对话框
            fileDialog.ShowDialog();

            // 3. 获取被选择的文件的路径及文件名
            var fileName = fileDialog.FileName;
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                //4.  获取选中文件的输入流
                //5. 读取文件中的数据
                using (var stream = fileDialog.OpenFile())
                {
                    var bytes = new byte[1024];
                    var length = stream.Read(bytes, 0, bytes.Length);
                    textBox1.AppendText(Encoding.UTF8.GetString(bytes, 0, length));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1. 创建保存文件对话框对象
            var sfd = new SaveFileDialog();
            //1.1 设置保存文件对话框标题
            sfd.Title = "请选择保存的位置";
            //1.2 设置的访问文件夹的路径
            sfd.InitialDirectory = "D:\\";
            //1.3 设置文件过滤器
            sfd.Filter = "文本文件|*.txt|视频|*.mp4|图片|*.png";

            //2. 打开文件对话框
            sfd.ShowDialog();

            //3.获取保存的文件路径及文件名
            var fileName = sfd.FileName;

            if (!string.IsNullOrEmpty(fileName))
            {
                //保存到指定的文件
                using (var stream = sfd.OpenFile())
                {
                    var bytes = Encoding.UTF8.GetBytes(textBox1.Text);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}
