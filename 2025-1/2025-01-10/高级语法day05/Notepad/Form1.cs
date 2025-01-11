using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Notepad_Component_Rlue;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //读取插件目录下的 dll 文件
            // 1.1 获取当前运行文件的绝对路径名
            var path = Assembly.GetExecutingAssembly().Location;
            // 1.2 获取当前文件的所在目录的路径名
            path = Path.GetDirectoryName(path);
            // 1.3 拼接插件目录名
            path = Path.Combine(path, "Component_Plug_In");
            // 1.4 读取插件目录下的所有 dll 文件路径
            var files = Directory.GetFiles(path);
            // 2. 循环读取所有 dll 文件，判断是否满足插件的规范
            foreach (var file in files)
            {
                // 2.1 获取文件路径的程序集
                var assembly = Assembly.LoadFile(file);
                // 2.2 获取程序集中的公共类型
                var types = assembly.GetExportedTypes();
                //2.3 循环判定types中的类型是否满足实现了规则接口，且不能说抽象类
                foreach (var type in types)
                {
                    if (!typeof(IComponentRule).IsAssignableFrom(type) || type.IsAbstract) continue;
                    //2.4 实例化符合规范的实现类
                    var instance = (IComponentRule)Activator.CreateInstance(type);
                    //2.5 获取实现类的Name属性添加到菜单栏中
                    var toolStripItem = menuStrip1.Items.Add(instance.Name);
                    // 把实现类对象放到菜单项的tag属性中存储
                    toolStripItem.Tag = instance;
                    // 给菜单项案例添加点击事件
                    toolStripItem.Click += ToolStripItem_Click;
                }
            }
        }
        /// <summary>
        /// 菜单项点击时，触发插件实现类的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripItem_Click(object sender, EventArgs e)
        {
            // 获取按钮对象
            var toolStripItem = (ToolStripItem)sender;
            //然后在获取按钮对象中Tag绑定的插件对象
            var tag = (IComponentRule)toolStripItem.Tag;
            //调用方法，完成插件功能的实现
            tag.ChangeText(textBox1);
        }
    }
}