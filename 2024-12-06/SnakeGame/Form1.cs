using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
namespace SnakeGame
{
    public partial class MainForm : Form
    {

        private List<Point> snake = new List<Point>(); // ���ڴ洢�ߵ�λ��
        private int snakeSegmentSize = 20; // ÿһ�ڵĴ�С������ߴ磩
        // ��ǰ����
        private string currentDirection = "Right"; // ��ʼ����Ϊ��
        private Point food;                // ��ʾʳ���λ��
        private Random random = new Random(); // �����������ʳ��λ��



        public MainForm()
        {
            InitializeComponent();
            InitializeGame();
            // ���ü����¼�
            this.KeyDown += new KeyEventHandler(Form_KeyDown);

        }
        // ��ʼ����Ϸ
        private void InitializeGame()
        {
            // ����ߵ�λ���б�
            snake.Clear();

            // ��Ϸ������м�λ��
            int startX = gamePanel.Width / 2;
            int startY = gamePanel.Height / 2;

            // ����������飬�γɳ�ʼ��
            snake.Add(new Point(startX, startY)); // ��ͷ
            snake.Add(new Point(startX - snakeSegmentSize, startY)); // ����1
            snake.Add(new Point(startX - 2 * snakeSegmentSize, startY)); // ����2

            // ˢ����Ϸ����
            gamePanel.Invalidate();

            // ��ʼ��ʳ��
            GenerateFood();
        }
        // Panel ����Ⱦ
        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // ������������ɫ�ͱ߿���ɫ
            Brush snakeBrush = Brushes.Red;
            Pen borderPen = Pens.Black; // �߿���ɫ

            // ��������С
            int gap = 2;

            // �����ߵ�ÿһ��
            foreach (Point segment in snake)
            {
                // ��ÿ�������ڲ���С�����С
                g.FillRectangle(snakeBrush,
                    segment.X + gap,
                    segment.Y + gap,
                    snakeSegmentSize - 2 * gap,
                    snakeSegmentSize - 2 * gap);

                // �����ߵı߿�
                g.DrawRectangle(borderPen, segment.X, segment.Y, snakeSegmentSize, snakeSegmentSize);
            }
            // ����ʳ��
            g.FillRectangle(Brushes.Red, food.X, food.Y, snakeSegmentSize, snakeSegmentSize);
        }
        // ��ȡ�����¼�
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            // ���ݰ��������ߵķ���
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
        // �����ߵ��ƶ�����
        private void MoveSnake()
        {
            // ��ȡ��ͷ��λ��
            Point head = snake[0];

            // ���ݷ�������µ�ͷ��λ��
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
                // �Ե�ʳ�������һ��
                snake.Add(snake[snake.Count - 1]);
                // ���·���
                int currentScore = int.Parse(score.Text); // ���ַ���ת��Ϊ����
                currentScore += 1; // ������1
                score.Text = currentScore.ToString(); // ����Label���ı�

                // �����µ�ʳ��
                GenerateFood();
            }

            // ����Ƿ�ײ���߽�
            if (newHead.X < 0 || newHead.Y < 0 ||
                newHead.X >= gamePanel.Width || newHead.Y >= gamePanel.Height)
            {
                // ��������߽磬����Ϸ����
                GameOver();
                return;
            }
            // ����Ƿ������Լ�����
            if (snake.Contains(newHead))
            {
                // �����ͷ��λ�ó����������б��У�����Ϸ����
                GameOver();
                return;
            }


            // ���ߵ�ͷ��������λ��
            snake.Insert(0, newHead);

            // ɾ����β��ʹ�߱�����ͬ���ȣ�
            snake.RemoveAt(snake.Count - 1);

            // ˢ�½���
            gamePanel.Invalidate();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
        }
        // ��Ϸ����
        private void GameOver()
        {
            // ֹͣ��ʱ��
            gameTimer.Stop();

            // ��ʾ��Ϸ������ʾ
            MessageBox.Show($"Game Over! Your score: {snake.Count - 3}",
                "Snake Game",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // ������Ϸ״̬
            ResetGame();
        }

        // ��ʼ��ʳ��
        private void GenerateFood()
        {
            while (true)
            {
                // �������ʳ��λ��
                int x = random.Next(0, gamePanel.Width / snakeSegmentSize) * snakeSegmentSize;
                int y = random.Next(0, gamePanel.Height / snakeSegmentSize) * snakeSegmentSize;
                Point newFood = new Point(x, y);

                // ���ʳ���Ƿ������ص�
                if (!snake.Contains(newFood))
                {
                    food = newFood;
                    break;
                }
            }
        }

        // ������Ϸ
        private void ResetGame()
        {
            // �����ߵĳ�ʼ״̬
            snake = new List<Point>
    {
        new Point(100, 100),
        new Point(80, 100),
        new Point(60, 100)
    };

            currentDirection = "Right"; // ���ó�ʼ����
            score.Text = "0";
            GenerateFood();             // ��������ʳ��

            // ���ü�ʱ��������
            gameTimer.Interval = 200;   // �ָ���ʼ�ٶȣ���ѡ��
            gameTimer.Start();

            // ˢ�½���
            gamePanel.Invalidate();
        }

    }
}
