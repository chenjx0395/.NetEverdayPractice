using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 工人类：含所有工人的通用属性及功能
 */
namespace interfaceExer02
{
    internal class Worker
    {
        private static int s_WorkNumberSeed = 100;
        public string WorkNumber { get; }
        public string Name { get; set; }
        public byte age { get; set; }
        public byte sex { get; set; }

        public Worker(string name, byte age, byte sex) 
        { 
            this.Name = name;
            this.age = age;
            this.sex = sex;
            this.WorkNumber = s_WorkNumberSeed.ToString();
            s_WorkNumberSeed++;
        }

        // 打卡
        public void clockIn()
        {
            Console.WriteLine($"员工编号:{WorkNumber} 姓名：{Name} 打卡上班。打卡时间：{DateTime.Now}");
        }



    }
}
