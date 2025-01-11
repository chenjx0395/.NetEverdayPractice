using System.Drawing;
using System.Windows.Forms;

namespace _3_事件案例_登录控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userLogin1.Login += (s, e) =>
            {
                var user = (User)e;
                if (user.Account == "admin" && user.Password == "123")
                {
                    MessageBox.Show("登录成功");
                    BackColor = Color.Green;
                }
                else
                {
                    MessageBox.Show("登录失败");
                    BackColor = Color.Red;
                }
            };
        }

    }
}
