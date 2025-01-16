using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _07_工厂方法设计模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = new AddFactory().GetOperator(1, 2).GetResult();
            Console.WriteLine(result);
        }

        // 定义抽象工厂
        abstract class Factory
        {
            public abstract Calculation GetOperator(int n1, int n2);

        }

        class AddFactory : Factory
        {
            public override Calculation GetOperator(int n1, int n2)
            {
                return new Add(n1, n2);
            }
        }

        class SubFactory : Factory
        {
            public override Calculation GetOperator(int n1, int n2)
            {
                return new Sub(n1, n2);
            }
        }

        abstract class Calculation
        {
            public int num1 { get; set; }
            public int num2 { get; set; }
            public abstract int GetResult();

            protected Calculation(int num1, int num2)
            {
                this.num1 = num1;
                this.num2 = num2;
            }
        }

        class Add : Calculation
        {
            public Add(int num1, int num2) : base(num1, num2)
            {
            }

            public override int GetResult()
            {
                return num1 + num2;
            }
        }

        class Sub : Calculation
        {
            public Sub(int num1, int num2) : base(num1, num2)
            {
            }

            public override int GetResult()
            {
                return num1 - num2;
            }
        }
    }
}
