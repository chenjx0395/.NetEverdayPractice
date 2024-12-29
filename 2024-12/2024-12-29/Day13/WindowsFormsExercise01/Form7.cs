using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExercise01
{
    public partial class Form7 : Form
    {
        private static readonly string[] paths = new []
        {
            "D:\\资源\\壁纸\\MKN.jpg",
            "D:\\资源\\壁纸\\pexels-elena-zhuravleva-647531-1457812.jpg",
            "D:\\资源\\壁纸\\pexels-maoriginalphotography-1485894.jpg",
            "D:\\资源\\壁纸\\pexels-pok-rie-33563-2049422.jpg"
        };

        private static int _count = 0;
       public Form7()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = paths[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = paths[++_count % 4];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = paths[Math.Abs(--_count) % 4];
        }
    }
}
