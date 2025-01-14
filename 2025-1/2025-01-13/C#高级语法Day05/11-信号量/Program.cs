using System;
using System.Threading;

namespace _11_信号量
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (var j = 0; j < 1000; j++)
            {
                var number = 0;
                //信号灯  红绿灯  用来控制线程的执行和暂停
                //手动挡的红绿灯
                //ManualResetEvent manualResetEvent = new ManualResetEvent(false);
                //自动挡的红绿灯
                //manualResetEvent.Set(); 自动挡对象调用完Set之后，会自动再把红绿灯变成红灯。
                var resetEvent = new ManualResetEvent(false);   
                new Thread(() =>
                {
                    for (var i = 0; i < 10000; i++)
                    {
                        number++;
                    }
                    resetEvent.Set(); // 线程1执行完，设置绿灯
                }).Start();
                new Thread(() =>
                {
                    // 线程2 需要等待线程1执行完
                    resetEvent.WaitOne();
                    for (var i = 0; i < 10000; i++)
                    {
                        number++;
                    }
                }).Start();
                Thread.Sleep(100);
                Console.WriteLine(number);
            }
        }
    }
}
