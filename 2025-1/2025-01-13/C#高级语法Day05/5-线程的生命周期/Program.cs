using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5_线程的生命周期
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Thread(() =>
            {
                Console.WriteLine("线程1执行了");
                Thread.Sleep(2);
            });
            t1.Start();
            while (true)
            {
                switch (t1.ThreadState)
                {
                    case ThreadState.Running:
                        Console.WriteLine("线程已启动");
                        break;
                    case ThreadState.WaitSleepJoin:
                        Console.WriteLine("线程已挂起或是睡眠");
                        break;
                    case ThreadState.Aborted:
                        Console.WriteLine("线程已死亡，一会后标记成stopped");
                        break;
                }

                if (t1.ThreadState == ThreadState.Stopped)
                {
                    Console.WriteLine("线程已死亡");
                    break;
                }
            }
        }
    }
}
