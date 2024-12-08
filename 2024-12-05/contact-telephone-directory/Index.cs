using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using ContactSystem;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace contact_telephone_directory
{
    public partial class Index : Form
    {
        // 文件存储名
        const string FileName = "contacts.json";
        BindingList<Contact> contacts = new BindingList<Contact> { };
        public Index()
        {
            InitializeComponent();
            //加载List数据
            InitializeListBox();
            //绑定下拉框的值
            SelectSearchKey.Items.AddRange(new string[] { "姓名", "电话" });
            SelectSearchKey.SelectedIndex = 0;
            //初始化修改区信息
            if (contacts.Count != 0)
            {
                NameInfo.Text = contacts[0].Name;
                PhoneInfo.Text = contacts[0].Phone;
            }
        }
        // ListBox数据载入
        private void InitializeListBox()
        {
            NameListBox.DataSource = contacts;
            PhoneListBox.DataSource = contacts;
            NameListBox.DisplayMember = "Name";
            PhoneListBox.DisplayMember = "Phone";
        }

        //添加联系人
        public void AddContact(string name, string phone)
        {
            // 如果存在同名联系人则不允许添加
            if (IsExist(name))
            {
                MessageBox.Show("添加失败！存在同名联系人!");
            }
            else
            {
                contacts.Add(new Contact(name, phone));
                MessageBox.Show("联系人添加成功！");
            }
        }



        

        //返回联系人集合中对于姓名索引
        public int ExistIndex(string name)
        {
            int count = 0;
            foreach (Contact contact in contacts)
            {
                if (contact.Name == name)
                {
                    return count;
                }
                count++;
            }
            return -1;
        }

        //判定联系人列表中是否存在此输入姓名
        public bool IsExist(string name)
        {
            if (ExistIndex(name) == -1)
            {
                return false;
            }
            return true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        //存储联系人至本地文件
        public void SaveToFile(string path)
        {
            try
            {
                string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, json);
                MessageBox.Show("数据已成功保存到文件。");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存数据时出错: {ex.Message}");
            }
        }

        // 保存数据
        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath + "/" + FileName; 
            SaveToFile(path);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        // 搜索按钮事件
        private void button1_Click(object sender, EventArgs e)
        {
            int index = -1;

            if (SelectSearchKey.Text == "姓名")
            {
                index = contacts.IndexOf(contacts.FirstOrDefault(contact => contact.Name == SearchValue.Text));
            }
            else
            {
                index = contacts.IndexOf(contacts.FirstOrDefault(contact => contact.Phone == SearchValue.Text));
            }
            if (index == -1)
            {
                MessageBox.Show("没有相关联系人信息");
            }
            else
            {
                NameListBox.SelectedIndex = index;
                Contact contact = (Contact)NameListBox.SelectedItem;
                NameInfo.Text = contact.Name;
                PhoneInfo.Text = contact.Phone;
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); // 退出整个应用程序
        }

        private void AddControlButton_Click(object sender, EventArgs e)
        {
            // 实例化新的 ContactForm
            using (var contactForm = new AddContactForm())
            {
                // 显示 ContactForm 并等待用户点击确定按钮
                var result = contactForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    AddContact(contactForm.GetAddNameBoxValue(), contactForm.GetAddPhoneBoxValue());
                }

            }
        }
        //修改联系人
        public void UpdateContact(string name, string phone)
        {
            //查找，删除，添加 实现修改
            if (ExistIndex(name) != -1)
            {
                MessageBox.Show("修改失败！存在同名联系人！");
                return;
            }
            if (string.IsNullOrWhiteSpace(NameInfo.Text) || string.IsNullOrWhiteSpace(PhoneInfo.Text))
            {
                MessageBox.Show("修改失败！修改信息不能为空！");
                return;
            }
            contacts.RemoveAt(NameListBox.SelectedIndex);
            contacts.Add(new Contact(name, phone));
            MessageBox.Show("修改成功！");


        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (NameListBox.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择您要修改的联系人");
            }
            else
            {
                UpdateContact(NameInfo.Text, PhoneInfo.Text);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (NameListBox.SelectedIndex == -1)
            {
                MessageBox.Show("请先选择您要删除的联系人");
            }
            else
            {
                contacts.RemoveAt(NameListBox.SelectedIndex);
                MessageBox.Show("删除成功！");

            }
        }

        private void SelectSearchKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = SelectSearchKey.SelectedIndex;
            if (index == -1)
            {
            }
            if (index == 0)
            {
                SearchLabel.Text = "姓名";
            }
            if (index == 1)
            {
                SearchLabel.Text = "电话";
            }
        }

        private void NameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NameListBox.SelectedItem != null && PhoneListBox.SelectedItem != null)
            {
                Contact contact = (Contact)NameListBox.SelectedItem;
                NameInfo.Text = contact.Name;
                PhoneInfo.Text = contact.Phone;
            }
        }

        private void 重新载入数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            LoadFromFile(path);
        }

        //读取本地文件的联系人
        public  void LoadFromFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    MessageBox.Show("您未存储过联系人，欢迎使用本系统存储联系人！");
                }

                string json = File.ReadAllText(path);
                BindingList<Contact>? newContacts = JsonSerializer.Deserialize<BindingList<Contact>>(json);
                contacts.Clear();
                foreach (Contact contact in newContacts) {
                    contacts.Add(contact);
                }
                MessageBox.Show("数据已成功从文件读取。"+ contacts.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"读取数据时出错: {ex.Message}");
            }
        }
    }
}
