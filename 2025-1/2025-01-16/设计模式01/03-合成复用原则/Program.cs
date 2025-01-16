using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _03_合成复用原则
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var gasolineCar = new GasolineCar(new RedColor());
            var gasolineCar2 = new GasolineCar(new GreenColor());
            var gasolineCar3 = new GasolineCar(new YellowColor());

            var electricCar = new ElectricCar(new RedColor());
            var electricCar2 = new ElectricCar(new GreenColor());
            var electricCar3 = new ElectricCar(new YellowColor());

            gasolineCar.Move();
            gasolineCar2.Move();
            gasolineCar3.Move();
            electricCar.Move();
            electricCar2.Move();
            electricCar3.Move();
        }

        interface IColor
        {
            string Color { get; }
        }

        class RedColor : IColor
        {
            public string Color => "红色";
        }
        class GreenColor : IColor
        {
            public string Color => "绿色";
        }
        class YellowColor : IColor
        {
            public string Color => "黄色";
        }
        abstract class Car
        {
           public  IColor Color { get; }
            public abstract void Move();

            protected Car(IColor color)
            {
                Color = color;
            }
        }

        class GasolineCar : Car
        {
            public GasolineCar(IColor color) : base(color)
            {
            }

            public override void Move()
            {
                Console.WriteLine($"{Color.Color}的汽车在跑");
            }
        }

        class ElectricCar : Car
        {
            public ElectricCar(IColor color) : base(color)
            {
            }

            public override void Move()
            {
                Console.WriteLine($"{Color.Color}的电车在跑");
            }
        }
    }
}
