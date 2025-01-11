using System;
using System.Windows.Forms;

namespace _3_事件案例_登录控件
{
    public partial class UserLogin : UserControl
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        public event EventHandler Login;
        private void loginButton_Click(object sender, EventArgs e)
        {
            var user = new User()
            {
                Account = account.Text,
                Password = password.Text
            };
            Login(this, (EventArgs)user);
        }

    }

    public class User : EventArgs
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
}
