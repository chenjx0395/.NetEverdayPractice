using System;
using System.Threading;

namespace _9_死锁
{
    internal class Program
    {
        private static object key1 = new object();
        private static object key2 = new object();
        static void Main(string[] args)
        {
            new Thread(() =>
            {
                lock (key1)
                {
                    Thread.Sleep(1000);
                    lock (key2)
                    {
                        Console.WriteLine("线程1快活了");
                    }
                }
            }).Start();
            new Thread(() =>
            {
                lock (key2)
                {
                    Thread.Sleep(1000);
                    lock (key1)
                    {
                        Console.WriteLine("线程2快活了");
                    }
                }
            }).Start();
        }
    }
}
