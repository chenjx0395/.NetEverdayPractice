using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDay01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 输出到控制台练习
            // Case1();
            // 变量声明练习
            // Case2();
            // 整形练习
            Case3();
        }

        private static void Case1()
        {
            Console.WriteLine("********************************");
            Console.Write("*   ");
            Console.Write("这是我的第一个C#应用程序");
            Console.Write("   *");
            Console.WriteLine();
            Console.WriteLine("********************************");
        }

        public static void Case2()
        {
            //定义一个int类型变量存95，输出到控制台？
            int a1 = 95;
            Console.WriteLine(a1);
            //有个同学姓名张三，18，身高175.3 ，电话：123456789，性别true。请将张三的信息存储到变量中，并输出到控制台？
            string name = "张三";
            double height = 175.3;
            string phone = "123456789";
            bool sex = true;
            Console.WriteLine($"姓名={name}，身高={height}，电话={phone}，性别={sex}，");
            //光头强跟自己的新女友说自己刚满18，后来发现光头强骗人，其实已经81了。
            //打印光头强自己说的年龄和真实的年龄，使用一个变量的重新赋值完成。
            int age = 18;
            Console.WriteLine("光头强的假年纪"+age);
            age = 81;
            Console.WriteLine("光头强的真年纪"+age);

        }

        public static void Case3()
        {
            //1.定义两个数分别为100和20，打印出两个数的和，平均数？
            int a1 = 100;
            int a2 = 20;
            Console.WriteLine(a1 + a2);
            Console.WriteLine((a1 + a2) / 2);
            //2.计算半径为5的圆的面积和周长并打印出来。（pi为3.14）面积：`pi*r*r`。
            int r = 5;
            double pi = 3.14;
            Console.WriteLine(pi*r*r);
            Console.WriteLine(2*pi*r);
            //3.某商店T恤(T-shirt)的价格为35元/件，裤子(trousers)的价格为120元/条。
            //小明在该店买了3件T恤和2条裤子，请计算并显示小明应该付多少钱？打8.8折后呢？
            double tsP = 35;
            double tP = 120;
            Console.WriteLine(3*tsP + 2*tP);
            Console.WriteLine((3 * tsP + 2 * tP) * 0.88);
        }

    }
}
