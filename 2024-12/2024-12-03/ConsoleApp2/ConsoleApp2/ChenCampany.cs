using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ChenCampany : Campany
    {
        public ChenCampany(string name) : base(name)
        {

        }

        public override void MakeReport()
        {
           Console.WriteLine("陈氏奶茶店的报表结果……");
        }
    }
}
