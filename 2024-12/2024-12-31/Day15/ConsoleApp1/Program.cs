using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace ChatRoom
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
            var thread1 = new Thread(Case1);
            thread1.Start();
            Thread.Sleep(1000);
            var thread2 = new Thread(Case2);
            thread2.Start();
        }

        public static void Case1()
        {
            var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666));
                server.Listen(10);
                Console.WriteLine("服务端：创建，绑定，监听准备完毕");
                //4.阻塞等待，接收客户端的连接
                var client = server.Accept();
                Console.WriteLine("客户端连接了");
                //6.向客户端发消息
                while (true)
                {
                    var readLine = Console.ReadLine();
                    if (readLine != " ")
                    {
                        client.Send(Encoding.UTF8.GetBytes(readLine));
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Case1 出错: {ex.Message}");
            }
            finally
            {
                server.Close();
            }
        }

        public static void Case2()
        {
            //1.创建服务端Socket，使用IP4，字节流，Tcp协议
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                //2.客户端连接服务端
                client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6666));
                //4.阻塞等待接收服务端的消息
                var thread = new Thread(Case3);
                thread.Start(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Case2 出错: {ex.Message}");
            }
           
        }

        public static void Case3(Object client)
        {
            var newClient = (Socket)client;
            while (true)
            {
                try
                {
                    byte[] bytes = new byte[1024];
                    int v = newClient.Receive(bytes);
                    Console.WriteLine("客户端：" + Encoding.UTF8.GetString(bytes, 0, v));
                }
                catch (SocketException ex) when (ex.SocketErrorCode == SocketError.ConnectionReset)
                {
                    Console.WriteLine("服务端关闭了连接。");
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Case3 出错: {e.Message}");
                    break;
                }
            }
            newClient.Close();
        }
    }
}