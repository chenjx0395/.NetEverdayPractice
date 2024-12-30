using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsCase1
{
    public partial class Form1 : Form
    {
        private Random _random = new Random();
        private bool isWin = false;
        public Form1()
        {
            InitializeComponent();
            // 允许子线程操作主（UI）线程创建的控件
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var thread1 = new Thread(TuZiRun)
            {
                IsBackground = true
            };
            var thread2 = new Thread(WuGuaiRun)
            {
                IsBackground = true
            };
            thread1.Start();
            thread2.Start();

        }

        private void TuZiRun()
        {
            while (true)
            {
                var locationX = pictureBox1.Location.X;
                var locationY = pictureBox1.Location.Y;
                // 兔子跑一次的距离
                var step = _random.Next(10,18);
                if (locationX >= 930)
                {
                    if (isWin) return;
                    isWin = true;
                    MessageBox.Show("兔子胜利了！");
                    return;
                }

                // 兔子跑一次休息的时间
                var sleepTime = _random.Next(300,500);
            
                pictureBox1.Location = new Point(locationX + step, locationY);
                Thread.Sleep(sleepTime);
            }
        }
        private void WuGuaiRun()
        {
            while (true)
            {
                var locationX = pictureBox2.Location.X;
                var locationY = pictureBox2.Location.Y;
                // 乌龟跑一次的距离
                var step = _random.Next(5, 10);
                if (locationX >= 930)
                {
                    if (isWin) return;
                    isWin = true;
                    MessageBox.Show("乌龟胜利了！");
                    return;
                }
                // 乌龟跑一次休息的时间
                var sleepTime = _random.Next(100, 300);

                pictureBox2.Location = new Point(locationX + step, locationY);

                Thread.Sleep(sleepTime);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            var pen = new Pen(Color.Red,5);
            graphics.DrawLine(pen,new Point(1000,0),new Point(1000,400));
        }
    }
}
