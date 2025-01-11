using System;
using System.Runtime.Remoting.Messaging;

namespace _5_Action和Fun
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Action a1 = () => Console.WriteLine("Hello World!");
            a1();
            Action<string> a2 = (s1) => Console.WriteLine($"Hello {s1}");
            a2("C#");
            Func<int, int, int> f1 = (i1, i2) => i1 + i2;
            Func<int, int> f2 = (i1) => -i1;
            Func<int> f3 = () => 100;
            Console.WriteLine(f1(1, 2));
            Console.WriteLine(f2(6));
            Console.WriteLine(f3());
        }
    }
}