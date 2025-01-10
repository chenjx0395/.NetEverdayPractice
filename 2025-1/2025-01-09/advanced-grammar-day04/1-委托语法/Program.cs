using System;

namespace _1_委托语法
{
    // 1.定义委托
    delegate void MyDelegate(string str);

    internal class Program
    {
        public static void Main(string[] args)
        {
            // 2. 创建委托对象，并将符合规范的方法赋值给委托对象
            MyDelegate myDelegate = new MyDelegate(SayHello);
            // 3. 可以直接执行委托对象
            myDelegate(".NET");
            // 3. Invoke 是调用委托绑定的方法的方法
            myDelegate.Invoke("world");
            
            // 简化创建委托的方式
            MyDelegate myDelegate2 = SayHello;
            myDelegate2("C#");
        }

        public static void SayHello(string str)
        {
            Console.WriteLine("hello " + str);
        }
        
        
    }
}