using System;
using System.Windows.Forms;

namespace _2_事件案例_三连击案例
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private int i;
        // 1. 定义事件
        public event Action TripleStrike;

        private void button_Click(object sender, EventArgs e)
        {
            if (++i != 3) return;
            // 2. 触发事件
            TripleStrike();
            i = 0;
        }
    }
}
