using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ArrayExer02
    {
        public static void Main()
        {
            string[] orders = { "B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179" };
            foreach (string order in orders)
            {
                if (order.StartsWith('B'))
                {
                    Console.WriteLine($"订单号{order}是欺诈订单！");
                }
            }
        }
    }
}
