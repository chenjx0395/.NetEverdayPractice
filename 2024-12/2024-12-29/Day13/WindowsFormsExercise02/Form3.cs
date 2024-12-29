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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            var bitmap = new Bitmap(300,300);
            var graphics = Graphics.FromImage(bitmap);

            // 绘图
            graphics.DrawEllipse(new Pen(Color.Red, 3), 0, 0, 60, 60);
            graphics.DrawEllipse(new Pen(Color.Yellow, 3), 70, 0, 60, 60);
            graphics.DrawEllipse(new Pen(Color.Blue, 3), 140, 0, 60, 60);
            graphics.DrawEllipse(new Pen(Color.Green, 3), 30, 30, 60, 60);
            graphics.DrawEllipse(new Pen(Color.Pink, 3), 100, 30, 60, 60);

            // 将图形文件植入图片控件中
            pictureBox1.Image = bitmap;

            // 持久化
            bitmap.Save(@"D://wuhuan.jpg");
        }
    }
}
