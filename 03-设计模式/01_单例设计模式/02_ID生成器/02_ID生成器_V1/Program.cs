using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ID生成器_V1
{
    /// <summary>
    /// 全局唯一生成ID
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            var idGenerator = IdGenerator.GetInstance();
            var task = Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    Console.WriteLine(idGenerator.GetId().ToString());
                }
            });
            var task2 = Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    Console.WriteLine(idGenerator.GetId().ToString());
                }
            });
            Console.ReadKey();
        }
    }
}
