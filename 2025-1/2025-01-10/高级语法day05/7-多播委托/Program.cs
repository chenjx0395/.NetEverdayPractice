using System;
using System.Runtime.InteropServices;

namespace _7_多播委托
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Action a1 = () => Console.WriteLine("方法1");
            // 通过 += 运算符来增添绑定的事件
            a1 += F2;
            a1 += F3;
            a1();
            // 可以通过 -= 删除绑定的事件
            a1 -= F2;
            a1 -= F3;
            // Lambda 表达式绑定的方法几乎无法删除。
            a1();
        }

        static void F2()
        {
            Console.WriteLine("方法2");
        }
        
        static void F3()
        {
            Console.WriteLine("方法3");
        }
    }
}