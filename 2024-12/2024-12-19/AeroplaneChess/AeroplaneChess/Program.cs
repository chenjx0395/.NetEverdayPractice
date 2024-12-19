using System;

namespace AeroplaneChess
{
    internal class Program
    {
        private static readonly int[] Map = new int[100];
        private static string _p1 = null;
        private static string _p2 = null;
        private static int[] _playLogo = new int[2];
        // 暂停标识，0 代表玩家无需暂停，1 代表玩家需暂停
        private static int[] _stop = new int[2];
        private static readonly Random Random = new Random();
        //幸运轮盘坐标
        private static readonly int[] LuckTurn = { 6, 23, 40, 55, 69, 83 };
        //地雷坐标
        private static readonly int[] LandMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 };
        //暂停坐标
        private static readonly int[] Pause = { 9, 27, 60, 93 };
        //时空隧道
        private static readonly int[] TimeTunnel = { 20, 25, 45, 63, 72, 88, 90 };


        private static void Main(string[] args)
        {
            // 调用绘制游戏标题
            DrawGameTitle();
            // 调用输入玩家
            ReadPlayer(out _p1, out _p2);
            // 调用绘制地图的标题
            DrawMapTitle();
            // 调用关卡分配
            AssignLevel();
            DrawMap();
            while (true)
            {
                PlayerMove(0);
                PlayerMove(1);
               
            }
        }
        // 绘制游戏标题
        private static void DrawGameTitle()
        {
            for (var i = 0; i < 7; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 3:
                        Console.ResetColor();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                }

                if (i == 3)
                {
                    Console.WriteLine("***********************C#_基础 飞行棋***********************");
                    continue;
                }

                Console.WriteLine("************************************************************");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
        // 输入玩家
        private static void ReadPlayer(out string player1, out string player2)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n请输入玩家A的姓名：");
                Console.ResetColor();
                player1 = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(player1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n玩家A的姓名不能为空");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n{player1} 录入成功");
                    Console.ResetColor();
                    break;
                }
            }
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n请输入玩家B的姓名：");
                Console.ResetColor();
                player2 = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(player2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n玩家B的姓名不能为空");
                    Console.ResetColor();
                }
                else if (player1.Equals(player2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("玩家B的姓名不能和玩家A重复！");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n{player2} 录入成功\n");
                    Console.ResetColor();
                    break;
                }
            }
            Console.Clear();

        }
        // 绘制地图的标题
        private static void DrawMapTitle()
        {
            DrawPlayerName();
            // 控制台输出，◎，●，▲，〓.
            Console.WriteLine("图例:  幸运轮盘：◎  地雷：●  暂停：▲  时空隧道：〓 ");
            Console.WriteLine();
        }
        // 绘制地图
        private static void DrawMap()
        {
            // 第一行
            for (var i = 0; i < 30; i++)
            {
                DrawGameLevel(i);
            }
            Console.WriteLine();
            // 第一列
            for (var i = 30; i < 35; i++)
            {
                for (var j = 0; j < 29 * 2; j++)
                {
                    Console.Write(" ");
                }
                DrawGameLevel(i);
                Console.WriteLine();
            }
            // 第二行
            for (var i = 64; i > 34; i--)
            {
                DrawGameLevel(i);
            }
            Console.WriteLine();
            // 第二列
            for (var i = 65; i < 70; i++)
            {
                DrawGameLevel(i);
                Console.WriteLine();
            }
            // 第三行
            for (var i = 70; i < 100; i++)
            {
                DrawGameLevel(i);
            }
            Console.WriteLine();
        }
        // 分配关卡
        private static void AssignLevel()
        {
            // 口 = 0 ◎ = 1 ● = 2 ▲ = 3 〓 = 4

            for (var i = 0; i < 100; i++)
            {
                // 分配幸运轮盘坐标
                foreach (var i1 in LuckTurn)
                {
                    if (i == i1)
                    {
                        Map[i] = 1;
                    }
                }
                // 分配地雷坐标
                foreach (var i1 in LandMine)
                {
                    if (i == i1)
                    {
                        Map[i] = 2;
                    }
                }
                // 分配暂停坐标
                foreach (var i1 in Pause)
                {
                    if (i == i1)
                    {
                        Map[i] = 3;
                    }
                }
                // 分配幸运轮盘坐标
                foreach (var i1 in TimeTunnel)
                {
                    if (i == i1)
                    {
                        Map[i] = 4;
                    }
                }
            }

        }
        // 绘制关卡
        private static void DrawGameLevel(int i)
        {
            if (_playLogo[0] == 0 && _playLogo[1] == 0 && i == 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("星");
            }
            else if (i == _playLogo[0])
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("#A");
            }
            else if (i == _playLogo[1])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("*B");
            }
            else
            {
                // 口 = 0  = 1 ● = 2 ▲ = 3 〓 = 4
                switch (Map[i])
                {
                    case 0:
                        Console.ResetColor();
                        Console.Write("口");
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("轮");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("雷");
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("停");
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("穿");
                        break;

                }
            }



        }
        // 绘制玩家姓名
        private static void DrawPlayerName()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"A表示 玩家{_p1}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"B表示 玩家{_p2}");
            Console.WriteLine();
            Console.ResetColor();
        }
        // 玩家移动
        private static void PlayerMove(int player) // 0 = 玩家A
        {
            var playerName = (player == 0 ? _p1 : _p2);
            // 代表此轮玩家需跳过
            if (_stop[player] == 1)
            {
                Console.WriteLine($"玩家 {playerName} 此轮跳过！");
                _stop[player] = 0;
            }
            else
            {
                
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n玩家{playerName} 按任意键开始丢骰子");
                Console.ReadKey();
                var step = Random.Next(1, 7);
                _playLogo[player] += step;
                if (_playLogo[player] >= 99)
                {
                    Console.Clear();
                    Console.WriteLine($"游戏结束! {playerName} 获得了胜利！！！");
                    Environment.Exit(0);

                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n玩家{playerName} 丢出了{step}");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"\n玩家{playerName} 按任意键开始行动");
                Console.ReadKey();
                // 玩家移动后需要判断玩家移动的目标位置是否存在特殊关卡
                TriggerRules(player, playerName);
            }
            

        }

        /// <summary>
        ///  触发规则
        /// </summary>
        /// <param name="player">0 代表一号玩家进行判定 1 代表二号玩家进行判定</param>
        /// <param name="name">玩家姓名</param>
        /// <returns>false 代表没有触发自身移动规则，true 代表触发了自身移动规则，需继续判断</returns>
        private static bool TriggerRules(int player, string name)
        {
            Console.Clear();
            var message = $"{name} 没触碰到机关";
            var result = false;
            
            // 检查幸运轮盘坐标
            foreach (var i1 in LuckTurn)
            {
                if (_playLogo[player] != i1) continue;
                (_playLogo[0], _playLogo[1]) = (_playLogo[1], _playLogo[0]);
                message = $"{name} 触发幸运轮盘，玩家位置互换";
            }
            // 检查地雷坐标
            foreach (var i1 in LandMine)
            {
                if (_playLogo[player] != i1) continue;
                if (_playLogo[player] < 6)
                {
                    _playLogo[player] = 0;
                }
                else
                {
                    _playLogo[player] -= 6;
                }

                message = $"{name}踩到地雷，后退6格";
                result =  true;
            }
            // 检查暂停坐标
            foreach (var i1 in Pause)
            {
                if (_playLogo[player] != i1) continue;
                _stop[player] = 1;
                message = $"{name}暂停一回合";
            }
            // 检查时空隧道坐标
            foreach (var i1 in TimeTunnel)
            {
                if (_playLogo[player] != i1) continue;
                _playLogo[player] += 10;
                message = $"{name}进入时空隧道，前进10格";
                result =  true;
            }

            // 判断是否踩到其他玩家
            if (_playLogo[0] == _playLogo[1])
            {
                if (!message.Equals($"{name} 没触碰到机关"))
                {
                    Console.WriteLine(message);
                }
                if (player == 0)
                {
                    if (_playLogo[1] < 6)
                    {
                        _playLogo[1] = 0;
                    }
                    else
                    {
                        _playLogo[1] -= 6;
                    }
                }
                else
                {
                    if (_playLogo[0] < 6)
                    {
                        _playLogo[0] = 0;
                    }
                    else
                    {
                        _playLogo[0] -= 6;
                    }
                }
                var newName = player == 0 ? _p2 : _p1;
                message = $"{name}踩了{newName}一脚，并吐了口痰";
                Console.WriteLine($"玩家{newName}被踩到，后退6格");
                Console.WriteLine("输入任意键继续游戏");
                Console.ReadKey();
                while (TriggerRules(player == 0 ? 1 : 0, newName))
                {

                }
                Console.WriteLine("输入任意键继续游戏");
                Console.ReadKey();
                Console.Clear();
            }
            DrawMapTitle();
            DrawMap();
            Console.WriteLine();
            Console.WriteLine(message);
            return result;
        }
    }
}

