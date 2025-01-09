using System;

namespace _5_泛型默认值
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var test = Test<string>();
            Console.WriteLine(test); //hello
            var test2 = Test<bool>();
            Console.WriteLine(test2); //False
        }

        public static T Test<T>()
        {
            T t;
            if (typeof(T) == typeof(int))
            {
                t = (T)(object)666;
            }
            else if (typeof(T) == typeof(string))
            {
                t = (T)(object)"hello";
            }
            else
            {
                // 泛型默认值
                t = default;
            }
            return t;
        }
    }
}