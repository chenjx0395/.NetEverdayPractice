using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace Exercise
{
    internal class Program
    {

        static void Main(string[] args)
        {


            // while 循环练习
            // Case1();
            // Case2();
            // Case3();
            // Case4();
            // Case5();
            // do-while 循环练习
            // Case6();
            // for 循环练习
            // Case7();
            // Case8();
            // Case9();
            // Case10();
            // Case11();
            // Case12();
            // Case13();
            // Case14();
            // Case15();
            // Case16();
            // Case17();
            // Case18();
            Case19();
        }

        public static void Case19()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("欢迎使用简易超市管理系统");
            Console.WriteLine("------------------------\n\n");

            while (true)
            {
                Console.WriteLine("请选择您的操作：");
                Console.WriteLine("\t1.录入商品");
                Console.WriteLine("\t2.查看商品");
                Console.WriteLine("\t3.退出系统");
                var readKey = Convert.ToInt32(Console.ReadLine());
                string shopName = null;
                double shopPrice = 0;
                switch (readKey)
                {
                    case 1:
                        var isAgain = true;
                        while (isAgain)
                        {
                            Console.WriteLine("\n请输入商品名称：");
                            shopName = Console.ReadLine();
                            Console.WriteLine("请输入商品价格：");
                            shopPrice = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("是否重新录入？y | n");
                            var readIsAgain = Console.ReadLine();
                            isAgain = readIsAgain.Equals("y") ? true : false;
                        }
                        break;
                    case 2:
                        Console.WriteLine($"\n商品名称：{shopName},商品价格：{shopPrice}");
                        break;
                    case 3:
                        Console.WriteLine("\n感谢使用，再见！");
                        break;
                    default:
                        Console.WriteLine("输入的操作编号不存在！");
                        break;
                }

                if (readKey == 3)
                {
                    break;
                }
            }
        }

        public static void Case18()
        {
            for (int i = 4; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(" ");
                }

                for (int j = 0; j < 5; j++)
                {
                    Console.Write("*   ");
                }

                Console.WriteLine();
            }
        }

        public static void Case17()
        {
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j}*{i}= {j * i}\t");
                }

                Console.WriteLine();
            }
        }

        public static void Case16()
        {
            var sum = 0;
            for (var i = 0; i < 100; i++)
            {
                if (i % 7 == 0) continue;
                sum += i;
            }

            Console.WriteLine(sum);
        }

        public static void Case15()
        {
            for (var i = 0; i < 100; i++)
            {
                if (i % 2 == 0) continue;
                Console.WriteLine(i);
            }
        }

        public static void Case14()
        {
            var sum = 0;
            for (var i = 1; ; i++)
            {
                var temp = Convert.ToInt32(Console.ReadLine());
                sum += temp;
                if (sum <= 200) continue;
                Console.WriteLine(i);
                break;
            }

        }

        public static void Case13()
        {
            var max = 0;
            while (true)
            {
                var temp = Convert.ToInt32(Console.ReadLine());
                if (temp == 886)
                {
                    Console.WriteLine("之前输入数的最大值：" + max);
                }
                max = temp > max ? temp : max;

            }
        }

        public static void Case12()
        {
            for (var i = 3; i > 0; i--)
            {
                Console.WriteLine("输入用户名和密码");
                var account = Console.ReadLine();
                var password = Console.ReadLine();
                if (account.Equals("admin") && password.Equals("88888"))
                {
                    Console.WriteLine("登录成功");
                    break;
                }

                Console.WriteLine("账号密码错误，请重新输入");
                if (i == 1)
                {
                    Console.WriteLine("锁定卡号");

                }
            }
        }

        public static void Case11()
        {
            while (true)
            {
                Console.WriteLine("输入用户名和密码");
                var account = Console.ReadLine();
                var password = Console.ReadLine();
                if (account.Equals("admin") && password.Equals("88888"))
                {
                    Console.WriteLine("登录成功");
                    break;
                }

                Console.WriteLine("账号密码错误，请重新输入");
            }
        }

        public static void Case10()
        {
            var sum = 0;
            for (var i = 0; i < 5; i++)
            {
                var age = Convert.ToInt32(Console.ReadLine());
                if (age < 0 || age > 100)
                {
                    Console.WriteLine("错误的输入，程序结束");
                    return;
                }
                sum += age;
            }

            Console.WriteLine(sum / 5.0);
        }

        public static void Case9()
        {
            for (var i = ""; i != null && !i.Equals("n"); i = Console.ReadLine())
            {
                Console.WriteLine("输入学生姓名，输入n结束。");
            }
        }

        public static void Case8()
        {
            Console.WriteLine("请输入一个整数：");
            var num = Convert.ToInt32(Console.ReadLine());
            var num2 = num;
            for (int i = 0; i <= num; i++)
            {
                Console.WriteLine($"{i}+{num2} = {i + num2}");
                num2--;
            }
        }

        public static void Case7()
        {
            for (var i = 1; i < 100; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void Case6()
        {
            var isExit = false;
            string shopName = null;
            double shopPrice = 0;
            do
            {
                Console.WriteLine("请选择您的操作：");
                Console.WriteLine("\t1.录入商品");
                Console.WriteLine("\t2.查看商品");
                Console.WriteLine("\t3.退出系统");
                var readKey = Convert.ToInt32(Console.ReadLine());
                switch (readKey)
                {
                    case 1:
                        Console.WriteLine("\n请输入商品名称：");
                        shopName = Console.ReadLine();
                        Console.WriteLine("\n请输入商品价格：");
                        shopPrice = Convert.ToDouble(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine($"商品名称：{(shopName == null ? "无" : shopName)},商品价格：{shopPrice}");
                        break;
                    case 3:
                        isExit = true;
                        Console.WriteLine("退出成功！欢迎再次使用！");
                        break;
                    default:
                        Console.WriteLine("没有此操作编号");
                        break;

                }
            } while (!isExit);
        }

        public static void Case5()
        {
            int i = 1;
            int sum = 0;
            while (i <= 100)
            {
                sum += i++;
            }

            Console.WriteLine(sum);
        }

        public static void Case4()
        {
            var message = "只能输入yes或者no";
            var input = message;
            while (!(input.Equals("yes") || input.Equals("no")))
            {
                Console.WriteLine(message);
                input = Console.ReadLine();
            }
        }

        public static void Case3()
        {
            Console.WriteLine("请输入班级人数：");
            var classCount = Convert.ToInt32(Console.ReadLine());
            var i = classCount;
            var sum = 0;
            while (i > 0)
            {
                Console.WriteLine($"请输入{i}号学生的成绩");
                sum += Convert.ToInt32(Console.ReadLine());
                i--;
            }
            Console.WriteLine($"总成绩为：{sum}");
            Console.WriteLine($"平均成绩为：{(sum * 1.0 / classCount):N2}");
        }

        public static void Case2()
        {
            var count = 3;
            while (count > 0)
            {

                Console.WriteLine("请输入用户名和密码");
                var account = Console.ReadLine();
                var password = Console.ReadLine();
                if (account.Equals("admin") && password.Equals("888888"))
                {
                    Console.WriteLine("登录成功");
                    count = int.MinValue;
                }
                else
                {
                    count--;
                    Console.WriteLine($"密码错误!你还有{count}次机会");
                }



            }
        }

        public static void Case1()
        {
            var i = 20;
            while (i > 0)
            {
                Console.WriteLine("HelloWorld");
                i--;
            }
        }
    }
}
