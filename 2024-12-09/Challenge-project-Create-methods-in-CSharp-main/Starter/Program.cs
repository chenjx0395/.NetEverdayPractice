using System;

Random random = new Random();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

//玩家控制台位置
int playerX = 0;
int playerY = 0;

//食物的控制台位置
int foodX = 0;
int foodY = 0;

//可用球员和食物串
string[] states = { "('-')", "(^-^)", "(X_X)" };
string[] foods = { "@@@@@", "$$$$$", "#####" };

//控制台中显示的当前玩家字符串
string player = states[0];

// 当前食品获得数
int food = 0;
// 食品部位，等于5时代表吃完了一个完整的食品
bool[] foodPart = new bool[5];


// 游戏入口
InitializeGame();

// 创建任务监测窗口大小变化
var monitorTas = Task.Run(() =>
{
    while (true)
    {
        if (TerminalResized())
        {
            Console.WriteLine("窗口大小被改变，游戏退出！");
            Environment.Exit(0);
        }
        Thread.Sleep(100); // 避免高 CPU 占用
    }
});

while (!shouldExit)
{
    Move();
}
// 等待监测任务完成（通常是因为程序退出时）
await monitorTas;


//如果调整了终端的大小，则返回true
bool TerminalResized()
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}

//在随机位置显示随机食物
void ShowFood()
{
    // 生成随机食物皮肤
    food = random.Next(0, foods.Length);

    // 将食物位置更新到随机位置
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);

    // 在指定地点展示食物
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);

}

//更改玩家以匹配所消耗的食物
void ChangePlayer()
{
    player = states[food];

    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

//暂时阻止玩家移动
void FreezePlayer()
{
    System.Threading.Thread.Sleep(1000);
    player = states[0];
}

// 从控制台读取输入并移动玩家
void Move()
{
    if (player.Contains("(X_X)"))
    {
        FreezePlayer();
    }

    int lastX = playerX;
    int lastY = playerY;

    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.UpArrow:
            playerY--;
            break;
        case ConsoleKey.DownArrow:
            playerY++;
            break;
        case ConsoleKey.LeftArrow:
            playerX--;
            break;
        case ConsoleKey.RightArrow:
            playerX++;
            break;
        case ConsoleKey.Escape:
            shouldExit = true;
            break;
        default:
            Console.WriteLine("不正常的键盘输入，游戏退出！");
            Environment.Exit(0);
            break;
    }

    //清除上一位置的字符
    Console.SetCursorPosition(lastX, lastY);
    for (int i = 0; i < player.Length; i++)
    {
        Console.Write(" ");
    }
    //判断食物是否吃完；
    isFoodConsume();

    //将玩家位置保持在终端窗口的范围内
    playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
    playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

    //在新位置绘制玩家
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

//清空控制台，显示食物和玩家
void InitializeGame()
{
    Console.Clear();
    ShowFood();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}



//判断食物是否被吃完，如果吃完，刷新食物，并更新玩家的外观
void isFoodConsume()
{
    //人物右端
    int playerEnd = playerX + 4;
    //食物右端
    int foodXEnd = foodX + 4;

    //人物左右端都在食物区间
    if (playerX == foodX && playerY == foodY)
    {
        FoodConsume();
        return;
    }
    //人物右端在食物区间
    if (playerEnd >= foodX && playerEnd < foodXEnd && playerY == foodY)
    {
        //将食物记录从起始端至人物右端全置为true
        for (int i = playerEnd - foodX; i >= 0; i--)
        {
            foodPart[i] = true;
        }
    }
    //人物左端在食物区间
    if (playerX > foodX && playerX < foodXEnd && playerY == foodY)
    {
        //将食物记录从末端至人物左端全置为true
        for (int i = playerX - foodX; i < 5; i++)
        {
            foodPart[i] = true;
        }
    }
    // 判断食物是否全部吃完
    for (int i = 0; i < foodPart.Length; i++)
    {
        // 代表有食物没吃完
        if (!foodPart[i])
        {
            return;
        }
    }
    FoodConsume();
}


void FoodConsume()
{

    
    //代表食物已被吃完
    for (global::System.Int32 i = 0; i < foodPart.Length; i++)
    {
        foodPart[i] = false;
    }
    food++;
    ShowFood();
    ChangePlayer();
}
