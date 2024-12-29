using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace Exercise
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 使用GZipStream 压缩文件
            // Case1();
            // 使用GZipStream 解压文件
            // Case2();
            // 二进制序列化
            // Case3();
            // 二进制反序列化
            // Case4();
            // 文件与IO案例
            // Case5();
            // ArrayList API练习
            // Case6();
            // ArrayList 练习1
            // Case7();
            // ArrayList 练习2
            Case8();
            
            
        }

        public static void Case8()
        {
            var chars1 = new []{'a','b','c','e','f','g'};
            var chars2 = new []{'e','f','g','h','i','j','k'};
            var arrayList = new ArrayList(chars1);
            foreach (var c in chars2)
            {
                if (arrayList.Contains(c))
                {
                    continue;
                }

                arrayList.Add(c);
            }
            foreach (var o in arrayList)
            {
                Console.WriteLine(o);
            }
            
        }

        public static void Case7()
        {
            var source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var odd = new ArrayList();
            var even = new ArrayList();
            foreach (var val in source)
            {
                if (val % 2 == 0)
                {
                    even.Add(val);
                }
                else
                {
                    odd.Add(val);
                }
            }
            odd.AddRange(even);
            foreach (var o in odd)
            {
                Console.WriteLine(o);
            }
        }


        public static void Case6()
        {
            var list = new ArrayList();
            // 添加元素
            list.Add("小明");
            list.Add(22);
            list.Add(176.4);
            list.Add(new DateTime(1999, 1, 1));
            // 获取元素
            foreach (var val in list)
            {
                Console.WriteLine(val);
            }

            // 添加集合
            var add = new ArrayList
            {
                "小黑",
                18
            };
            list.AddRange(add);
            // 判断集合中是否有元素
            var exist = list.Contains("小黑");
            Console.WriteLine(exist); // true

            // 移除指定元素
            list.Remove("小黑");
            // 根据索引移除元素
            list.RemoveAt(list.Count - 1);
            // 反转元素
            list.Reverse();
            // 查找元素
            var indexOf = list.IndexOf("小明");
            Console.WriteLine(indexOf); // 3
        }

        /*
            1. 注册，登录功能。
            2. 用户只能注册一个账号。
            3. 使用已经注册的用户名和密码登录，提示登录成功。
                1. 只要用户完成了注册，即使程序重新启动，用户依然可以直接登录成功。
         */
        public static void Case5()
        {
            MySystem.ShowMenu();
        }

        // 系统类
        private static class MySystem
        {
            private static User _user;
            private const string Path = @"D://user";

            // 展示菜单
            public static void ShowMenu()
            {
                while (true)
                {
                    Console.WriteLine("***欢迎用户中心系统***");
                    Console.WriteLine("输入下列功能符号执行功能!");
                    Console.WriteLine("1.注册");
                    Console.WriteLine("2.登录");
                    Console.WriteLine("3.退出");
                    var readLine = Console.ReadLine();
                    switch (readLine)
                    {
                        case "1":
                            Register();
                            break;
                        case "2":
                            Login();
                            break;
                        case "3":
                            Console.WriteLine("欢迎下次使用!");
                            return;
                        default:
                            Console.WriteLine("输入错误，请重新输入！");
                            break;
                    }
                }
            }

            // 注册方法
            private static void Register()
            {
                // 不能二次注册
                if (_user != null)
                {
                    Console.WriteLine("不允许重复注册");
                    return;
                }
                else
                {
                    // 判断本地路径是否存在用户信息
                    if (File.Exists(Path))
                    {
                        using (var fs = new FileStream(Path, FileMode.Open))
                        {
                            try
                            {
                                _user = (User)new BinaryFormatter().Deserialize(fs);
                                Console.WriteLine(_user);
                                Console.WriteLine("不允许重复注册");
                                return;
                            }
                            catch (Exception)
                            {
                                // 代表本地文件存储的不是User信息
                                Console.WriteLine("用户信息存储文件被破坏,请删除文件后重试!");
                                return;
                            }
                        }
                    }
                }

                _user = new User();
                // 代表不是二次注册
                Console.WriteLine("请输入账号:");
                _user.Username = Console.ReadLine();
                Console.WriteLine("请输入密码:");
                _user.Password = Console.ReadLine();
                Console.WriteLine("注册成功!,将为您持久化账号信息");
                using (var fs = new FileStream(@"D://user", FileMode.Create))
                {
                    new BinaryFormatter().Serialize(fs, _user);
                }
            }

            // 登录方法
            private static void Login()
            {
                // 如果没注册过,不允许登录
                if (_user == null)
                {
                    // 读取本地用户账号信息
                    if (File.Exists(Path))
                    {
                        using (var fs = new FileStream(Path, FileMode.Open))
                        {
                            _user = (User)new BinaryFormatter().Deserialize(fs);
                        }
                    }
                    else
                    {
                        Console.WriteLine("请注册后登录!");
                        return;
                    }
                }

                var temp = new User();
                // 代表不是二次注册
                Console.WriteLine("请输入账号:");
                temp.Username = Console.ReadLine();
                Console.WriteLine("请输入密码:");
                temp.Password = Console.ReadLine();
                if (temp.Username == _user.Username && temp.Password == _user.Password)
                {
                    Console.WriteLine("登录成功!");
                }
                else
                {
                    Console.WriteLine("登录失败!用户名或密码错误!");
                }
            }
        }

        // 用户类
        [Serializable]
        private class User
        {
            public string Username { get; set; }
            public string Password { get; set; }

            public User()
            {
            }

            public User(string username, string password)
            {
                Username = username;
                Password = password;
            }

            public override string ToString()
            {
                return $"{Username}--{Password}";
            }
        }


        public static void Case4()
        {
            const string path = @"D://person文件";
            using (var fs = new FileStream(path, FileMode.Open))
            {
                var bf = new BinaryFormatter();
                var person = (Person)bf.Deserialize(fs);
                Console.WriteLine(person);
            }
        }

        public static void Case3()
        {
            const string path = @"D://person文件";
            var person = new Person()
            {
                Name = "张三",
                Age = 18
            };
            using (var fs = new FileStream(path, FileMode.Create))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, person);
            }
        }

        [Serializable]
        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {
                return $"{Name}--{Age}";
            }
        }

        public static void Case2()
        {
            const string readPath = "D:\\压缩视频.gzip";
            const string writePath = "D:\\解压视频.mp4";
            //1.定义读取流
            using (var fsr = new FileStream(readPath, FileMode.OpenOrCreate))
            {
                //2.定义写入流
                using (var fsw = new FileStream(writePath, FileMode.OpenOrCreate))
                {
                    //3.定义压缩流
                    using (var gzs = new GZipStream(fsr, CompressionMode.Decompress))
                    {
                        var buffer = new byte[1024];
                        int length;
                        // 通过GZipStream来读取数据
                        while ((length = gzs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            //通过输出流输出到指定文件中
                            fsw.Write(buffer, 0, length);
                        }
                    }
                }
            }
        }

        public static void Case1()
        {
            const string readPath = "D:\\5.2. [作业讲解]函数语法【itjc8.com】.mp4";
            const string writePath = "D:\\压缩视频.gzip";
            //1.定义读取流
            using (var fsr = new FileStream(readPath, FileMode.OpenOrCreate))
            {
                //2.定义写入流
                using (var fsw = new FileStream(writePath, FileMode.OpenOrCreate))
                {
                    //3.定义压缩流
                    using (var gzs = new GZipStream(fsw, CompressionMode.Compress))
                    {
                        var buffer = new byte[1024];
                        int length;
                        // 通过while循环读取文件内容，并写入压缩流中
                        while ((length = fsr.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            //压缩后通过输入流输入到指定文件中
                            gzs.Write(buffer, 0, length);
                        }
                    }
                }
            }
        }
    }
}