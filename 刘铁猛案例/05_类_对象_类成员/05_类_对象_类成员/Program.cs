using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_类_对象_类成员
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Text = "哈哈";
            form.ShowDialog();
        }
    }
}
