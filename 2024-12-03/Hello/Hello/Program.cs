/*
 * 由SharpDevelop创建。
 * 用户： 22439
 * 日期: 2024-12-02
 * 时间: 15:54
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;

namespace Hello
{
	class Program
	{
		public static void Main(string[] args)
		{
			var p1 = new Person("cjx",18);
			p1.DisplayInfo();
			
			var t1 = new Teacher("zxk",19,"sing");
			t1.DisplayInfo();
			t1.Teach();
		}
	}
}