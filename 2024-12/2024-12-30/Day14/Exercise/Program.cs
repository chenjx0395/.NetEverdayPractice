using System;
using System.Threading;

namespace Exercise
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 子线程的创建与运行
            // Case1();
            // 子线程传参
            Case2();
            
        }

        public static void Case2()
        {
            var thread = new Thread(Task2);
            thread.Start(666);
        }

        public static void Task2(object i)
        {
            Console.WriteLine(i); // 666
        }

        public static void Case1()
        {
            var thread = new Thread(Task);
            // 将子线程设置为后台线程，即主线程执行完，子线程会直接关闭
            thread.IsBackground = true;
            thread.Start();
            for (var i = 0; i < 30; i++)
            {
                Console.WriteLine("主线程执行了：{0}",i); 
                Thread.Sleep(500);
            }
        }

        private static void Task()
        {
            for (var i = 0; i < 30; i++)
            {
                Console.WriteLine("子线程执行了：{0}",i); 
                Thread.Sleep(1000);
            }
        }
    }
}