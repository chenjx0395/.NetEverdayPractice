using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2_线程传参
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var i = 5;
            var thread = new Thread((o) => { Console.WriteLine("子线程" + o); });
            thread.Start(i);
            i = 6;
            Console.WriteLine("主线程" + i);
            /*
                主线程6
                子线程5
             */
        }
    }
}
