using System;

namespace _4_里氏替换
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 1、子类可以赋值给父类 2、如果父类中装的是子类对象，则可以将父类转换成【对应】的子类对象
            int a = 100;
            object b = a; // 子赋父
            Console.WriteLine(b);
            int c = (int)b; // 父转子
            Console.WriteLine(c);
            
            // 错误示例
            int a2 = 100;
            object b2 = a2;
            string c2 = (string)b2;
            Console.WriteLine(c2);
        }
    }
}