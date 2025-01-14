using System;
using System.Threading;

namespace _7_锁解决线程同步
{
    internal class Program
    {
        private static object o = new object();
        static void Main(string[] args)
        {
            for (int j = 0; j < 1000; j++)
            {
                var number = 0;
                var t1 = new Thread(() =>
                    {
                        for (var i = 0; i < 10000; i++)
                        {
                            /*Monitor.Enter(o);
                            number++;
                            Monitor.Exit(o);*/
                            /*lock (o)
                            {
                                number++;
                            }*/
                            Interlocked.Increment(ref number);
                        }
                    }
                );
                var t2 = new Thread(() =>
                    {
                        for (var i = 0; i < 10000; i++)
                        {
                            /*Monitor.Enter(o);
                            number++;
                            Monitor.Exit(o);*/
                            /*lock (o)
                            {
                                number++;
                            }*/
                            Interlocked.Increment(ref number);

                        }
                    });
                t1.Start();
                t2.Start();
                t1.Join();
                t2.Join();
                Console.WriteLine(number);
            }
        }
    }
}
