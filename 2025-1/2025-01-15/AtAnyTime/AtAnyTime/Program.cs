using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AtAnyTime
{
    internal class Program 
    {
        static async Task Main(string[] args)
        {
            // Case1();
            // Case2();
            // Case3();
            Console.WriteLine("当前线程"+Thread.CurrentThread.Name);
            Task<int> task4  = Case4();
            // 只要使用了await，那么所处的方法也要声明成异步方法。
            await task4;
            Console.WriteLine(task4);
        }

        /// <summary>
        /// 使用 async/await
        /// 获取淘宝网首页的html，存入文件，返回文件的字符数
        /// </summary>
        /// <returns></returns>
        public static async Task<int> Case4()
        {
            const string path = @"D:\test.txt";
            const string url = "http://www.taobao.com";
            var webClient = new WebClient();
            Task<string> task = webClient.DownloadStringTaskAsync(url);
            // await 会切换线程等待任务执行，不会阻塞当前线程
            await task; // 等待异步方法执行完毕
            string html = task.Result; // 获取结果
            using (var fs = new FileStream(path, FileMode.Create))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(html);
                // 使用异步写入文件
                Task writeTask = fs.WriteAsync(bytes, 0, bytes.Length);
                await writeTask;
            }

            // 如果异步方法有返回值，必须以Task<T>的形式返回；
            return html.Length;
        }

        /// <summary>
        /// 任务的创建：方式三，控制执行顺序
        /// </summary>
        public static void Case1()
        {
            var t1 = new Task(() => { Console.WriteLine("任务1执行"); });
            var t2 = new Task(() => { Console.WriteLine("任务2执行"); });
            var t3 = new Task(() => { Console.WriteLine("任务3执行"); });
            t1.Start();
            t2.Start();
            t3.Start(); // 3个任务无序执行，底层使用线程池调用
            Console.ReadKey();
        }

        /// <summary>
        /// 任务的创建：方式二，控制执行顺序
        /// </summary>
        public static void Case2()
        {
            // ContinueWith 控制顺序执行
            Task.Run(() => { Console.WriteLine("任务1执行"); }).ContinueWith((task) => { Console.WriteLine("任务2执行"); })
                .ContinueWith((task) => { Console.WriteLine("任务3执行"); });
            Console.ReadKey();
        }

        /// <summary>
        /// 多线程和任务的对比
        /// </summary>
        public static void Case3()
        {
            // 任务中尽量不使用线程的API
            // 任务中暂停
            /*Task.Run(() =>
            {
                Task.Delay(3000);
                Console.WriteLine("任务1执行");
            });*/
            // 多线程处理1000个请求，创建1000个线程，Task处理1000个请求，最大线程数是固定的，是线程池的最大线程数

            Console.ReadKey();
        }

        
    }
}
