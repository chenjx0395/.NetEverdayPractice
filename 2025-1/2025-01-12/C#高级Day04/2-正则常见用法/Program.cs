using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2_正则常见用法
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var match = Regex.Match("aaabaaab",".+b");
            Console.WriteLine(match.Value);
            var match1 = Regex.Match("aaabaaab", ".+?b");
            Console.WriteLine(match1.Value);
            var str = @"\";
            Console.WriteLine(str == "\\");
        }
    }
}
