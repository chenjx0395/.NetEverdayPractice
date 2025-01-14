using System;
using System.Threading;

namespace _12_使用线程池
{
    internal class Program
    {
        // QueueUserWorkItem 接受一个委托，从线程池中取出一个线程执行任务
        static void Main(string[] args)
        {
            for (var i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem((obj) => {
                    Console.WriteLine("线程池创建了线程的ID是" + Thread.CurrentThread.ManagedThreadId);
                });
            }
            Thread.Sleep(1000);
            for (var i = 0; i < 10; i++)
            {
                var th = new Thread(() => {

                });
                th.Start();
                Console.WriteLine("我自己创建的线程对象ID是" + th.ManagedThreadId);
            }

        }
    }
}
