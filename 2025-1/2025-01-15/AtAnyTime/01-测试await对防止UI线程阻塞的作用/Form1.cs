using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_测试await对防止UI线程阻塞的作用
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            Task.Run(LongTimeAsync);
        }

        private  void LongTimeAsync()
        {
            
            

            Console.WriteLine(j);

        }
    }
}
