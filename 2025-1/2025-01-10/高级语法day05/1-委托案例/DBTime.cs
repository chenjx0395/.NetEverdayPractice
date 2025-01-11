using System;
using System.Globalization;

namespace _1_委托案例
{
    public class DBTime
    {
        public void OutputTime(DateTime dateTime)
        {
            Console.WriteLine("时间被存储到了数据库中"+dateTime.ToString(CultureInfo.InvariantCulture));
        }
    }
}