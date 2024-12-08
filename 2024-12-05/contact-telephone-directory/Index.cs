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
        // �ļ��洢��
        const string FileName = "contacts.json";
        BindingList<Contact> contacts = new BindingList<Contact> { };
        public Index()
        {
            InitializeComponent();
            //����List����
            InitializeListBox();
            //���������ֵ
            SelectSearchKey.Items.AddRange(new string[] { "����", "�绰" });
            SelectSearchKey.SelectedIndex = 0;
            //��ʼ���޸�����Ϣ
            if (contacts.Count != 0)
            {
                NameInfo.Text = contacts[0].Name;
                PhoneInfo.Text = contacts[0].Phone;
            }
        }
        // ListBox��������
        private void InitializeListBox()
        {
            NameListBox.DataSource = contacts;
            PhoneListBox.DataSource = contacts;
            NameListBox.DisplayMember = "Name";
            PhoneListBox.DisplayMember = "Phone";
        }

        //�����ϵ��
        public void AddContact(string name, string phone)
        {
            // �������ͬ����ϵ�����������
            if (IsExist(name))
            {
                MessageBox.Show("���ʧ�ܣ�����ͬ����ϵ��!");
            }
            else
            {
                contacts.Add(new Contact(name, phone));
                MessageBox.Show("��ϵ����ӳɹ���");
            }
        }



        

        //������ϵ�˼����ж�����������
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

        //�ж���ϵ���б����Ƿ���ڴ���������
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

        //�洢��ϵ���������ļ�
        public void SaveToFile(string path)
        {
            try
            {
                string json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, json);
                MessageBox.Show("�����ѳɹ����浽�ļ���");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��������ʱ����: {ex.Message}");
            }
        }

        // ��������
        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string path = folderBrowserDialog1.SelectedPath + "/" + FileName; 
            SaveToFile(path);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        // ������ť�¼�
        private void button1_Click(object sender, EventArgs e)
        {
            int index = -1;

            if (SelectSearchKey.Text == "����")
            {
                index = contacts.IndexOf(contacts.FirstOrDefault(contact => contact.Name == SearchValue.Text));
            }
            else
            {
                index = contacts.IndexOf(contacts.FirstOrDefault(contact => contact.Phone == SearchValue.Text));
            }
            if (index == -1)
            {
                MessageBox.Show("û�������ϵ����Ϣ");
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
            Application.Exit(); // �˳�����Ӧ�ó���
        }

        private void AddControlButton_Click(object sender, EventArgs e)
        {
            // ʵ�����µ� ContactForm
            using (var contactForm = new AddContactForm())
            {
                // ��ʾ ContactForm ���ȴ��û����ȷ����ť
                var result = contactForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    AddContact(contactForm.GetAddNameBoxValue(), contactForm.GetAddPhoneBoxValue());
                }

            }
        }
        //�޸���ϵ��
        public void UpdateContact(string name, string phone)
        {
            //���ң�ɾ������� ʵ���޸�
            if (ExistIndex(name) != -1)
            {
                MessageBox.Show("�޸�ʧ�ܣ�����ͬ����ϵ�ˣ�");
                return;
            }
            if (string.IsNullOrWhiteSpace(NameInfo.Text) || string.IsNullOrWhiteSpace(PhoneInfo.Text))
            {
                MessageBox.Show("�޸�ʧ�ܣ��޸���Ϣ����Ϊ�գ�");
                return;
            }
            contacts.RemoveAt(NameListBox.SelectedIndex);
            contacts.Add(new Contact(name, phone));
            MessageBox.Show("�޸ĳɹ���");


        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (NameListBox.SelectedIndex == -1)
            {
                MessageBox.Show("����ѡ����Ҫ�޸ĵ���ϵ��");
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
                MessageBox.Show("����ѡ����Ҫɾ������ϵ��");
            }
            else
            {
                contacts.RemoveAt(NameListBox.SelectedIndex);
                MessageBox.Show("ɾ���ɹ���");

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
                SearchLabel.Text = "����";
            }
            if (index == 1)
            {
                SearchLabel.Text = "�绰";
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

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;
            LoadFromFile(path);
        }

        //��ȡ�����ļ�����ϵ��
        public  void LoadFromFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    MessageBox.Show("��δ�洢����ϵ�ˣ���ӭʹ�ñ�ϵͳ�洢��ϵ�ˣ�");
                }

                string json = File.ReadAllText(path);
                BindingList<Contact>? newContacts = JsonSerializer.Deserialize<BindingList<Contact>>(json);
                contacts.Clear();
                foreach (Contact contact in newContacts) {
                    contacts.Add(contact);
                }
                MessageBox.Show("�����ѳɹ����ļ���ȡ��"+ contacts.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��ȡ����ʱ����: {ex.Message}");
            }
        }
    }
}
