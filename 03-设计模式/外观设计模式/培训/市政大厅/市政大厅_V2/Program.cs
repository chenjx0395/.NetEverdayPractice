using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace 市政大厅_V2
{
    internal class Program
    {
        /// <summary>
        /// 版本2：采用外观设计模式思想对外提供复杂操作的接口，满足迪米特原则
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            var person = new Person(){Name = "小明"};
            var hall = new OfficeHall();
            hall.ProofMother(person.Name, "小美");
        }
    }
    class Person
    {
        public string Name { get; set; }
     
    }

    class OfficeHall
    {
        /// <summary>
        /// 对外提供复杂操作的接口
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mom"></param>
        public void ProofMother(string name, string mom)
        {
            AccountEnquiry(name, mom);
            RegisteredResidenceInquiry(name, mom);
            QueryProductionCertificate(name, mom);
        }

        private void AccountEnquiry(string name, string mom)
        {
            Console.WriteLine($"{name}的户口证明小美是他妈");
        }
        private void RegisteredResidenceInquiry(string name, string mom)
        {
            Console.WriteLine($"{name}的户籍证明小美是他妈");
        }
        private void QueryProductionCertificate(string name, string mom)
        {
            Console.WriteLine($"{name}的产证证明小美是他妈");
        }


    }
}
