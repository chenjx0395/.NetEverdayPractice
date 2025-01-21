using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace _02_打印网站字符数_异步版
{
    public class MyDownloadString
    {
        /// <summary>
        /// 计算代码执行时间
        /// </summary>
        private readonly Stopwatch _sw = new Stopwatch();
        public void DoRun()
        {
            const int value = 100_000_000;
            _sw.Start();
            var startTime = _sw.Elapsed;
            var task1 = CountCharactersAsync(1, "http://www.jd.com");
            var task2 = CountCharactersAsync(2, "http://www.taobao.com");
            MockLongTimeThing(1, value);
            MockLongTimeThing(2, value);
            MockLongTimeThing(3, value);
            MockLongTimeThing(4, value);
            Console.WriteLine("京东的首页字符数：{0}", task1.Result);
            Console.WriteLine("淘宝的首页字符数：{0}", task2.Result);
            var stopTime = _sw.Elapsed;
            Console.WriteLine("任务执行总耗时：{0} ms", (stopTime - startTime).TotalMilliseconds);
        }

        /// <summary>
        /// 获取网站的字符数
        /// </summary>
        /// <param name="id">任务编号</param>
        /// <param name="url">网址</param>
        /// <returns>网址的字符数</returns>
        private async Task<int> CountCharactersAsync(int id, string url)
        {
            var client = new WebClient();
            var startTime = _sw.Elapsed;
            var webContent = await client.DownloadStringTaskAsync(new Uri(url));
            var stopTime = _sw.Elapsed;
            Console.WriteLine("{0}号网址下载时间：{1} ms", id, (stopTime - startTime).TotalMilliseconds);
            return webContent.Length;
        }


        private void MockLongTimeThing(int id, int value)
        {
            var startTime = _sw.Elapsed;
            for (var i = 0; i < value; i++) ;
            var stopTime = _sw.Elapsed;

            Console.WriteLine("{0}号长时任务执行的时长：{1} ms", id, (stopTime - startTime).TotalMilliseconds);

        }
    }
}