using System;
using System.Windows.Forms;

namespace WindowsFormsAppCase2
{
    public partial class Form1 : Form
    {
        private Tank tank;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tank = new Tank();
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.DrawImage(tank.OwnImage, tank.X, tank.Y);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tank.X = 0;
            tank.Y = 0;
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("askdaskhdkasdhsa");
            var eKeyCode = e.KeyCode;
            switch (eKeyCode)
            {
                case Keys.W:
                case Keys.Up:
                    tank.Direction = Direction.Up;
                    break;
                case Keys.S:
                case Keys.Down:
                    tank.Direction = Direction.Down;
                    break;
                case Keys.A:
                case Keys.Left:
                    tank.Direction = Direction.Left;
                    break;
                case Keys.D:
                case Keys.Right:
                    tank.Direction = Direction.Right;
                    break;
            }

            tank.OwnImage = null;
        }
    }
}
