using System;
using System.Text;

namespace Exercise
{
    public static class Util
    {
        /*public static double Sub( A a)
        {
            return a.X - a.Y;
        }*/
        public static double Sub(this A a)
        {
            return a.X - a.Y;
        }
    }

    public sealed class A
    {
        public double X;
        public double Y;

        public A(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Sum()
        {
            return X + Y;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            // 指定接口成员实现
            // Case1();
            // 显式构造函数调用
            // Case2();
            // 构造函数公共逻辑抽离案例
            // Case3();
            // 扩展方法
            // Case4();
            // 练习String常见API
            // Case5();
            // 演示StringBuilder 常见API
            // Case6();
            // 值类型和引用类型的比较
            // Case7();
            // 综合案例
            Case8();
        }

        public static void Case8()
        {
            string name = null, password = null;
            while (true)
            {
                Console.WriteLine("---欢迎使用---");
                Console.WriteLine("\n请选择您的操作：");
                Console.WriteLine("\t1.注册");
                Console.WriteLine("\t2.登录");
                Console.WriteLine("\t3.退出系统");
                int int32;
                while (true)
                {
                    var input = Console.ReadLine();
                    try
                    {
                        int32 = Convert.ToInt32(input);
                        break;
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("输入有误，请重新输入");
                        Console.ResetColor();
                    }
                }

                switch (int32)
                {
                    case 1:
                        Console.WriteLine("请输入用户名");
                        name = Console.ReadLine();
                        Console.WriteLine("请输入密码");
                        password = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("请输入用户名");
                            
                        var tempName = Console.ReadLine();
                        Console.WriteLine("请输入密码");
                        var tempPassword = Console.ReadLine();
                       
                        if (name == tempName && password == tempPassword)
                        {
                            Console.WriteLine("登录成功");
                        }
                        else
                        {
                            Console.WriteLine("登录失败");
                        }
                        break; 
                    case 3 :
                        Console.WriteLine("欢迎下次使用");
                        return;
                    default:
                        Console.WriteLine("输入有误，请重新输入");
                        break;
                }
            }
        }

        public static void Case7()
        {
            var a = 10;
            var b = 10;
            Console.WriteLine(a == b); // true
            var c = false;
            var d = false;
            Console.WriteLine(c == d); // true

            var random1 = new Random();
            var random2 = new Random();
            Console.WriteLine(random1 == random2); //False

            var random3 = new Random();
            var random4 = new Random();
            Console.WriteLine(ReferenceEquals(random3, random4)); //False

            var s1 = "aaaaa";
            var s2 = new string('a', 5);
            Console.WriteLine(s1.Equals(s2)); // true
        }

        public static void Case6()
        {
            //1. Append(string value) 字符串拼接
            var sb = new StringBuilder();
            sb.Append("hello");
            sb.Append("world");
            Console.WriteLine(sb); //helloworld
            //2. Insert(int index,string value) 在指定位置插入字符串
            sb.Insert(3, "world");
            Console.WriteLine(sb); //helworldloworld
            //3. Remove(int startIndex,int lenght) 删除指定位置的字符串
            sb.Remove(3, 5);
            Console.WriteLine(sb); //helloworld
            //4. Replace(string oldValue,string newValue) 替换字符串
            sb.Replace("world", "hello");
            Console.WriteLine(sb); //hellohello
            //5. string ToString()  转换成字符串
            Console.WriteLine(sb.ToString()); // hellohello
        }

        public static void Case5()
        {
            // 1. Concat 连接字符串
            var s1 = "hello";
            var s2 = "world";
            var concat = string.Concat(s1, s2);
            Console.WriteLine(concat); //helloworld
            // 2. Join 分隔字符数组
            var array = new[] { "a", "b", "c" };
            var join = string.Join("~", array);
            Console.WriteLine(join); //a~b~c
            // 3. IsNullOrEmpty 判断字符串是否为空 null 和 “” 空字符串都为空
            var s3 = "";
            var isNullOrEmpty = string.IsNullOrEmpty(s3);
            Console.WriteLine(isNullOrEmpty); // true
            // 4. IsNullOrWhiteSpace 判断字符串是否为空或空格
            var s4 = "  ";
            var isNullOrWhiteSpace = string.IsNullOrWhiteSpace(s4);
            Console.WriteLine(isNullOrWhiteSpace); // true
            // 5. Contains 判断字符串是否包含某个子串
            var s5 = "hello world";
            var contains = s5.Contains("llo");
            Console.WriteLine(contains); // true
            // 6. IndexOf 查找字符串中某个子串的位置
            var s6 = "hello world";
            var indexOf = s6.IndexOf("llo");
            Console.WriteLine(indexOf); // 2
            // 7. Split 分割字符串 默认以空格分割 
            var s7 = "hello world";
            var s8 = "hello|world";
            var split1 = s7.Split();
            var split2 = s8.Split('|');
            Console.WriteLine(split1[0]); // hello
            Console.WriteLine(split2[1]); // world
            // 8. Substring(int startIndex,int lenght) 截取字符串,从指定位置开始截取指定长度的字符串
            var s9 = "hello world";
            var substring = s9.Substring(0, 5);
            Console.WriteLine(substring); // hello
            // Substring(int startIndex) 截取字符串,从指定位置开始截取到字符串末尾
            var substring2 = s9.Substring(6);
            Console.WriteLine(substring2); //world
            // 9. ToLowerCase 转小写 , ToUpperCase 转大写
            var s10 = "HELLO WORLD";
            var toLowerCase = s10.ToLower();
            Console.WriteLine(toLowerCase); // hello world
            var toUpperCase = toLowerCase.ToUpper();
            Console.WriteLine(toUpperCase); // HELLO WORLD
            // 10. Trim 去除字符串首尾空格
            var s11 = "  hello world  ";
            var trim = s11.Trim();
            Console.WriteLine(trim); // hello world
            // 11. String(char [] value) 构造方法，将字符数组转换成字符串
            var chars = new char[] { 'a', 'b', 'c' };
            var string1 = new String(chars);
            Console.WriteLine(string1); // abc
        }

        public static void Case4()
        {
            var a = new A(1, 2);
            Console.WriteLine(a.Sum());
            // 通过静态工具类调用扩展的方法
            Console.WriteLine(Util.Sub(a));
            // 通过实例调用扩展的方法
            Console.WriteLine(a.Sub());
        }


        public static void Case3()
        {
            var class1 = new MyClass2("周磊乐");
            var class2 = new MyClass2(18);
            Console.WriteLine($"国家：{class1.Country},人种：{class1.race}");
            Console.WriteLine($"国家：{class2.Country},人种：{class2.race}");
        }

        private class MyClass2
        {
            public readonly string Country;
            public readonly string race;

            private string _name;
            private int _age;

            public MyClass2()
            {
                // 模拟构造函数的通用逻辑
                Country = "中国";
                race = "亚洲人";
            }

            public MyClass2(string name) : this()
            {
                this._name = name;
            }

            public MyClass2(int age) : this()
            {
                this._age = age;
            }
        }


        public static void Case2()
        {
            var derived = new Derived("周磊乐");
            Console.WriteLine($"父亲:{derived.Father},儿子:{derived.Son}");
        }

        private class Derived : Base1
        {
            public string Son;

            public Derived() : base("陈嘉鑫")
            {
                Console.WriteLine("子类空参构造方法执行了~");
            }

            public Derived(string son) : this()
            {
                Console.WriteLine("子类有参构造方法执行了~");
                this.Son = son;
            }
        }

        private class Base1
        {
            public string Father;

            public Base1()
            {
                Console.WriteLine("父类空参构造方法执行了~");
            }

            public Base1(string father) : this()
            {
                Console.WriteLine("父类有参构造方法执行了~");
                this.Father = father;
            }
        }

        public static void Case1()
        {
            var myClass = new MyClass();
            // myClass.Say() 编译报错
            // 可以自己声明一个类引用的同名方法
            IIfc1 i1 = myClass;
            i1.Say();
            IIfc2 i2 = myClass;
            i2.Say();
        }

        class MyClass : IIfc1, IIfc2
        {
            void IIfc1.Say()
            {
                Console.WriteLine("IIfc1");
            }

            void IIfc2.Say()
            {
                Console.WriteLine("IIfc2");
            }

            public void Say()
            {
                Console.WriteLine("MyClass");
            }
        }

        internal interface IIfc1
        {
            void Say();
        }

        internal interface IIfc2
        {
            void Say();
        }
    }
}