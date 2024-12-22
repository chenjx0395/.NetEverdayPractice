using System;
using System.Diagnostics.SymbolStore;
using System.Runtime.InteropServices;

namespace Exercise
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 测试同名，屏蔽，覆写方法的区别
            // Case1();
            // 封装继承作业
            // Case2();
            // 测试 覆写标记为 override 的方法
            Case3();
        }

       
        
        private static void Case3()
        {
            var c1 = new C1();
            var b1 = new B1();
            A1 a1 = c1;
            c1.Say();
            b1.Say();
            a1.Say();

        }
        
        private class A1
        {
            public virtual void Say()
            {
                Console.WriteLine("A");
            }
        }
        
        private class B1 : A1
        {
            public override void Say()
            {
                Console.WriteLine("B");
            }
        }
        private class C1 : A1
        {
            public override void Say()
            {
                Console.WriteLine("C");
            }
        }

        private static void Case2()
        {
            var cat = new Cat();
            cat.Seelp();
            cat.Eat();
            cat.CatchMouse();
            var dog = new Dog();
            dog.Seelp();
            dog.Eat();
            dog.Cry();
        }
        
        private class Dog : Animal
        {
            public void Cry()
            {
                Console.WriteLine($"{Name} is crying.");
            }
        }
        
        private class Cat : Animal
        {
            public void CatchMouse()
            {
                Console.WriteLine($"{Name} is catching mouse.");
            }
        }
        
        private class Animal
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public void Seelp()
            {
                Console.WriteLine($"{Name} is sleeping.");
            }

            public void Eat()
            {
                Console.WriteLine($"{Name} is eating.");
            }
        }

        private static void Case1()
        {
            // 声明B 同名方法调用B
            // 声明B 屏蔽方法调用B
            // 声明B 屏蔽方法调用B
            B test = new B();
            test.Say();
            // 声明A 同名方法调用A
            // 声明A 屏蔽方法调用A
            // 声明A 屏蔽方法调用B
            A test2 = new B();
            test2.Say();

            // 结论1：同名方法和屏蔽方法效果一致
            // 结论2：重写方法在基引用声明时会调用派生方法
            // 结论3：重写方法最大作用是基引用类型时，调用派生类的同名方法，也就是实现多态。
        }

        private class A
        {
            public virtual void Say()
            {
                Console.WriteLine("Hello A");
            }
        }

        private class B : A
        {
            // 同名方法
            /*public void Say()
            {
                Console.WriteLine("Hello B");
            }*/
            // 屏蔽方法
            /*public  new  void Say()
            {
                Console.WriteLine("Hello B");
            }*/
            // 重写方法
            /*public  override  void Say()
           {
               Console.WriteLine("Hello B");
           }*/
        }
    }
}