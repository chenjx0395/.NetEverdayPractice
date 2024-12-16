using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Program
    {

        
        struct MyStruct
        {
            public static string name = "cjx";
        }

        static void Main(string[] args)
        {

            int outNum;
            // var tarStr = "123";
            var tarStr = "qwe";
            var tryParse = int.TryParse(tarStr,out outNum);
            if (tryParse)
            {
                Console.WriteLine("成功转换");
            }
            else
            {
                Console.WriteLine("转换失败");
            }
            Console.WriteLine(outNum);

            // var isBool = true;
            // Console.WriteLine(Convert.ToInt32(isBool));

            // var a = 10;
            // var b = 10;
            // var c = 30;
            // 对于预定义的值类型，如果使用默认构造函数创建，默认构造函数会给其成员赋初始值
            // var d = new int();
            // int e;
            // Console.WriteLine(d);
            // 如果不使用构造函数创建，则咩有初始值，编译器会产生错误
            // Console.WriteLine(e);
            // d = 30;

            // if (true || b++ < c)
            // {
            //     Console.WriteLine(b);
            // }
            //
            // if (true & a++ < b)
            // {
            //     Console.WriteLine(a);
            // }

            // using 语句第一种用法
            /*using (TextWriter f =  File.CreateText("hello.txt"))
             {
                 f.WriteLine("天气不错");
             }*/
            // using 语句第二种用法
            // TextWriter f = File.CreateText("hello.txt");
            // using (f)
            // {
            //     f.WriteLine("天气不错");
            // }
            // f.WriteLine("错误啦"); // f 资源已被using语句回收，此操作会导致异常
        }
    }
}
