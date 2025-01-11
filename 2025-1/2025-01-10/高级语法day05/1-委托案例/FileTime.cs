using System;
using System.Globalization;

namespace _1_委托案例
{
    public class FileTime
    {
        public void OutputTime(DateTime dateTime)
        {
            Console.WriteLine("时间存储到了文件中"+dateTime.ToString(CultureInfo.InvariantCulture));
        }
    }
}