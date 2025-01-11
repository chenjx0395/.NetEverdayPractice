using System;
using System.Reflection;

namespace Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 1. 加载要操作的程序集
            var assembly = Assembly.LoadFile(@"D:\Code\.NetEverdayPractice\2025-1\2025-01-10\高级语法day05\Tools\bin\Debug\Tools.dll");
            //2.1 ass.GetExportedTypes :标记为public的成员
            //2.2 ass.GetTypes(); 获取程序集中所有的成员：public+internal
            var exportedTypes = assembly.GetExportedTypes();
            foreach (var exportedType in exportedTypes)
            {
                Console.WriteLine(exportedType.Name);
            }
            //2.3 获取指定的类型 —— 需要指定命名空间
            var type = assembly.GetType("Tools.Tools");
            // 获取静态方法
            var methodInfo = type.GetMethod("Hello",BindingFlags.Static|BindingFlags.Public);
            // 调用方法需要指定对象（静态方法不需要），和参数数组（无参数不需要）
            methodInfo.Invoke(null, null);
            
            //3 创建对象
            //3.1 利用 Activator 远程创建对象
            // var obj = Activator.CreateInstance(type);
            //3.2 获取构造函数，创建对象
            var constructorInfo = type.GetConstructor(Type.EmptyTypes);
            var tools =constructorInfo.Invoke(null);
            var method = type.GetMethod("Work");
            method.Invoke(tools, new object[] { "打游戏" });
        }
    }
}