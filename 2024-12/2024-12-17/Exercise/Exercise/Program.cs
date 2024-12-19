using System;
using System.Linq;

namespace Exercise
{
    internal class Program
    {
        //防止种子生成相同问题
        private static readonly Random _random = new Random();
        static void Main(string[] args)
        {
            //删除数组元素demo
            // Case1();
            //删除数组元素案例
            // Case2();
            //元素反转 -- 倒叙查找案例
            // Case2();
            // 冒泡排序
            // Case3();
            // 双色球案例
            Case4();

        }



        public static void Case4()
        {
            // 用户购买彩票记录 - 设定用户最多购买3张
            // 单个彩票单个数字的记录中 1-6 = 红球 7 = 篮球 8 = 倍数
            var lotteryRecords = new int[3][][];
            // 初始化交错数组
            for (var i = 0; i < 3; i++)
            {
                lotteryRecords[i] = new int[5][];
                for (var j = 0; j < 5; j++)
                {
                    lotteryRecords[i][j] = new int[8];
                }
            }
            // 已购买彩票数
            var lotteryCount = 0;
            // 开奖记录
            var openLotteryRecord = new int[7];
            // 总金额
            var money = 0;
            // 中奖记录, 0 = 一等奖
            var awardRecord = new int[6];
            var isExit = false;
            while (!isExit)
            {
                MenuPrinting();
                var readKey = Console.ReadKey();
                Console.WriteLine();
                // 异常输入重新输入
                if (!int.TryParse(readKey.KeyChar.ToString(), out var readKeyNum))
                {
                    PrintErrorMessage("\n请输入正确的操作符！");
                    continue;
                }

                switch (readKeyNum)
                {
                    case 1:
                        //1.判断用户是否还可以购买彩票（开奖后也不允许购买）
                        if (IsBuyLottery()) break;
                        var groupCount = 0;
                        //2.询问是否机选
                        if (MachineSelection()) goto isExit;

                        //3.输入红球，范围约束，重复约束
                        do
                        {
                            ManualInputBallValue(groupCount++);
                        //6.询问是否再购买一组号码（最多5组）
                        groupCount: Console.WriteLine("还要再购买一组吗？(y/n)");
                            var isSystem = Console.ReadKey();
                            if (isSystem.KeyChar == 'y')
                            {
                            }
                            else if (isSystem.KeyChar == 'n')
                            {
                                break;
                            }
                            else
                            {
                                PrintErrorMessage("错误的操作符！");
                                goto groupCount;
                            }
                        } while (groupCount < 5);
                        //输入此张彩票购买的倍数
                        isExit: SelectMultiples();
                        Console.WriteLine();
                        lotteryCount++;
                        break;
                    //查看已购买彩票
                    case 2:
                        ViewTicketsPurchased();
                        break;
                    //开奖
                    case 3:
                        //不允许二次开奖
                        if (openLotteryRecord[0] != 0)
                        {
                            PrintErrorMessage("不允许重复开奖！");
                            break;
                        }
                        GeneratingRandomBalls(openLotteryRecord);
                        // 中奖号码是
                        Console.WriteLine("中奖号码为：");
                        foreach (var i in openLotteryRecord)
                        {
                            Console.Write(i + " ");
                        }

                        Console.WriteLine();
                        break;
                    case 4:
                        CheckWinnings();
                        break;
                    case 5:
                        Console.WriteLine("\n退出成功！欢迎再次使用！");
                        isExit = true;
                        break;
                    default:
                        PrintErrorMessage("请输入正确的操作值！");
                        break;
                }

            }
            return;

            // 冒泡排序
            void BubbleSort(int[] arr, int length)
            {
                for (var i = length; i > 0; i--)
                {
                    for (var j = 1; j < i; j++)
                    {
                        // 如果前大于后，则替换
                        if (arr[j] > arr[j - 1]) continue;
                        (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                    }
                }
            }
            //删除数组元素
            void DeleteArray(int[] arr, int index)
            {
                //判断index是否越界
                if (index < 0 || index >= arr.Length) return;
                for (var i = index + 1; i < arr.Length; i++)
                {
                    arr[i - 1] = arr[i];
                }
                arr[arr.Length - 1] = 0;
            }
            // 错误输入打印
            void PrintErrorMessage(string message)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\n{message}！\n");
                Console.ResetColor();
            }
            // 菜单打印
            void MenuPrinting()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("----------------------");
                Console.ResetColor();
                Console.WriteLine("欢迎使用双色球彩票系统");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("----------------------");
                Console.ResetColor();
                Console.WriteLine("\n请输入下列功能序号：");
                Console.WriteLine("\n\t1.购买彩票");
                Console.WriteLine("\n\t2.查看购买彩票");
                Console.WriteLine("\n\t3.开奖");
                Console.WriteLine("\n\t4.查看中奖情况");
                Console.WriteLine("\n\t5.退出系统");
            }
            // 随机6个红球和1个蓝球
            void GeneratingRandomBalls(int[] ints)
            {
                //定义33个数数组 - 用于保证红球不重复
                var referenceNumbers = new int[33];
                for (var i = 0; i < 33; i++)
                {
                    referenceNumbers[i] = i + 1;
                }

                //随机6个红球
                for (var i = 0; i < 6; i++)
                {
                    //选了一个，就少一个选择
                    var index = _random.Next(0, 33 - i);
                    //给红球赋值
                    ints[i] = referenceNumbers[index];
                    //删除已选择的
                    DeleteArray(referenceNumbers, index);
                }
                //随机1个蓝球
                ints[6] = _random.Next(1, 17);
                //排序红球
                BubbleSort(ints, 6);
            }
            // 机选球号
            bool MachineSelection()
            {
                while (true)
                {
                    Console.WriteLine("\n是否机选彩票：(y/n)");
                    var isSystem = Console.ReadKey();
                    if (isSystem.KeyChar == 'y')
                    {
                        Console.WriteLine("\n您需要机选几组号码：（不能大于5组）");
                        var lotteryReadKey = Console.ReadKey();
                        // 异常输入重新输入
                        if (!int.TryParse(lotteryReadKey.KeyChar.ToString(), out var lotteryReadKeyNum) || lotteryReadKeyNum > 5)
                        {
                            PrintErrorMessage("\n请输入正确的操作值！");
                            continue;
                        }
                        // 给当前彩票赋予机选红蓝球
                        for (var i = 0; i < lotteryReadKeyNum; i++)
                        {
                            // 机选出一组
                            GeneratingRandomBalls(lotteryRecords[lotteryCount][i]);
                        }
                        Console.WriteLine("\n机选完成！");
                        return true;
                    }

                    if (isSystem.KeyChar == 'n')
                    {
                        break;
                    }

                    PrintErrorMessage("\n请输入正确的操作符！");
                }

                return false;
            }
            // 选择倍数
            void SelectMultiples()
            {
                while (true)
                {
                    //5.输入倍数，范围约束
                    Console.WriteLine("\n请输入购买的倍数，值需在1~99范围内");
                    var multipleReadLine = Console.ReadLine();
                    // 异常输入重新输入
                    if (!int.TryParse(multipleReadLine, out var multipleReadValue) || multipleReadValue < 0 || multipleReadValue > 100)
                    {
                        PrintErrorMessage("\n请输入正确的操作值！");
                        continue;
                    }
                    lotteryRecords[lotteryCount][0][7] = multipleReadValue;
                    break;
                }
            }
            // 是否可以购买彩票
            bool IsBuyLottery()
            {
                if (lotteryCount == lotteryRecords.Length)
                {
                    PrintErrorMessage("\n一次开奖内可购买的彩票数已满，无法购买！");
                    return true;
                }
                
                if (openLotteryRecord[0] == 0) return false;
                PrintErrorMessage("\n已经开奖，无法购买彩票！");
                return true;

            }
            // 手动选择球号
            void ManualInputBallValue(int groupCount)
            {
                var redCount = 0;
                while (redCount < 6)
                {
                redCount: Console.WriteLine($"\n请输入第{redCount + 1}个红球值,值需在1~33范围内");
                    var redReadLine = Console.ReadLine();
                    // 异常输入重新输入
                    if (!int.TryParse(redReadLine, out var readValue) || readValue < 0 || readValue > 34)
                    {
                        PrintErrorMessage("\n请输入正确的操作值！");
                        continue;
                    }
                    // 判断输入的红球值是否出现过
                    if (lotteryRecords[lotteryCount][groupCount].Contains(readValue))
                    {
                        PrintErrorMessage("\n不能输入重复的红球值！");
                        continue;
                    }
                    //6.1 第二组后最后一次输入需要判断是否和之前的彩票序列重复
                    if (groupCount > 0 && redCount > 4)
                    {
                        for (var i = 0; i < groupCount; i++)
                        {
                            if (!lotteryRecords[lotteryCount][i].Contains(readValue)) continue;
                            PrintErrorMessage("此组数值和此彩票其他数值重复，请重新输入最后一个数值！");
                            goto redCount;
                        }
                    }
                    lotteryRecords[lotteryCount][groupCount][redCount] = readValue;
                    redCount++;

                }
                // 给输入的红球排序
                BubbleSort(lotteryRecords[lotteryCount][groupCount], 6);
                Console.WriteLine("\n红球输入完毕");
                while (true)
                {
                    //4.输入蓝球，范围约束
                    Console.WriteLine("\n请输入蓝球值，值需在1~16范围内");
                    var blueReadLine = Console.ReadLine();
                    // 异常输入重新输入
                    if (!int.TryParse(blueReadLine, out var blueReadValue) || blueReadValue < 0 || blueReadValue > 17)
                    {
                        PrintErrorMessage("\n请输入正确的操作值！");
                        continue;
                    }
                    lotteryRecords[lotteryCount][groupCount][6] = blueReadValue;
                    break;
                }
                Console.WriteLine("\n蓝球输入完毕");
            }
            // 查看已购买彩票
            void ViewTicketsPurchased()
            {
                //判断是否已购买彩票
                if (lotteryRecords[0][0][0] == 0)
                {
                    PrintErrorMessage("\n请购买彩票后再来查看！");
                }

                // 彩票层
                for (var i = 0; i < lotteryRecords.Length; i++)
                {
                    //此张彩票序列未购买
                    if (lotteryRecords[i][0][0] == 0) break;
                    Console.WriteLine($"\n您购买的第{i + 1}张彩票号码数为：");
                    // 单个彩票号码层
                    for (var j = 0; j < lotteryRecords[i].Length; j++)
                    {
                        // 此张彩票此组号码未购买
                        if (lotteryRecords[i][j][0] == 0) break;
                        Console.Write($"第 {j + 1} 组数字为：\t红球值：");
                        // 打印此张彩票此组号码值
                        for (var k = 0; k < 7; k++)
                        {
                            if (k < 6) Console.Write($" {lotteryRecords[i][j][k]} ");
                            else Console.WriteLine($" -- 蓝球值：{lotteryRecords[i][j][k]}");
                        }
                    }
                    Console.WriteLine($"\n您购买的第{i + 1}张彩票的倍数为：{lotteryRecords[i][0][7]}");
                }
            }
            // 查看中奖情况
            void CheckWinnings()
            {
                if (openLotteryRecord[0] == 0)
                {
                    PrintErrorMessage("还没开奖，无法查看中奖情况！");
                    return;
                }
                // 遍历所有彩票
                for (var i = 0; i < lotteryCount; i++)
                {
                    //此张彩票序列未购买，不计算
                    if (lotteryRecords[i][0][0] == 0) break;
                    // 遍历每组数字
                    for (var j = 0; j < lotteryRecords[i].Length; j++)
                    {
                        var redHit = 0;
                        var blueHit = false;
                        // 此张彩票此组号码未购买，不计算
                        if (lotteryRecords[i][j][7] == 0) break;
                        // 遍历计算
                        for (var k = 0; k < 7; k++)
                        {
                            if (k < 6)
                            {
                                if (lotteryRecords[i][j][k] == openLotteryRecord[k]) redHit++;
                            }
                            else
                            {
                                if (lotteryRecords[i][j][k] == openLotteryRecord[k]) blueHit = true;
                            }
                        }
                        // 获取这种彩票的倍数
                        var multiple = lotteryRecords[i][0][7];
                        // 根据中奖规则来判断此组彩票是几等奖，并加入总金额。
                        // 根据蓝球是否选择进行分类
                        if (blueHit)
                        {
                            switch (redHit)
                            {
                                case 6:
                                    awardRecord[0]++;
                                    money += 5_000_000 * multiple;
                                    break;
                                case 5:
                                    awardRecord[2]++;
                                    money += 3_000 * multiple;
                                    break;
                                case 4:
                                    awardRecord[3]++;
                                    money += 200 * multiple;
                                    break;
                                case 3:
                                    awardRecord[4]++;
                                    money += 10 * multiple;
                                    break;
                                case 2:
                                case 1:
                                case 0:
                                    awardRecord[5]++;
                                    money += 5 * multiple;
                                    break;
                            }
                        }
                        else
                        {
                            switch (redHit)
                            {
                                case 6:
                                    awardRecord[1]++;
                                    money += 50_000 * multiple;
                                    break;
                                case 5:
                                    awardRecord[3]++;
                                    money += 200 * multiple;
                                    break;
                                case 4:
                                    awardRecord[4]++;
                                    money += 10 * multiple;
                                    break;

                            }
                        }
                        Console.WriteLine($"此彩票红球中{redHit}个，蓝球{(blueHit ? "中了" : "没中")}");
                    }
                }
                // 中奖号码是
                Console.WriteLine("中奖号码为：");
                foreach (var i in openLotteryRecord)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                // 显示中奖情况和中奖总金额
                for (var i = 0; i < awardRecord.Length; i++)
                {
                    if (awardRecord[i] != 0) Console.WriteLine($"{i + 1} 等奖数量：{awardRecord[i]}");
                }

                Console.WriteLine($"中奖金额：{money:C}");
            }
        }

