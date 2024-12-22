using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // 类的声明，对象的创建
            // Case1();
            // Case2();
            // Case3();
            // Case4();    
            // 综合案例
            Case5();

        }

        class Product
        {
            public int Id;
            public string Name;
            public double Price;
            public string Description;

            public Product()
            {
            }
            public Product(int id, string name, double price, string description)
            {
                this.Id = id;
                this.Name = name;
                this.Price = price;
                this.Description = description;
            }

        }

        private static void Case5()
        {
            var mySupermarket = new MySupermarket();
            mySupermarket.ShowMenu();
        }

        class MySupermarket
        {
            public Product[] Products = new Product[100];
            public int Count;

            public void ShowMenu()
            {
                while (true)
                {
                    Console.WriteLine("欢迎使用我的超市\n");
                    Console.WriteLine("请选择操作编号：");
                    Console.WriteLine("\t1.录入商品");
                    Console.WriteLine("\t2.查看商品");
                    Console.WriteLine("\t3.退出系统");
                    var readLine = Console.ReadLine();
                    switch (readLine)
                    {
                        case "1":
                            AddProduct();
                            break;
                        case "2":
                            ShowProduct();
                            break;
                        case "3":
                            return;
                    }
                }
            }

            public void AddProduct()
            {
                int id;
                Console.WriteLine("请输入商品编号");
                int.TryParse(Console.ReadLine(), out id);
                Console.WriteLine("请输入商品名称");
                var name = Console.ReadLine();
                Console.WriteLine("请输入商品价格");
                double.TryParse(Console.ReadLine(), out var price);
                Console.WriteLine("请输入商品描述");
                var description = Console.ReadLine();
                var product = new Product(id, name, price, description);
                Products[Count++] = product;

            }

            public void ShowProduct()
            {
                Console.WriteLine("\n查看商品操作");
                Console.WriteLine("商品编号\t商品名称\t商品价格\t商品描述");
                for (int i = 0; i < Count; i++)
                {
                    Console.WriteLine($"{Products[i].Id}\t\t{Products[i].Name}\t\t{Products[i].Price}\t\t{Products[i].Description}");

                }
            }
        }


        public static void Case4()
        {
            var huaWei = new Phone
            {
                Price = 7999,
                Color = "黑色",
                Storage = "512GB",
                Name = "华为手机"
            };

            var iPhone = new Phone
            {
                Price = 8999,
                Color = "白色",
                Storage = "256GB",
                Name = "苹果手机"
            };

            var xiaoMi = new Phone
            {
                Price = 5999,
                Color = "蓝色",
                Storage = "1TB",
                Name = "小米手机"
            };
            huaWei.Call();
            iPhone.SendMessage();
            xiaoMi.PlayGame();
        }

        public static void Case3()
        {
            var person = new Person()
            {
                Name = "光头强",
                Age = 32,
                Address = "北京昌平",
                Sex = '男',
                PhoneNum = "123456"
            };
            person.Eat();
        }

        public static void Case2()
        {
            var huaWei = new Phone
            {
                Price = 7999,
                Color = "黑色",
                Storage = "512GB",
                Name = "华为手机"
            };

            var iPhone = new Phone
            {
                Price = 8999,
                Color = "白色",
                Storage = "256GB",
                Name = "苹果手机"
            };

            var xiaoMi = new Phone
            {
                Price = 5999,
                Color = "蓝色",
                Storage = "1TB",
                Name = "小米手机"
            };
            Console.WriteLine(huaWei.Price + "," + huaWei.Color + "," + huaWei.Storage + "," + huaWei.Name);
            Console.WriteLine(iPhone.Price + "," + iPhone.Color + "," + iPhone.Storage + "," + iPhone.Name);
            Console.WriteLine(xiaoMi.Price + "," + xiaoMi.Color + "," + xiaoMi.Storage + "," + xiaoMi.Name);
        }

        public static void Case1()
        {
            Person p1 = new Person();
            p1.Name = "李嘉明";
            p1.Age = 18;
            p1.Address = "岳阳市";
            p1.Sex = '男';
            p1.PhoneNum = "12881239187";
            Console.WriteLine(p1);
        }

        class Person
        {
            public string Name;
            public int Age;
            public string Address;
            public char Sex;
            public string PhoneNum;

            public void Eat()
            {
                Console.WriteLine($"{Name}，{Age}岁，{Address},{Sex},{PhoneNum} 喜欢吃");
            }
        }

        class Phone
        {


            public string Name;
            public double Price;
            public string Color;
            public string Storage;

            public void Call()
            {
                Console.WriteLine($"使用{Price}，{Color}，{Storage}的{Name}打电话");
            }
            public void SendMessage()
            {
                Console.WriteLine($"使用{Price}，{Color}，{Storage}的{Name}发信息");
            }
            public void PlayGame()
            {
                Console.WriteLine($"使用{Price}，{Color}，{Storage}的{Name}玩游戏");
            }

        }

    }
}
