using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketCLient
{
    public partial class Form1 : Form
    {
        private Socket client;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var thread = new Thread(Task);
            thread.Start();
        }

        private void Task()
        {
            //1. 创建客户端Socket，使用IP4，字节流，TCP协议
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //2. 连接服务端
            client.Connect(new IPEndPoint(IPAddress.Parse("192.168.10.5"), 6666));

            //4. 接收服务端的消息
            while (true)
            {
                var buffer = new byte[1024];
                var v = client.Receive(buffer);
                label1.Text = Encoding.UTF8.GetString(buffer, 0, v);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //3. 发送消息给服务端
            client.Send(Encoding.UTF8.GetBytes(textBox1.Text));
        }
    
    }
}
