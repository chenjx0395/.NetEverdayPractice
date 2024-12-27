using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercise
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 隐式转换
            // Case1();
            // 显示转换
            // Case2();
            // 表达式检测溢出
            // Case3();
            // 语句检测溢出
            Case4();
            var arrayList = new ArrayList();
        }

        public static void Case4()
        {
            unchecked
            {
                ushort s = 12345;
                byte b;
                b =  unchecked((byte)s); // 不会抛出异常
                checked
                {
                    b = checked((byte)s);  // 会抛出异常
                    Console.WriteLine($"转换前：{s} 转换后：{b} 类型：{b.GetType()}"); 
                }
            }
        }

        public static void Case3()
        {
            ushort s = 12345;
            byte b;
            b =  unchecked((byte)s); // 不会抛出异常
            b = checked((byte)s);  // 会抛出异常
            Console.WriteLine($"转换前：{s} 转换后：{b} 类型：{b.GetType()}");
        }

        public static void Case2()
        {
            ushort s = 12345;
            byte b = (byte)s;
            Console.WriteLine($"转换前：{s} 转换后：{b} 类型：{b.GetType()}");
        }

        public static void Case1()
        {
            byte b = 10;
            short s = b;
            Console.WriteLine(s+"类型："+s.GetType()); //10类型：System.Int16

        }
    }
}