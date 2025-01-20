using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 市政大厅_V1
{
    /// <summary>
    /// 1. 你需要证明你妈是你妈
    /// 2. 为了证明你需要办理如下操作
    /// 3. 派出所开户口证明
    /// 4. 街道办开户籍证明
    /// 5. 医院开生产证明，最后才能代表你妈是你妈
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 方案1：不使用设计模式
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var person = new Person(){Name = "小明"};
            var hall = new OfficeHall();
            person.ProofMother(hall);
        }
    }
    class Person
    {
        public string Name { get; set; }
        /// <summary>
        /// 证明自己的妈是自己的妈
        /// </summary>
        public void ProofMother(OfficeHall hall)
        {
            hall.AccountEnquiry(Name,"大美");
            hall.RegisteredResidenceInquiry(Name, "大美");
            hall.QueryProductionCertificate(Name, "大美");
        }
    }

    class OfficeHall
    {
        public void AccountEnquiry(string name,string mom)
        {
            Console.WriteLine($"{name}的户口证明小美是他妈");
        }
        public void RegisteredResidenceInquiry(string name, string mom)
        {
            Console.WriteLine($"{name}的户籍证明小美是他妈");
        }
        public void QueryProductionCertificate(string name, string mom)
        {
            Console.WriteLine($"{name}的产证证明小美是他妈");
        }
    }
}
