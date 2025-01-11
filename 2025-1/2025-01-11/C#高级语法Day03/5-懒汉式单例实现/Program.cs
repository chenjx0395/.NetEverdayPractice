using System;

namespace _5_懒汉式单例实现
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
        private static Singleton _singleton;
        private Singleton()
        {

        }

        public static Singleton GetExample()
        {
            if (_singleton == null) _singleton = new Singleton();
            return _singleton;
        }
    }
}
