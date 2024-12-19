/*
 * 由SharpDevelop创建。
 * 用户： 22439
 * 日期: 2024-12-02
 * 时间: 17:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Hello
{
	/// <summary>
	/// Description of Person.
	/// </summary>
	public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }
}
