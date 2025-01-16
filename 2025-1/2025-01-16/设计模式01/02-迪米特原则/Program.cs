using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_迪米特原则
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 迪米特原则：
             * 1. 一个对象应该对其他对象有最少地了解。
             * 2. 减低类之间的耦合度
             * 3. 迪米特原则实际上就是一个类创建方法和属性时要遵守的法则
             * 4. 只和直接朋友通信
             * 直接朋友
             * 1. 成员对象
             * 2. 方法参数
             * 3. 方法返回值
             * 局部变量不是直接朋友？
             * 为什么？
             * 
             */

            var headEmployee = new HeadEmployee();
            headEmployee.AddEmployee();
            headEmployee.PrintEmployee();
        }

        /// <summary>
        /// 总公司员工
        /// </summary>
        class HeadEmployee
        {
            private int Id { get; set; }
            // 1. 一个集合存储总公司所有的员工
            private List<HeadEmployee> Employees { get; } = new List<HeadEmployee>();
            // 2. 定义一个方法给总公司员工添加数据
            public void AddEmployee()
            {
                for (int i = 0; i < 5; i++)
                {
                    var headEmployee = new HeadEmployee();
                    headEmployee.Id = i;
                    Employees.Add(headEmployee);
                }
            }
            // 3. 打印所有总公司员工 且打印子公司员工
            public void PrintEmployee()
            {
                foreach (var item in Employees)
                {
                    Console.WriteLine("总公司员工：" + item.Id);
                }
                // 打印子公司员工
                var branchEmployees = new BranchEmployees();
                branchEmployees.AddEmployee();
                foreach (var item in branchEmployees.Employees)
                {
                    Console.WriteLine("子公司员工：" + item.Id);
                }
            }

        }
        /// <summary>
        /// 分公司员工
        /// </summary>
        class BranchEmployees
        {
            public int Id { get; set; }
            // 1. 一个集合存储分公司所有的员工
            public List<BranchEmployees> Employees { get; set; } = new List<BranchEmployees>();
            // 2. 定义一个方法给总公司员工添加数据
            public void AddEmployee()
            {
                for (int i = 0; i < 5; i++)
                {
                    var headEmployee = new BranchEmployees();
                    headEmployee.Id = i;
                    Employees.Add(headEmployee);
                }
            }
        }



    }
}
