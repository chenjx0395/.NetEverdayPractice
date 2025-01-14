using System;
using System.Threading;

namespace 线程优先级问题
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n1 = 0.0;
            var n2 = 0.0;
            var t1 = new Thread(() =>
            {
                while (true)
                {
                    n1++;
                }
            });
            var t2 = new Thread(() =>
            {
                while (true)
                {
                    n2++;
                }
            });
            t1.Priority = ThreadPriority.Highest; // 设置优先级为最高
            t2.Priority = ThreadPriority.Lowest; // 设置优先级为最低
            t1.Start();
            t2.Start();
            Thread.Sleep(5000);
            Console.WriteLine(n1);
            Console.WriteLine(n2);
        }
    }
}
