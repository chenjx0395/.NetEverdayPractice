namespace _6_泛型约束
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 1. 必须是值类型
            // var test1 = new Test<string>(); // error
            var test = new Test<int>(); // ok
            // 2. 必须是引用类型
            // var test1 = new Test2<int>(); // error
            var test2 = new Test2<string>(); // ok
            // 3. new 约束
            // var test3 = new Test3<string>(); // error
            //4. 必须是Student或其子类
            var test3 = new Test4<Student>(); // ok
            var test4 = new Test4<StudentChild>(); // ok
            //5. 必须实现IFlyable的接口
            var test5 = new Test5<Student>(); // ok
            var test6 = new Test5<StudentChild>(); // ok
            //6. 裸类型约束，要求T必须继承与U,同样适用接口
            var test7 = new QQ<Student, IFlyable>(); // ok
        }
    }
    //1. 必须是值类型
    public class Test<T> where T : struct
    {
    }
    //2. 必须是引用类型
    public class Test2<T> where T : class
    {
    }
    //3. 要求T类型，必须具备一个无参数的构造函数,new()必须是所有约束中的最后一个
    //如果泛型有多个约束的情况下，new()语法上要求，必须放到所有约束的最后面
    public class Test3<T> where T : class, new()
    {
        public T Value { get; set; }
        public Test3()
        {
            Value = new T();
        }
    }
    //4. 必须是Student或其子类
    public class Student : IFlyable
    {
    }
    public class StudentChild : Student , IFlyableChild
    {
    }
    public class Test4<T> where T : Student
    {
    }
    //5. 必须实现IFlyable的接口或其子类
    public interface IFlyable
    {
        
    }

    public interface IFlyableChild : IFlyable
    {
    }

    public class Test5<T> where T : IFlyable
    {
    }
    //6. 裸类型约束： 要求T必须继承与U,同样适用接口
    class QQ<T, U> where T : U
    {
    }
}