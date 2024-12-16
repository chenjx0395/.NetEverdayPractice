using System;
using System.IO;

namespace Exercise
{
    internal class Program
    {



        private static void Main(string[] args)
        {
            // 三元表达式的练习
            // Case5();
            // Case6();
            // Case7();
            // Case8();
            // 常量练习
            // Case9();
            // 枚举类型
            // Case10();
            // 结构体练习
            // Case11();
            // 数组练习
            // Case12();
            // Case13();
            // 综合练习
            Case14();
        }

        private struct Shop
        {
            private string _shopNameValue;
            private double _shopPriceValue;
            public string ShopName
            {
                get => _shopNameValue;
                set => _shopNameValue = value;
            }
            public double ShopPrice
            {
                get => _shopPriceValue;
                set => _shopPriceValue = value;
            }
        }

        public static void Case14()
        {
            Console.WriteLine("欢迎使用简易超市管理系统");
            Console.WriteLine("------------------------\n");

            var isExit = false;
            var shopList = new Shop[3];
            var nowShopNumber = 0;
            while (!isExit)
            {
                Console.WriteLine("\n请选择您的操作：");
                Console.WriteLine("\t1.录入商品");
                Console.WriteLine("\t2.查看商品");
                Console.WriteLine("\t3.退出系统");
                var readKey = Convert.ToInt32(Console.ReadLine());
                switch (readKey)
                {
                    case 1:
                        var isAgain = true;
                        // 可重复添加
                        while (isAgain)
                        {
                            // 商品数组满后不允许添加
                            if (nowShopNumber == shopList.Length)
                            {
                                Console.WriteLine("商品列表已满，无法继续录入");
                                break;
                            }
                            // 商品输入
                            Console.WriteLine("请输入商品名称：");
                            var readShopName = Console.ReadLine();
                            shopList[nowShopNumber].ShopName = readShopName;
                            Console.WriteLine("请输入商品价格：");
                            var readShopPrice = Convert.ToDouble(Console.ReadLine());
                            shopList[nowShopNumber].ShopPrice = readShopPrice;
                            nowShopNumber++;
                            // 加入异常符号判断
                            while (true)
                            {
                                Console.WriteLine("是否继续录入？y | n");
                                var readIsOk = Console.ReadKey();
                                Console.WriteLine();
                                if (readIsOk.KeyChar == 'y') break;
                                if (readIsOk.KeyChar == 'n')
                                {
                                    isAgain = false;
                                    break;
                                }
                                Console.WriteLine("错误操作编号不存在！，请重新选择");
                            }
                        }
                        break;
                    case 2:
                        // 遍历展示商品数组
                        Console.WriteLine("商品名称\t商品价格");
                        foreach (var shop in shopList)
                        {
                            Console.WriteLine(shop.ShopName + "\t" + shop.ShopPrice);
                        }
                        break;
                    case 3:
                        Console.WriteLine("感谢使用，再见！");
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("输入操作编号不存在！");
                        break;

                }
            }

        }

        public static void Case13()
        {
            int[] arr = { 1, 8, 9, 7, 4, 0, 5, 2, 3 };
            int[] index = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 2, 0 };
            var tel = "";
            foreach (var i in index)
            {
                tel += arr[i];
            }

            Console.WriteLine(tel);
        }

        public static void Case12()
        {
            var nums = new int[5];
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"请输入第 {i + 1} 个数字");
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }
            var sum = 0;
            Console.Write("5个数字为：");
            foreach (var num in nums)
            {
                sum += num;
                Console.Write(num + "，");
            }
            Console.WriteLine($"\n5个数字和为：{sum}");
            Console.WriteLine($"5个数字平均数为：{sum / (double)nums.Length}");

        }

        public static void Case11()
        {
            var person01 = new Person("张三", Sex.男, 18);
            var person02 = new Person("小兰", Sex.女, 16);
            Console.WriteLine(person01);
        }

        private enum Sex
        {
            男,
            女
        }

        private struct Person
        {
            public string Name;
            public Sex Sex;
            public int Age;

            public Person(string name, Sex sex, int age)
            {
                Name = name;
                Sex = sex;
                Age = age;
            }
        }

        private enum Weather
        {
            Spring,
            Summer,
            Fall,
            Winter
        }

        public static void Case10()
        {
            Console.WriteLine(Weather.Spring);
            Console.WriteLine(Weather.Summer);
            Console.WriteLine(Weather.Fall);
            Console.WriteLine((int)Weather.Winter);
        }

        public static void Case9()
        {
            const int day = 365;
            const int week = 52;
            const int month = 12;
            Console.WriteLine($"一年有{day}天，{week}周, {month}月");
        }

        public static void Case8()
        {
            var num1 = Convert.ToInt32(Console.ReadLine());
            var num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num1 >= num2 ? num1 == num2 ? "等于" : "大于" : "小于");
        }

        public static void Case7()
        {
            var num1 = Convert.ToInt32(Console.ReadLine());
            var num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num1 > num2 ? num1 : num2);
        }

        public static void Case6()
        {
            var mathScore = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(mathScore % 2 == 0 ? "偶数" : "奇数");
        }
        public static void Case5()
        {
            var mathScore = Convert.ToInt32(Console.ReadLine());
            var result = mathScore > 60 ? "及格" : "不及格";
            Console.WriteLine(result);
        }


        // 结构体定义
        struct MyStruct
        {
            public static string name = "cjx";
        }

        // TryParse 方法的使用
        public static void Case4()
        {
            int outNum;
            // var tarStr = "123";
            var tarStr = "qwe";
            var tryParse = int.TryParse(tarStr, out outNum);
            if (tryParse)
            {
                Console.WriteLine("成功转换");
            }
            else
            {
                Console.WriteLine("转换失败");
            }
            Console.WriteLine(outNum);

        }

        // 值类型初始化
        public static void Case3()
        {
            // 对于预定义的值类型，如果使用默认构造函数创建，默认构造函数会给其成员赋初始值
            var d = new int();
            int e;
            Console.WriteLine(d);
            // 如果不使用构造函数创建，则没有初始值，编译器会产生错误
            // Console.WriteLine(e);
            d = 30;
        }

        // 条件逻辑运算符 和 逻辑运算符的 区别
        public static void Case2()
        {

            // var isBool = true;
            // Console.WriteLine(Convert.ToInt32(isBool));

            var a = 10;
            var b = 10;
            var c = 30;
            if (true || b++ < c)
            {
                Console.WriteLine(b);
            }

            if (true & a++ < b)
            {
                Console.WriteLine(a);
            }
        }

        public static void Case1()
        {
            // using 语句第一种用法
            /*using (TextWriter f =  File.CreateText("hello.txt"))
             {
                 f.WriteLine("天气不错");
             }*/
            // using 语句第二种用法
            TextWriter f = File.CreateText("hello.txt");
            using (f)
            {
                f.WriteLine("天气不错");
            }
            f.WriteLine("错误啦"); // f 资源已被using语句回收，此操作会导致异常
        }
    }
}
