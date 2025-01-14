using System;
using System.Threading;

namespace _1_多线程模拟异步
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("炒菜店开业啦！！！");
            Console.WriteLine("欢迎顾客点餐");
            var shopName = Console.ReadLine();
            // 子线程制作咖啡
            var thread = new Thread(() =>
            {
                Console.WriteLine($"正在制作{shopName}");
                // 模拟制作
                Thread.Sleep(3000);
            }); 
            thread.Start();

            Console.WriteLine("给顾客倒水");
            Console.WriteLine("给顾客准备盘子");

            // 轮询等待咖啡制作完成
            while (true)
            {
                if (thread.ThreadState == ThreadState.Stopped)
                {
                    Console.WriteLine($"{shopName}制作完成，顾客来取餐吧");
                    break;
                }
            }
        }
    }
}
