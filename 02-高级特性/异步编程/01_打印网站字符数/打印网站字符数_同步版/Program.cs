using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打印网站字符数_同步版
{
    /// <summary>
    /// 获取某网站内容，打印网站的字符数
    /// 模拟同步下执行IO密集型任务导致线程等待的缺陷
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
