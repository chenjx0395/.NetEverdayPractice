using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatRoom
{
    public partial class Form1 : Form
    {
        private Thread _connectThread;
        private readonly List<Thread> _messageThreads = new List<Thread>();
        private readonly List<Socket> _clientList = new List<Socket>(); // 改成集合，可以连接多个客户端
        private readonly BindingList<string> _comboBoxData = new BindingList<string>();
        private int _clientCount; // 客户端数量
        private int _index = -1;// 选中的客户端索引
        private Socket _service;
        private Socket _nowClient = null; // 选中的客户端


        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            comboBox1.DataSource = _comboBoxData;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        // 开启客户端
        private void button1_Click(object sender, EventArgs e)
        {
            //开启服务端监听客户端连接线程
            if (_connectThread != null) return;
            _connectThread = new Thread(MonitorConnect)
            {
                IsBackground = true
            };
            // 使按钮不可选
            button1.Enabled = false;
            _connectThread.Start();

        }
        
        // 监听客户端连接线程

        private void MonitorConnect()
        {
            _service = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _service.Bind(new IPEndPoint(IPAddress.Parse(textBox1.Text), Convert.ToInt32(textBox2.Text)));
            textBox3.AppendText("服务端正常启动！开始监听客户端连接……\r\n");
            _service.Listen(50);
            // 允许连接50个客户端
            while (_clientCount <= 50) // 检查是否请求取消
            {
                try
                {
                    // 阻塞等待客户端连接
                    _clientList.Add(_service.Accept());
                    textBox3.AppendText($"客户端: {_clientList[_clientCount].RemoteEndPoint} 已连接！\r\n");
                    // 将新的客户端信息存入下列列表
                    _comboBoxData.Add(_clientList[_clientCount].RemoteEndPoint.ToString());
                    _index = _comboBoxData.Count;
                    _nowClient = _clientList[_index - 1];
                    _clientCount++;
                    // 连接后，启动信息监听线程
                    _messageThreads.Add(new Thread(MonitorMessage) { IsBackground = true });
                    _messageThreads[_clientCount - 1].Start();
                }
                catch (SocketException ex)
                {
                    Console.WriteLine("SocketException: " + ex.Message);
                }
            }
        }
        // 监听客户端消息线程
        private void MonitorMessage()
        {
            // 获得当前客户端并存储
            var nowClient = _nowClient;
            // 循环监听
            while (true)
            {
                try
                {
                    var buffer = new byte[1024];
                    var length = nowClient.Receive(buffer);
                    textBox3.AppendText($"{nowClient.RemoteEndPoint}:{Encoding.UTF8.GetString(buffer, 0, length)}\r\n");
                }
                catch (Exception e)
                {
                    textBox3.AppendText($"{nowClient.RemoteEndPoint} 已离线！\r\n");
                    // 监听不到，代表此客户端下线，需要在记录的列表中删除该客户端的信息
                    _clientList.Remove(nowClient);
                    _comboBoxData.Remove(nowClient.RemoteEndPoint.ToString());
                    _clientCount--;
                    break;
                }
            }

        }
        // 发送消息给客户端
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (_index != -1)
                {
                    var bytes = Encoding.UTF8.GetBytes(textBox4.Text);
                    var sendBytes = new byte[bytes.Length + 1];
                    sendBytes[0] = 0;
                    Array.Copy(bytes, 0, sendBytes, 1, bytes.Length);
                    // 发送消息给客户端
                    _nowClient.Send(sendBytes);
                    textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show($"请选择要发送的客户端后再发送消息", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception)
            {
                MessageBox.Show($"请选择正确的发送对象", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 1. 创建文件对话框对象
            var fileDialog = new OpenFileDialog();
            // 1.1 设置文件对话框标题
            fileDialog.Title = "请选择发送的文件";
            // 1.2 设置是否允许选择多个文件
            fileDialog.Multiselect = false;
            // 1.3 设置访问文件夹的地址
            fileDialog.InitialDirectory = "D:\\";
            // 1.4 设置文件过滤器
            fileDialog.Filter = "文本文件|*.txt|视频|*.mp4|图片|*.png|任意|*.*";

            // 2. 打开文件对话框
            var dialogResult = fileDialog.ShowDialog();
            // 获取文件名和路径
            var fileName = fileDialog.FileName;
            textBox5.Text = fileName;
            if (dialogResult != DialogResult.OK) return;
            using (var stream = fileDialog.OpenFile())
            {
                var bytes = new byte[stream.Length + 1];
                // 1 代表发送的文件
                bytes[0] = 1;
                stream.Read(bytes, 1, bytes.Length - 1);
                _nowClient.Send(bytes);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] bytes = { 2 };
            _nowClient.Send(bytes);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _index = comboBox1.SelectedIndex;
            if (_index == -1)
            {
                _nowClient = null;
                return;
            }
            _nowClient = _clientList[_index];
        }
    }
}
