using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace _8_同步方法
{
    internal class Program
    {
        private static int _number = 0;

        private static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                var th1 = new Thread(Test);
                th1.Start();

                var th2 = new Thread(Test);
                th2.Start();

                th1.Join();
                th2.Join();
                Console.WriteLine(_number);
                Console.ReadKey();
            }
        }
        //Synchronized 同步
        //ASynchronized 异步
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void Test()
        {
            for (var i = 0; i < 10000; i++)
            {
                _number++;
                Thread.Sleep(0);
            }
        }
    }
}
