using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _8_正则表达式案例
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Case1();
            // Case2();
            Case3();
        }

        /// <summary>
        /// 从文件路径中提取出文件名(包含后缀) 
        /// 比如从c:\windows\testb.txt中提取出testb.txt这个文件名出来。
        /// </summary>
        public static void Case1()
        {
            var path = "c:\\windows\\testb.txt";
            var match = Regex.Match(path, @"[^\\]+$");
            Console.WriteLine(match.Value);
        }
        /// <summary>
        /// 从“June      26    ,     1951  ”中提取出月份June、26、1951来
        /// </summary>
        public static void Case2()
        {
            var str = "June      26    ,     1951 ";
            var matchCollection = Regex.Matches(str, @"\w+");
            foreach (Match match in matchCollection)
            {
                Console.WriteLine(match.Value);
            }
        }
        /// <summary>
        /// “192.168.10.5[port=21,type=ftp]”从中提取出ip地址192.168.10.5，端口号21，类型ftp
        /// </summary>
        public static void Case3()
        {
            var str = "192.168.10.5[port=21,type=ftp]";
            var mathes = Regex.Matches(str, @"(?<ip>\d{1,3}(\.\d{1,3}){3})|port=(?<port>\d{1,4})|type=(?<type>[a-z]+)");
            foreach (Match math in mathes)
            {
                Console.WriteLine(math.Groups["ip"]);
                Console.WriteLine(math.Groups["port"]);
                Console.WriteLine(math.Groups["type"]);
            }


                               
        }
    }
}
