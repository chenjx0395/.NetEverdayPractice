using System;

namespace _01_反射创建对象
{
    public class Secret
    {
        private Secret()
        {
            Console.WriteLine("我是不能被创建的构造函数");
        }

        public void Show()
        {
            Console.WriteLine("我不信有人可以调用我");
        }
    }
}