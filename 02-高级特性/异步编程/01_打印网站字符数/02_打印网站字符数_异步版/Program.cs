using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_打印网站字符数_异步版
{
    /// <summary>
    /// 将获取网站字符数的操作异步化，后续方法无需等待网址响应
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var downloadString = new MyDownloadString();
            downloadString.DoRun();
        }
    }
}
