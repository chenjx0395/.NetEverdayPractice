using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExercise02
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            var eGraphics = e.Graphics;
            // 高质量展示，例如：消除锯齿，线条更加清晰
            eGraphics.SmoothingMode = SmoothingMode.HighQuality;

            var pen = new Pen(Color.Orange,3);
            eGraphics.DrawEllipse(pen,50,50,200,130);

            // 通过坐标来填充颜色
            eGraphics.FillEllipse(new SolidBrush(Color.Pink), 50, 50, 200,130);
        }
    }
}
