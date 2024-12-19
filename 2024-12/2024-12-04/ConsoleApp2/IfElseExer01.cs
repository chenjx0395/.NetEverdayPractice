using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class IfElseExer01
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();

            int roll1 = rnd.Next(1, 7);
            int roll2 = rnd.Next(1, 7);
            int roll3 = rnd.Next(1, 7);
            //int roll1 = 6;
            //int roll2 = 6;
            //int roll3 = 6;
            int tatol = roll1 + roll2 + roll3;

            Console.WriteLine($"丢出的三个数：{roll1}+{roll2}+{roll3}={tatol}");

            if (roll1 == roll2 || roll2 == roll3 || roll1 == roll3)
            {
                // 三倍奖励
                if (roll1 == roll2 && roll1 == roll3)
                {
                    tatol += 6;
                    Console.WriteLine($"您摇出了三个相同的数值，分数+6。总分：{tatol}！！！");
                }
                // 双倍奖励
                else
                {
                    tatol += 2;
                    Console.WriteLine($"您摇出了二个相同的数值，分数+2。总分：{tatol}！！！");
                }

            }

            // 判定胜负
            /*if (tatol >= 15)
            {
                Console.WriteLine("您获胜了！！！");
            }
            else
            {
                Console.WriteLine("您输了！！！");
            }*/
            if (tatol >= 16)
            {
                Console.WriteLine("赢得一辆新车。");
            }
            else if (tatol >= 10)
            {
                Console.WriteLine("赢得一台新的笔记本电脑。");
            }
            else if (tatol >= 7)
            {
                Console.WriteLine("赢得一次旅行机会。");
            }
            else
            {
                Console.WriteLine("赢得一只小猫");
            }
        }
    }
}
