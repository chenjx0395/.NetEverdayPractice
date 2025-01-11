using System;
using System.Globalization;

namespace _1_委托案例
{
    public class ConsoleTime
    {
        
        public void OutputTime(DateTime dateTime)
        {
            Console.WriteLine(dateTime.ToString(CultureInfo.InvariantCulture));
        }
        
    }
   
}