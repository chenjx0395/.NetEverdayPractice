using System;
using System.Diagnostics;
using System.Net;

namespace 打印网站字符数_同步版
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
            var webCharCount1 = CountCharacters(1, "http://www.jd.com");
            var webCharCount2 = CountCharacters(2, "http://www.taobao.com");
            MockThing(1, value);
            MockThing(2, value);
            MockThing(3, value);
            MockThing(4, value);
            Console.WriteLine("京东的首页字符数：{0}", webCharCount1);
            Console.WriteLine("淘宝的首页字符数：{0}", webCharCount2);
            var stopTime = _sw.Elapsed;
            Console.WriteLine("任务执行总耗时：{0} ms",(stopTime - startTime).TotalMilliseconds);
        }

        /// <summary>
        /// 获取网站的字符数
        /// </summary>
        /// <param name="id">任务编号</param>
        /// <param name="url">网址</param>
        /// <returns>网址的字符数</returns>
        private int CountCharacters(int id, string url)
        {
            var client = new WebClient();
            var startTime = _sw.Elapsed;
            var webContent = client.DownloadString(new Uri(url));
            var stopTime = _sw.Elapsed;
            Console.WriteLine("{0}号网址下载时间：{1} ms", id, (stopTime - startTime).TotalMilliseconds);

            return webContent.Length;
        }

        /// <summary>
        /// 模拟一个任务
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        private void MockThing(int id, int value)
        {
            var startTime = _sw.Elapsed;
            for (var i = 0; i < value; i++) ;
            var stopTime = _sw.Elapsed;

            Console.WriteLine("{0}号任务执行的时长：{1} ms", id, (stopTime - startTime).TotalMilliseconds);

        }
    }
}