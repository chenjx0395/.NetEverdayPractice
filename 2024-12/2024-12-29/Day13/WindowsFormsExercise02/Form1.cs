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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var graphics = this.CreateGraphics();
            // 创建画笔，指定颜色，宽度属性
            var pen = new Pen(Color.Red,2);
            // 使用画笔在指定线段绘画
            graphics.DrawLine(pen,new Point(20,40),new Point(80,120));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var eGraphics = e.Graphics;
            var pen = new Pen(Color.Blue,2);
            eGraphics.DrawLine(pen,new Point(50,50),new Point(130,130));
        }
    }
}
