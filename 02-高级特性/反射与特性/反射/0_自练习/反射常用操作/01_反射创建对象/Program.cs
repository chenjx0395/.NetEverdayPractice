using System;
using System.Reflection;

namespace _01_反射创建对象
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Secret);
            //获取私有实例的构造函数
            // 错误示例：GetConstructor 只能获取公共构造函数
            // ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            // 方式1：通过复杂的匹配获取构造函数
            /*var constructor = type.GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance, 
                null, 
                Type.EmptyTypes, 
                null);*/
            // 方式2：通过获取所有的构造函数
            var constructors = type.GetConstructors(BindingFlags.NonPublic| BindingFlags.Instance);
            var constructor = constructors[0];
            // 调用构造函数创建对象
            Secret invoke = (Secret)constructor?.Invoke(null);
            invoke?.Show();
        }
    }
}
