using System;
using System.Threading;

namespace 单例模式在多线程环境下的不安全问题
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 100; i++)
            {
                new Thread(() =>
                {
                    var instance = Person.GetInstance();
                    Console.WriteLine(instance.GetHashCode());
                }).Start();
            }
        }

        private class Person
        {
            private static object key = new object();
            private static Person _instance;

            private Person()
            {
            }
            public static Person GetInstance()
            {
                // 双重判断减少加锁开销
                if (_instance == null)
                {
                    lock (key)
                    {
                        if (_instance == null)
                        {
                            _instance = new Person();
                        }
                    }
                }
               
                return _instance;
            }
        }
    }
}