        public static void Case3()
        {
            int[] array = { 3, 5, 2, 1, 8, };
            BubbleSort(array);
            foreach (var i in array)
            {
                Console.WriteLine(i);
            }

            return;

            void BubbleSort(int[] arr)
            {
                for (var i = arr.Length; i > 0; i--)
                {
                    for (var j = 1; j < i; j++)
                    {
                        // 如果前大于后，则替换
                        if (arr[j] > arr[j - 1]) continue;
                        (arr[j], arr[j - 1]) = (arr[j - 1], arr[j]);
                    }
                }
            }
        }

        private struct Shop
        {
            private string _shopNameValue;
            private double _shopPriceValue;
            public string ShopName
            {
                get => _shopNameValue;
                set => _shopNameValue = value;
            }
            public double ShopPrice
            {
                get => _shopPriceValue;
                set => _shopPriceValue = value;
            }
        }

        public static void Case2()
        {
            Console.WriteLine("欢迎使用简易超市管理系统");
            Console.WriteLine("------------------------\n");

            var isExit = false;
            var shopList = new Shop[3];
            var nowShopNumber = 0;
            while (!isExit)
            {
                Console.WriteLine("\n请选择您的操作：");
                Console.WriteLine("\t1.录入商品");
                Console.WriteLine("\t2.查看商品");
                Console.WriteLine("\t3.查看最新商品");
                Console.WriteLine("\t4.下架商品");
                Console.WriteLine("\t5.退出系统");
                var readKey = Convert.ToInt32(Console.ReadLine());
                switch (readKey)
                {
                    case 1:
                        var isAgain = true;
                        // 可重复添加
                        while (isAgain)
                        {
                            // 商品数组满后不允许添加
                            if (nowShopNumber == shopList.Length)
                            {
                                Console.WriteLine("商品列表已满，无法继续录入");
                                break;
                            }
                            // 商品输入
                            Console.WriteLine("请输入商品名称：");
                            var readShopName = Console.ReadLine();
                            shopList[nowShopNumber].ShopName = readShopName;
                            Console.WriteLine("请输入商品价格：");
                            var readShopPrice = Convert.ToDouble(Console.ReadLine());
                            shopList[nowShopNumber].ShopPrice = readShopPrice;
                            nowShopNumber++;
                            // 加入异常符号判断
                            while (true)
                            {
                                Console.WriteLine("是否继续录入？y | n");
                                var readIsOk = Console.ReadKey();
                                Console.WriteLine();
                                if (readIsOk.KeyChar == 'y') break;
                                if (readIsOk.KeyChar == 'n')
                                {
                                    isAgain = false;
                                    break;
                                }
                                Console.WriteLine("错误操作编号不存在！，请重新选择");
                            }
                        }
                        break;
                    case 2:
                        // 遍历展示商品数组
                        Console.WriteLine("商品序号\t商品名称\t商品价格");
                        for (var i = 0; i < nowShopNumber; i++)
                        {
                            Console.WriteLine(i + "\t\t" + shopList[i].ShopName + "\t\t" + shopList[i].ShopPrice);
                        }
                        break;
                    case 3:
                        //反转商品列表来实现打印最新商品功能。
                        for (int i = 0, j = nowShopNumber - 1; i < nowShopNumber / 2; i++, j--)
                            (shopList[i], shopList[j]) = (shopList[j], shopList[i]);
                        for (int i = 0, j = nowShopNumber - 1; i < nowShopNumber; i++, j--)
                        {
                            Console.WriteLine(j + "\t\t" + shopList[i].ShopName + "\t\t" + shopList[i].ShopPrice);
                        }
                        for (int i = 0, j = nowShopNumber - 1; i < nowShopNumber / 2; i++, j--)
                            (shopList[i], shopList[j]) = (shopList[j], shopList[i]);
                        break;
                    case 4:
                        Console.WriteLine("输入下架的序号：");
                        var readDeleteKey = Convert.ToInt32(Console.ReadLine());
                        //判断index是否越界
                        if (readDeleteKey < 0 || readDeleteKey >= nowShopNumber)
                        {
                            Console.WriteLine("您输入的序号超出了已有商品序号范围！请重新操作");
                            break;
                        }
                        for (var i = readDeleteKey + 1; i < nowShopNumber; i++)
                        {
                            //替换
                            shopList[i - 1] = shopList[i];
                        }

                        nowShopNumber--;
                        Console.WriteLine("下架成功~~~");
                        break;
                    case 5:
                        Console.WriteLine("感谢使用，再见！");
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("输入操作编号不存在！");
                        break;

                }
            }

        }

        // 删除数组元素
        public static void Case1()
        {
            int[] array = { 1, 2, 3 };
            DeleteArray(array, 0);
            foreach (var i in array)
            {
                Console.WriteLine(i);
            }

            void DeleteArray(int[] arr, int index)
            {
                //判断index是否越界
                if (index < 0 || index >= arr.Length) return;
                for (var i = index + 1; i < arr.Length; i++)
                {
                    arr[i - 1] = arr[i];
                }
                arr[arr.Length - 1] = 0;
            }
        }
    }
}
