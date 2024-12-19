/*
 * 由SharpDevelop创建。
 * 用户： 22439
 * 日期: 2024-12-02
 * 时间: 17:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Hello
{
	/// <summary>
	/// Description of Teacher.
	/// </summary>
	  public class Teacher : Person
    {
        public string Subject { get; set; }

        public Teacher(string name, int age, string subject) : base(name, age)
        {
            Subject = subject;
        }

        public void Teach()
        {
            Console.WriteLine($"{Name} is teaching {Subject}.");
        }
    }
}
