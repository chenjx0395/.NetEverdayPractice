using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4_控制线程执行顺序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Thread(() =>
            {
                Console.WriteLine("线程1执行");
            });
            var t2 = new Thread(() =>
            {
                // Thread.Sleep(1000);
                Console.WriteLine("线程2执行");

            });
            t1.Start();
            t1.Join(); // 主线线程等待子线程1执行完成
            t2.Start();
            // Thread.Sleep(2000); // 主线程睡眠等待
            t2.Join(); // 主线线程等待子线程2执行完成
            Console.WriteLine("主线程执行");
        }
    }
}
