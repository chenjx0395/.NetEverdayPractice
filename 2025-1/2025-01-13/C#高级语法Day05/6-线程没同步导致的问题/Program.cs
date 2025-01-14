using System;
using System.Diagnostics;
using System.Threading;

namespace _6_线程没同步导致的问题
{
    internal class Program
    {
        static volatile int number;
        static void Main(string[] args)
        {
            // Case1();
            Case2();
        }
       

        public static void Case1()
        {
            for (int j = 0; j < 10000; j++)
            {
                number = 0;
                var t1 = new Thread(() =>
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        Interlocked.Increment(ref number);
                    }
                });
                var t2 = new Thread(() =>
                {
                    for (int i = 0; i < 10000; i++)
                    {
                        Interlocked.Increment(ref number);
                    }
                });
                t1.Start();
                t2.Start();
                t1.Join();
                t2.Join();
                Console.WriteLine(number); // 1或2
            }
        }
        private static volatile  bool flag;
        /// <summary>
        /// 可见性案例
        /// </summary>
        /// 
        public static void Case2()
        {
            for (int i = 0; i < 1000; i++)
            {
                flag = false;
                var t1 = new Thread(() =>
                {
                    Thread.Sleep(100);
                    flag = true; // 修改 flag
                    Console.WriteLine("t1 修改 flag 为 true");
                });

                var t2 = new Thread(() =>
                {
                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    while (!flag) // 读取 flag
                    {
                        // 空循环
                    }
                    stopwatch.Stop();
                    Console.WriteLine($"t2 检测到 flag 的修改,检测时间为：{stopwatch.ElapsedMilliseconds}");
                });

                t1.Start();
                t2.Start();
                Thread.Sleep(500);
            }
        }
    }


}
