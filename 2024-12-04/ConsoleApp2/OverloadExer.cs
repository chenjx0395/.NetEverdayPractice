using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class OverloadExer
    {
        public static void OverloadExerM()
        {
            Random dice = new Random();
            // 0 到 2,147,483,647  int类型的最大值
            int roll1 = dice.Next();
            // 0 到 100
            int roll2 = dice.Next(101);
            int roll3 = dice.Next(50, 101);

            Console.WriteLine($"First roll: {roll1}");
            Console.WriteLine($"Second roll: {roll2}");
            Console.WriteLine($"Third roll: {roll3}");
        }
    }
}
