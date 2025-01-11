using System;

namespace _4_泛型委托练习_求数组最大值
{
    // 定义委托
    internal delegate int MaxDel<T>(T a, T b);

    internal abstract class Program
    {
        public static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 88, 8, 9, 10 };
            string[] strs = { "aasd", "basd", "cqwe", "iasfasdqw", "j123" };
            Person[] persons =
            {
                new Person { Name = "张三", Age = 18 }, new Person { Name = "李四", Age = 66 },
                new Person { Name = "王五", Age = 20 }
            };
            Console.WriteLine(GetMax(nums, (a, b) => a - b));
            Console.WriteLine(GetMax(strs, (a, b) => a.Length - b.Length));
            Console.WriteLine(GetMax(persons, (a, b) => a.Age - b.Age).Name);
        }

        private static T GetMax<T>(T[] arrs, MaxDel<T> maxDel)
        {
            T max = arrs[0];
            for (var i = 1; i < arrs.Length; i++)
            {
                max = maxDel(max, arrs[i]) > 0 ? max : arrs[i];
            }

            return max;
        }

        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}