using System;
using System.CodeDom;

namespace _10_反射的其他API
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            //1.IsAssignableFrom既可以判断类，也可以判断接口。
            //IsAssignableFrom 判断后面的类型是否可以赋值给前面的类型  里式转换，子类可以赋值给父类
            bool b1 = typeof(Person).IsAssignableFrom(typeof(Student)); // true
            bool b2 = typeof(Person).IsAssignableFrom(typeof(Teacher)); // true
            bool b3 = typeof(Person).IsAssignableFrom(typeof(Driver)); // false
            bool b4 = typeof(I1).IsAssignableFrom(typeof(I2)); // true
            bool b5 = typeof(I1).IsAssignableFrom(typeof(Teacher)); // false
            bool b6 = typeof(I1).IsAssignableFrom(typeof(Driver)); // true
            //2. IsInstanceOfType 判断谁是否可以赋值给谁，可以判断类也可以判断接口
            var p = new Person();
            var s = new Student();
            var d = new Driver();
            bool b7 = typeof(Person).IsInstanceOfType(s); // true
            bool b8 = typeof(I1).IsInstanceOfType(d); // true
            //3. IsSubclassOf 只能判断类，不能判断接口
            bool b9 = typeof(I2).IsSubclassOf(typeof(I1)); // false
            //4. IsAbstract 判断是否是抽象
            bool b10 = typeof(I1).IsAbstract; // true
        }
        
        
    }
    class Person
    { }
    class Student : Person
    { }

    class Teacher : Person
    { }

    interface I1
    { }
    interface I2 : I1
    {

    }
    class Driver : I1
    { }
}