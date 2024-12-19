using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class IfElseExer02
    {
        public static void Main()
        {
            Random random = new Random();
            int daysUntilExpiration = random.Next(12);
            int discountPercentage = 0;

            if (daysUntilExpiration == 0)
            {
                Console.WriteLine("您的订阅已过期！");
            }
            else if (daysUntilExpiration == 1)
            {
                Console.WriteLine("您的订阅还有1天过期！");
                Console.WriteLine("现在订阅优惠20%！");
                discountPercentage = 20;
            }
            else if (daysUntilExpiration <= 5)
            {
                Console.WriteLine($"您的订阅还有{daysUntilExpiration}天过期！");
                Console.WriteLine("现在订阅优惠10%！");
                discountPercentage = 10;
            }
            else if (daysUntilExpiration <= 10)
            {
                Console.WriteLine($"您的订阅即将过期！");
            }
        }
    }
}
