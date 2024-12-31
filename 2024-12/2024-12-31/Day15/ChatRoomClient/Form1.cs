using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatRoomClient
{
    public partial class Form1 : Form
    {
        private Socket _client;
        private Thread _messageThread;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        // 连接服务端
        private void button1_Click(object sender, EventArgs e)
        {
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _client.Connect(new IPEndPoint(IPAddress.Parse(textBox1.Text), Convert.ToInt32(textBox2.Text)));
            textBox3.AppendText("已成功连接服务端！\r\n");
            // 连接成功后，创建监听服务端消息线程
            _messageThread = new Thread(MonitorMessage)
            {
                IsBackground = true
            };
            _messageThread.SetApartmentState(ApartmentState.STA);
            _messageThread.Start();
        }

        // 发送消息给服务端
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                _client.Send(Encoding.UTF8.GetBytes(textBox4.Text));
                textBox4.Text = "";
            }
            catch (SocketException)
            {
                MessageBox.Show($"此服务端已断开连接！无法发送消息！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 监听消息线程
        private void MonitorMessage()
        {

            while (true)
            {
                try
                {
                    var bytes = new byte[1024 * 1024 * 10]; // 10MB
                    //阻塞等待接收服务端的消息
                    //返回接收的数据长度
                    var length = _client.Receive(bytes);
                    Console.WriteLine("长度"+length);
                    var category = bytes[0];
                    switch (category)
                    {
                        // 发送消息
                        case 0:
                            textBox3.AppendText("\r\n" + _client.RemoteEndPoint + "：" + Encoding.UTF8.GetString(bytes, 1, length));
                            break;
                        // 发送文件
                        case 1:
                            // 询问是否要接收文件
                            var dialogResult = MessageBox.Show("服务端向你发送了文件。是否接收", "接收文件",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                            if (dialogResult == DialogResult.Yes)
                            {
                                Console.WriteLine("*************************************");
                                //1. 创建保存文件对话框对象
                                var sfd = new SaveFileDialog();
                                //1.1 设置保存文件对话框标题
                                sfd.Title = "请选择保存的位置";
                                //1.2 设置的访问文件夹的路径
                                sfd.InitialDirectory = "D:\\";
                                //1.3 设置文件过滤器
                                sfd.Filter = "文本文件|*.txt|视频|*.mp4|图片|*.png|任意|*.*";

                                //2. 打开文件对话框
                                sfd.ShowDialog();

                                //3.获取保存的文件路径及文件名
                                var fileName = sfd.FileName;

                                if (!string.IsNullOrEmpty(fileName))
                                {
                                    //保存到指定的文件
                                    using (var stream = sfd.OpenFile())
                                    {
                                        stream.Write(bytes, 1, length);
                                    }
                                }
                                MessageBox.Show("文件接收成功！");
                            }
                            break;
                        // 抖动窗口
                        case 2:
                            for (var i = 0; i < 100; i++)
                            {
                                Location = new Point(Location.X + 5, Location.Y + 5);
                                Location = new Point(Location.X - 5, Location.Y - 5);
                            }
                            break;
                        default:
                            throw new Exception("错误的信息类别");
                    }
                }
                catch (SocketException ex)
                {
                    MessageBox.Show($"此服务端已掉线！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 如果关闭窗体时有连接，清理资源
            _client?.Close();
        }
    }
}

