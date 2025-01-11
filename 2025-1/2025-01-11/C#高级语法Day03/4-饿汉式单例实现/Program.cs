using System;

namespace _4_饿汉式单例实现
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 100; i++)
            {
                var s = Singleton.GetExample();
                Console.WriteLine(s.GetHashCode());
            }
        }
    }

    public class Singleton
    {
        private static readonly Singleton _singleton = new Singleton();
        private Singleton()
        {

        }

        public static Singleton GetExample()
        {
            return _singleton;
        }
    }
}
