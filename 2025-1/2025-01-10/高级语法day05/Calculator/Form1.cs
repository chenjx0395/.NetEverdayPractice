using System;
using System.Drawing;
using System.Windows.Forms;
using Calculator_Component_Factory;
using Calculator_Component_Rule;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 通过工厂方法获取插件对象集合
            var plugIns = ComponentFactory.LoadPlugIns();
            // 遍历插件对象，为插件对象创建相关按钮
            for (var i = 0; i < plugIns.Count; i++)
            {
                //1. 创建按钮
                var button = new Button();
                button.Location = new Point(100 + i * 80, 150);
                button.Text = plugIns[i].Name;
                button.Font = new Font(FontFamily.GenericMonospace, 16);
                //2. 给插件对象的num属性赋值
                button.Tag = plugIns[i];
                button.Click += (buttonSender, buttonE) =>
                {
                    var plug = (ComponentRule)button.Tag;
                    plug.Num1 = Convert.ToInt32(textBox1.Text);
                    plug.Num2 = Convert.ToInt32(textBox2.Text);
                    textBox3.Text = plug.CalculationMethod().ToString();
                };
                this.Controls.Add(button);
            }
        }
    }
}