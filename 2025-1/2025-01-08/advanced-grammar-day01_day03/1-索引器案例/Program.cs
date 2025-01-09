using System;

namespace _1_索引器案例
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
             * 案例：
                要求：写三个索引器
                1、根据员工的姓名、员工号、查找对方所在的部门
                2、根据员工的姓名、部门名称、查找对方的员工号
                3、根据员工的员工号和部门名称，查找对方的姓名
             */
            var employeeWork = new EmployeeWork();
            Console.WriteLine(employeeWork["张三", 1]);
            Console.WriteLine(employeeWork["李四", "销售部"]);
            Console.WriteLine(employeeWork[3, "研发部"]);
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Department { get; set; }

        public Employee(string name, int id, string department)
        {
            Name = name;
            Id = id;
            Department = department;
        }
    }

    class EmployeeWork
    {
        private Employee[] employees = new Employee[3];

        public EmployeeWork()
        {
            employees[0] = new Employee("张三", 1, "管理部");
            employees[1] = new Employee("李四", 2, "销售部");
            employees[2] = new Employee("王五", 3, "研发部");
        }

        // 1、根据员工的姓名、员工号、查找对方所在的部门
        public string this[string name, int id]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(name) || id <= 0) return null;
                foreach (var employee in employees)
                {
                    if (employee.Name == name && employee.Id == id)
                    {
                        return employee.Department;
                    }
                }
                
                return null;
            }
        }
        
        // 2、根据员工的姓名、部门名称、查找对方的员工号
        public int? this[string name, string department]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(department)) return null;
                foreach (var employee in employees)
                {
                    if (employee.Name == name && employee.Department == department)
                    {
                        return employee.Id;
                    }
                }
                
                return null;
            }
        }
        
        // 3、根据员工的员工号和部门名称，查找对方的姓名
        public string this[int id, string department]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(department) || id <= 0) return null;
                foreach (var employee in employees)
                {
                    if (employee.Department == department && employee.Id == id)
                    {
                        return employee.Name;
                    }
                }
                
                return null;
            }
        }
    }
    
}