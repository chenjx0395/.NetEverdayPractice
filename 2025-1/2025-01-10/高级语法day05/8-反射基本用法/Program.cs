using System;
using System.Reflection;

namespace _8_反射基本用法
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 1. 获取类的 Type
            var person = new Person("张三");
            //1.1 直接通过类获取 Type
            var type1 = typeof(Person);
            //1.2 通过对象获取 Type
            var type = person.GetType();
            //2. 获取类的所有公共成员
            var memberInfos = type.GetMembers();
            /*foreach (var memberInfo in memberInfos)
            {
                Console.WriteLine(memberInfo.Name);
            }*/

            //3. 获取实例对象的非公共成员
            var members = type.GetMembers(BindingFlags.Instance | BindingFlags.NonPublic);
            /*foreach (var member in members)
            {
                Console.WriteLine(member.Name);
            }*/

            //4. 获取指定方法的参数和返回 -- 获取私有方法需要额外的指定参数
            var methodInfo = type.GetMethod("Eat", BindingFlags.NonPublic | BindingFlags.Instance);
            //4.1 获取参数
            var parameters = methodInfo.GetParameters();
            foreach (var parameter in parameters)
            {
                Console.WriteLine(parameter.ParameterType);
            }

            //4.2 获取返回值
            var returnParameter = methodInfo.ReturnParameter;
            Console.WriteLine(returnParameter.ParameterType);
        }

        private class Person
        {
            private string _name;
            public int Age { get; set; }

            public Person(string name)
            {
                this._name = name;
            }

            private string Eat(string food, int numberOfCopies)
            {
                Console.WriteLine("吃饭中！");
                return $"吃了{numberOfCopies}份的{food}";
            }

            public void Work(string thing)
            {
                Console.WriteLine("工作中:" + thing);
            }

            public static void Hello()
            {
                Console.WriteLine("执行静态方法！");
            }
        }
    }
}