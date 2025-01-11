using System;

namespace _2_匿名方法与Lambda表达式
{
    delegate int AddDelegate(int a, int b);

    internal class Program
    {
        public static void Main(string[] args)
        {
            
            int Add(int x, int y)
            {
                return x + y;
            }
            // 不使用匿名方法
            AddDelegate add1 = Add;
            // 使用匿名方法
            AddDelegate add2 = delegate(int x, int y) { return x + y; };
            // 使用Lambda表达式
            AddDelegate add3 = (x, y) => x + y;
        }
        
    }
}