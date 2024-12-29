using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExercise02
{
    public partial class VerificationCode : Form
    {
        private Random random = new Random();
        public VerificationCode()
        {
            InitializeComponent();
        }

        private void VerificationCode_Paint(object sender, PaintEventArgs e)
        {
            DrawCode();
        }

        private void DrawCode()
        {
            Color[] colors = { Color.Black, Color.Red, Color.Green, Color.Blue, Color.Coral, Color.HotPink };
            char[] Code =
            { 'a', 'b', 'c', 'd', 'A', 'B', 'C', 'D',
                '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var bitmap = new Bitmap(180, 50);
            var graphics = Graphics.FromImage(bitmap);
            // 验证码符号
            for (var i = 0; i < 4; i++)
            {
                var codeRandom = random.Next(0, 17);
                var step = i * 20;
                var xRandom = random.Next(-5, 6);
                var yRandom = random.Next(-8, 9);
                graphics.DrawString(Code[codeRandom].ToString(), new Font("楷体", 12), new SolidBrush(colors[random.Next(0, colors.Length)]), new PointF(xRandom + step, yRandom));
            }
            // 线条
            for (var i = 0; i < 20; i++)
            {
                graphics.DrawLine(new Pen(new SolidBrush(colors[random.Next(0, colors.Length)]), 1),
                    new Point(random.Next(0, bitmap.Width), random.Next(0, bitmap.Height)),
                    new Point(random.Next(0, bitmap.Width), random.Next(0, bitmap.Height)));
            }

            // 背景点
            for (int i = 0; i < 600; i++)
            {
                bitmap.SetPixel(random.Next(0, bitmap.Width), random.Next(0, bitmap.Height), colors[random.Next(0, colors.Length)]);
            }

            pictureBox1.Image = bitmap;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DrawCode();
        }

        private void VerificationCode_Load(object sender, EventArgs e)
        {

        }
    }
}
