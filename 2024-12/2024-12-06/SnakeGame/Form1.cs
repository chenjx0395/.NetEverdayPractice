using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
namespace SnakeGame
{
    public partial class MainForm : Form
    {

        private List<Point> snake = new List<Point>(); // 用于存储蛇的位置
        private int snakeSegmentSize = 20; // 每一节的大小（方块尺寸）
        // 当前方向
        private string currentDirection = "Right"; // 初始方向为右
        private Point food;                // 表示食物的位置
        private Random random = new Random(); // 用于随机生成食物位置



        public MainForm()
        {
            InitializeComponent();
            InitializeGame();
            // 启用键盘事件
            this.KeyDown += new KeyEventHandler(Form_KeyDown);

        }
        // 初始化游戏
        private void InitializeGame()
        {
            // 清空蛇的位置列表
            snake.Clear();

            // 游戏区域的中间位置
            int startX = gamePanel.Width / 2;
            int startY = gamePanel.Height / 2;

            // 添加三个方块，形成初始蛇
            snake.Add(new Point(startX, startY)); // 蛇头
            snake.Add(new Point(startX - snakeSegmentSize, startY)); // 身体1
            snake.Add(new Point(startX - 2 * snakeSegmentSize, startY)); // 身体2

            // 刷新游戏区域
            gamePanel.Invalidate();

            // 初始化食物
            GenerateFood();
        }
        // Panel 的渲染
        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // 设置蛇身体颜色和边框颜色
            Brush snakeBrush = Brushes.Red;
            Pen borderPen = Pens.Black; // 边框颜色

            // 定义间隔大小
            int gap = 2;

            // 绘制蛇的每一节
            foreach (Point segment in snake)
            {
                // 在每个方块内部缩小间隔大小
                g.FillRectangle(snakeBrush,
                    segment.X + gap,
                    segment.Y + gap,
                    snakeSegmentSize - 2 * gap,
                    snakeSegmentSize - 2 * gap);

                // 绘制蛇的边框
                g.DrawRectangle(borderPen, segment.X, segment.Y, snakeSegmentSize, snakeSegmentSize);
            }
            // 绘制食物
            g.FillRectangle(Brushes.Red, food.X, food.Y, snakeSegmentSize, snakeSegmentSize);
        }
        // 读取键盘事件
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // 根据按键更改蛇的方向
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (currentDirection != "Down") currentDirection = "Up";
                    break;
                case Keys.S:
                    if (currentDirection != "Up") currentDirection = "Down";
                    break;
                case Keys.A:
                    if (currentDirection != "Right") currentDirection = "Left";
                    break;
                case Keys.D:
                    if (currentDirection != "Left") currentDirection = "Right";
                    break;
            }
        }
        // 创建蛇的移动方法
        private void MoveSnake()
        {
            // 获取蛇头的位置
            Point head = snake[0];

            // 根据方向计算新的头部位置
            Point newHead = head;
            switch (currentDirection)
            {
                case "Up":
                    newHead.Y -= snakeSegmentSize;
                    break;
                case "Down":
                    newHead.Y += snakeSegmentSize;
                    break;
                case "Left":
                    newHead.X -= snakeSegmentSize;
                    break;
                case "Right":
                    newHead.X += snakeSegmentSize;
                    break;
            }
            if (snake[0] == food)
            {
                // 吃到食物，蛇增长一格
                snake.Add(snake[snake.Count - 1]);
                // 更新分数
                int currentScore = int.Parse(score.Text); // 将字符串转换为整数
                currentScore += 1; // 分数加1
                score.Text = currentScore.ToString(); // 更新Label的文本

                // 生成新的食物
                GenerateFood();
            }

            // 检测是否撞到边界
            if (newHead.X < 0 || newHead.Y < 0 ||
                newHead.X >= gamePanel.Width || newHead.Y >= gamePanel.Height)
            {
                // 如果超出边界，则游戏结束
                GameOver();
                return;
            }
            // 检测是否碰到自己身体
            if (snake.Contains(newHead))
            {
                // 如果蛇头的位置出现在身体列表中，则游戏结束
                GameOver();
                return;
            }


            // 在蛇的头部插入新位置
            snake.Insert(0, newHead);

            // 删除蛇尾（使蛇保持相同长度）
            snake.RemoveAt(snake.Count - 1);

            // 刷新界面
            gamePanel.Invalidate();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
        }
        // 游戏结束
        private void GameOver()
        {
            // 停止计时器
            gameTimer.Stop();

            // 显示游戏结束提示
            MessageBox.Show($"Game Over! Your score: {snake.Count - 3}",
                "Snake Game",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // 重置游戏状态
            ResetGame();
        }

        // 初始化食物
        private void GenerateFood()
        {
            while (true)
            {
                // 随机生成食物位置
                int x = random.Next(0, gamePanel.Width / snakeSegmentSize) * snakeSegmentSize;
                int y = random.Next(0, gamePanel.Height / snakeSegmentSize) * snakeSegmentSize;
                Point newFood = new Point(x, y);

                // 检查食物是否与蛇重叠
                if (!snake.Contains(newFood))
                {
                    food = newFood;
                    break;
                }
            }
        }

        // 重置游戏
        private void ResetGame()
        {
            // 重置蛇的初始状态
            snake = new List<Point>
    {
        new Point(100, 100),
        new Point(80, 100),
        new Point(60, 100)
    };

            currentDirection = "Right"; // 重置初始方向
            score.Text = "0";
            GenerateFood();             // 重新生成食物

            // 重置计时器并启动
            gameTimer.Interval = 200;   // 恢复初始速度（可选）
            gameTimer.Start();

            // 刷新界面
            gamePanel.Invalidate();
        }

    }
}
