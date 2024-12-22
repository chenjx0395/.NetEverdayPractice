
using System;
using ClassLibrary1;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Square s1 = new Square();
            s1.Length = 10;
            Console.WriteLine(s1.Area);
        }
    }
}
