using System;

namespace _06_简单工厂设计模式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入运算符：");
            string oper = Console.ReadLine();
            var calculation = new OperatorFactory().CreateCalculation(oper, 1, 2);
            Console.WriteLine(calculation.GetResult());
        }

        class OperatorFactory
        {
            public Calculation CreateCalculation(string oper, int n1, int n2)
            {
                Calculation calculation = null;
                switch (oper)
                {
                    case "+":
                        calculation = new Add(n1, n2);
                        break;
                    case "-":
                        calculation = new Sub(n1, n2);
                        break;
                    default:
                        throw new Exception("不支持该运算符");
                }

                return calculation;
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
