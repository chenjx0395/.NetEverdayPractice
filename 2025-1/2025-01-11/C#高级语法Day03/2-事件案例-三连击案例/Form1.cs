using System.Windows.Forms;

namespace _2_事件案例_三连击案例
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userControl.TripleStrike += () =>
            {
                MessageBox.Show("触发了自定义组件的三连击事件!");
            };
        }
    }
}
