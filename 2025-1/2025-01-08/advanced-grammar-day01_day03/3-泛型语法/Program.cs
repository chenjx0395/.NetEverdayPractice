using System;

namespace _3_泛型语法
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var tInt = new Test<int>(6);
            var tStr = new Test<string>("world");
            tInt.SayHello();
            tStr.SayHello();
            
        }
    }

    class Test<T>
    {
        private T t;

        public Test(T t)
        {
            this.t = t;
        }

        public void SayHello()
        {
            Console.WriteLine("hello " + t);
        }
    }
}