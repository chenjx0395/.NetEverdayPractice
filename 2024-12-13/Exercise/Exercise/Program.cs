using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 输入练习
            // Case1();
            // Case2();
            // 格式转换练习
            // Case3();
            // Case4();
            // 逻辑运算符练习
            // Case5();
            // Case6();
            // 分支结构练习
            // Case7();
            // Case8();
            // Case9();
            // Case10();
            // if-else 练习
            // Case11();
            // Case12();
            // Case13();
            // Case14();
            // 嵌套if-else练习
            // Case15();
            // Case16();
            // Case17();
            // Case18();
            // switch练习
            // Case19();
            Case20();
        }


        public static void Case20()
        {
            Console.WriteLine("----欢迎使用----");
            Console.WriteLine("请输入您的操作编号：");
            Console.WriteLine("\t1.登录");
            Console.WriteLine("\t2.注册");
            var key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    Console.WriteLine("您的选择为：登录");
                    break;
                case 2:
                    Console.WriteLine("您的选择为；注册");
                    break;
                default:
                    Console.WriteLine("输入的操作编号不存在");
                    break;
            }
        }

        public static void Case19()
        {
            Console.WriteLine("输入月份：");
            var month = Console.ReadLine();
            switch (month)
            {
                case "3月":
                case "4月":
                case "5月":
                    Console.WriteLine("春季");
                    break;
                case "6月":
                case "7月":
                case "8月":
                    Console.WriteLine("夏季");
                    break;
                case "9月":
                case "10月":
                case "11月":
                    Console.WriteLine("秋季");
                    break;
                case "12月":
                case "1月":
                case "2月":
                    Console.WriteLine("冬季");
                    break;
            }
        }

        public static void Case18()
        {
            Console.WriteLine("请输入年龄：");
            var age = Convert.ToInt32(Console.ReadLine());
            if (age >= 18)
            {
                Console.WriteLine("可以查看");
            }
            else
            {
                if (age > 10)
                {
                    Console.WriteLine("是否继续查看（yes/no）");
                    var isWatch = Console.ReadLine();
                    if (isWatch.Equals("yes"))
                    {
                        Console.WriteLine("查看");
                    }
                    else
                    {
                        Console.WriteLine("退出，放弃查看");
                    }

                }
                else
                {
                    Console.WriteLine("不允许查看");
                }
            }
        }

        public static void Case17()
        {
            Console.WriteLine("请输入用户名");
            var account = Console.ReadLine();
            Console.WriteLine("输入密码：");
            var password = Console.ReadLine();
            if (account.Equals("admin"))
            {
                if (password.Equals("88888"))
                {
                    Console.WriteLine("登录成功！");
                }
                else
                {
                    Console.WriteLine("密码错误");
                }

            }
            else
            {
                Console.WriteLine("用户名不存在！");
            }
        }

        public static void Case16()
        {
            Console.WriteLine("请输入密码：");
            var password = Console.ReadLine();
            if (password.Equals("88888"))
            {
                Console.WriteLine("密码正确");
            }
            else
            {
                Console.WriteLine("还有一次输入机会");
                password = Console.ReadLine();
                if (password.Equals("88888"))
                {
                    Console.WriteLine("密码正确");

                }
            }
        }

        public static void Case15()
        {
            Console.WriteLine("输入语文成绩：");
            var chineseScore = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入数学成绩：");
            var mathScore = Convert.ToInt32(Console.ReadLine());
            if (mathScore > chineseScore)
            {
                Console.WriteLine("数学成绩更好");
            }
            else if (mathScore < chineseScore)
            {
                Console.WriteLine("数学成绩没有语文成绩好");
            }
            else
            {
                Console.WriteLine("数学成绩和语文成绩一样好");
            }
        }

        public static void Case14()
        {
            Console.WriteLine("输入学生的考试成绩：");
            var studentScore = Convert.ToInt32(Console.ReadLine());
            if (studentScore >= 90)
            {
                Console.WriteLine("学生成绩评选为：A");
            }
            else if (studentScore >= 80)
            {
                Console.WriteLine("学生成绩评选为：B");
            }
            else if (studentScore >= 70)
            {
                Console.WriteLine("学生成绩评选为：C");
            }
            else if (studentScore >= 60)
            {
                Console.WriteLine("学生成绩评选为：D");
            }
            else
            {
                Console.WriteLine("学生成绩评选为：E");
            }
        }

        public static void Case13()
        {
            Console.WriteLine("输入a");
            var a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入b");
            var b = Convert.ToInt32(Console.ReadLine());
            if (a % b == 0)
            {
                Console.WriteLine(a);
            }
            else if (a + b > 100)
            {
                Console.WriteLine(b);
            }
        }

        public static void Case12()
        {
            var badEggs = new Random().Next(1, 11);
            Console.WriteLine("坏鸡蛋数" + badEggs);
            if (badEggs < 5)
            {
                Console.WriteLine("吃掉");
            }
            else
            {
                Console.WriteLine("退货");
            }
        }

        public static void Case11()
        {
            Console.WriteLine("输入语文成绩：");
            var chineseScore = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入数学成绩：");
            var mathScore = Convert.ToInt32(Console.ReadLine());
            if (mathScore > chineseScore)
            {
                Console.WriteLine("数学成绩更好");
            }
            else
            {
                Console.WriteLine("数学成绩没有语文成绩好");
            }
        }

        public static void Case10()
        {
            Console.WriteLine("请输入用户名");
            var account = Console.ReadLine();
            Console.WriteLine("输入密码：");
            var password = Console.ReadLine();
            if (account.Equals("admin") && password.Equals("mypass"))
            {
                Console.WriteLine("登录成功！");

            }
        }

        public static void Case9()
        {
            Console.WriteLine("输入语文成绩：");
            var chineseScore = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入音乐成绩：");
            var musicScore = Convert.ToInt32(Console.ReadLine());
            if ((chineseScore > 90 && musicScore > 80) || (chineseScore == 100 && musicScore > 70))
            {
                Console.WriteLine("奖励100元");
            }
        }

        public static void Case8()
        {
            Console.WriteLine("请输入年龄：");
            var age = Convert.ToInt32(Console.ReadLine());
            if (age >= 23)
            {
                Console.WriteLine("该结婚了");
            }
        }

        public static void Case7()
        {
            Console.WriteLine("输入语文成绩：");
            var chineseScore = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入数学成绩：");
            var mathScore = Convert.ToInt32(Console.ReadLine());
            if (mathScore > chineseScore)
            {
                Console.WriteLine("数学成绩更好");
            }
        }

        public static void Case6()
        {
            Console.WriteLine("请输入一个年份");
            var year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(year % 400 == 0 || (year % 4 == 0 && year % 100 != 0));
        }

        public static void Case5()
        {
            Console.WriteLine("输入语文成绩：");
            var chineseScore = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入数学成绩：");
            var mathScore = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(chineseScore > 90 && mathScore > 90);
            Console.WriteLine(chineseScore > 90 || mathScore > 90);
        }

        public static void Case4()
        {
            Console.WriteLine("请输入秒数:");
            var second = Convert.ToInt32(Console.ReadLine());
            var minute = second / 60;
            second %= 60;
            var hour = minute / 60;
            minute %= 60;
            var day = hour / 24;
            hour %= 24;
            Console.WriteLine($"输入秒数转换成{day}天{hour}小时{minute}分钟{second}秒");


        }



        public static void Case3()
        {
            Console.WriteLine("请输入姓名：");
            var name = Console.ReadLine();
            Console.WriteLine("\n请输入语文成绩：");
            var chineseScore = Console.ReadLine();
            Console.WriteLine("\n请输入数学成绩：");
            var mathScore = Console.ReadLine();
            Console.WriteLine("\n请输入英语成绩：");
            var englishScore = Console.ReadLine();
            var allScore = Convert.ToDouble(chineseScore) + Convert.ToDouble(mathScore) + Convert.ToDouble(englishScore);
            var averageScore = allScore / 3;
            Console.WriteLine($"\n您好 {name} 您的总成绩为：{allScore}。您的平均成绩为：{averageScore}");

        }

        public static void Case2()
        {
            Console.WriteLine("请输入姓名：");
            var name = Console.ReadLine();
            Console.WriteLine("请输入年龄：");
            var age = Console.ReadLine();
            Console.WriteLine("请输入生日：");
            var birthday = Console.ReadLine();
            Console.WriteLine("请输入地址：");
            var address = Console.ReadLine();
            Console.WriteLine("{0} 您的年龄是{1},生日为{2},地址为{3}", name, age, birthday, address);
        }

        public static void Case1()
        {
            Console.WriteLine("你喜欢的男生类型是什么？");
            var read = Console.ReadLine();
            Console.WriteLine($"哈，这么巧，我就是你说的{read}类型");

        }
    }
}
