using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Convert.ToInt32("123");
            int.TryParse("123", out var a);
            var max1 = Max(4, 6);
            Console.WriteLine(max1);
            Console.WriteLine("----------------");
            var max2 = ArrayMax(new[] { 1, 2, 8, 3, 4 });
            Console.WriteLine(max2);
            Console.WriteLine("----------------");
            var sum = Sum(new[] { 1, 2, 8, 3, 4 });
            Console.WriteLine(sum);
            Console.WriteLine("----------------");
            var avg = Avg(new[] { 1, 2, 8, 3, 4 });
            Console.WriteLine(avg);
            
            Case1();                                                                                                                                                                                                                                              

        }
        //4.重复让用户输入一个数，判断该数是否是奇数，输入q结束。

        public static void Case1()
        {
            while (true)
            {
                var read = Console.ReadLine();
                if (int.TryParse(read,out var result))
                {
                    if (IsOdd(result))
                    {
                        Console.WriteLine("奇数");
                    }
                }else if (read != null && read.Equals("q"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("错误的输入");
                }
            }

            bool IsOdd(int number)
            {
                return number % 2 != 0;
            }
        }


        //1. 定义一个方法，参数为两个整数，返回两个整数中的最大值：int Max(int i1,int i2)。
        private static int Max(int i1, int i2)
        {
            return i1 > i2 ? i1 : i2;
        }

        //2.定义一个方法，参数为整数类型数组，返回数组中的最大值：int ArrayMax（int[］ values)。
        private static int ArrayMax(int[] values)
        {
            var max = 0;
            foreach (var value in values)
            {
                if (value > max)
                {
                    max = value;
                }
            }

            return max;
        }

        //3.定义一个方法，参数为整数类型数组，返回数组中所有元素的和：int Sum（int[］ values)。
        private static int Sum(int[] values)
        {
            var sum = 0;
            foreach (var value in values)
            {
                sum += value;
            }

            return sum;
        }

        //4.定义一个方法，参数为整数类型数组，返回数组中所有元素的平均数：int Avg（int[］values）。
        private static int Avg(int[] values)
        {
            var avg = Sum(values) / values.Length;
            return avg;
        }

    }
}
