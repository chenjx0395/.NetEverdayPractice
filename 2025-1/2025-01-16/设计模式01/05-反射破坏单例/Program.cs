using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _05_反射破坏单例
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.获取元数据
            var type = typeof(Singleton);
            ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            /*Singleton singleton = (Singleton)constructors[0].Invoke(null);
            Console.WriteLine(singleton.GetHashCode());
            Singleton singleton2 = (Singleton)constructors[0].Invoke(null);
            Console.WriteLine(singleton2.GetHashCode());*/

            //第二次破坏
            Singleton singleton = (Singleton)constructors[0].Invoke(null);
            Console.WriteLine(singleton.GetHashCode());
            // 将_instance设置为null
            FieldInfo field = type.GetField("_instance", BindingFlags.NonPublic | BindingFlags.Static);
            field.SetValue(field, null);
            Singleton singleton2 = (Singleton)constructors[0].Invoke(null);
            Console.WriteLine(singleton2.GetHashCode());

        }
    }

    class Singleton
    {
        private static Singleton _instance = null;
        private static object o = new object();
        private Singleton()
        {
            if (_instance != null)
            {
                throw new Exception("单例已被破坏");
            }
            else
            {
                _instance = this;
            }
        }
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                lock (o)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }
}
