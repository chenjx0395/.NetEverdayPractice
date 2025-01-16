using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_类之间的6种关系
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        class home
        {
            private List<Person> persons = new List<Person>();
        }

        class Leg
        {
            
        }
        class  Person
        {
            private Leg[] legs = new Leg[2];
        }
    }
}
