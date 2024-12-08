using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal abstract class Campany
    {
        public string brand { get; set; }

        public Campany(string name) 
        {
            brand = name;
        }

        public void MakeTea()
        {
            Console.WriteLine("总公司，统一的奶茶制作工艺");
        }

        public abstract void MakeReport();
    }
}
