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

namespace WindowsFormsCase2
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
            //1. 创建服务端Socket,使用IP4，字节流，TCP协议
            var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //2. 服务端绑定本机IP和 6666 端口号
            server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666));

            //3. 服务端开始监听，最多监听10个客户端
            server.Listen(10);

            Console.WriteLine("服务端：创建，绑定，监听准备完毕！");

            //4. 阻塞等待，接受客户端的连接
            while (true)
            {
                client = server.Accept();

                Console.WriteLine("客户端连接了");

                //5. 阻塞等待接收客户端消息
                var buffer = new byte[1024];
                var v = client.Receive(buffer);
                label1.Text = Encoding.UTF8.GetString(buffer, 0, v);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //6. 向客户端发消息
            client.Send(Encoding.UTF8.GetBytes(textBox1.Text));
        }
    }
}
