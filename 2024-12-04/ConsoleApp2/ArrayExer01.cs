using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ArrayExer01
    {
        public static void Main()
        {
            string[] fraudulentOrderIDs = ["A123", "B456", "C789"];

            Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
            Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
            Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");

            fraudulentOrderIDs[0] = "F000";

            Console.WriteLine($"修改后的First：{fraudulentOrderIDs[0]}");


            Console.WriteLine($"有 {fraudulentOrderIDs.Length} 个订单.");
        }
    }
}
