using System;
using System.Windows.Forms;

namespace 窗口传值
{
    public partial class Form1 : Form
    {
        public static string msg;

        public class EventReturnValue : EventArgs
        {
            public string msg { get; set; }
        }
        // 定义事件
        public event EventHandler MyEvent;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2("根据构造函数传值");
            form2.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            msg = "根据静态字段传参";
            new Form2().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();    
            // 绑定事件
            MyEvent += form2.bind;
            MyEvent.Invoke(this,new EventReturnValue(){msg = "通过事件传值"});
            form2.Show();
        }
        
       
    }
}