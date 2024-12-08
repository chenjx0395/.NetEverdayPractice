
namespace contact_telephone_directory
{
    partial class Index
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contactBindingSource = new BindingSource(components);
            SearchButton = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            OutButton = new Button();
            SaveButton = new Button();
            contextMenuStrip2 = new ContextMenuStrip(components);
            NameListBox = new ListBox();
            SearchValue = new TextBox();
            menuStrip1 = new MenuStrip();
            功能ToolStripMenuItem = new ToolStripMenuItem();
            AddControlButton = new ToolStripMenuItem();
            重新载入数据ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            帮助ToolStripMenuItem = new ToolStripMenuItem();
            NameInfo = new TextBox();
            PhoneInfo = new TextBox();
            label2 = new Label();
            label3 = new Label();
            UpdateButton = new Button();
            groupBox1 = new GroupBox();
            DeleteButton = new Button();
            SearchLabel = new Label();
            label5 = new Label();
            PhoneListBox = new ListBox();
            SelectSearchKey = new ComboBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)contactBindingSource).BeginInit();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // contactBindingSource
            // 
            contactBindingSource.DataSource = typeof(ContactSystem.Contact);
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(657, 86);
            SearchButton.Margin = new Padding(3, 2, 3, 2);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(170, 68);
            SearchButton.TabIndex = 2;
            SearchButton.Text = "搜索";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += button1_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(36, 36);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // OutButton
            // 
            OutButton.Location = new Point(925, 710);
            OutButton.Margin = new Padding(3, 2, 3, 2);
            OutButton.Name = "OutButton";
            OutButton.Size = new Size(170, 83);
            OutButton.TabIndex = 4;
            OutButton.Text = "退出系统";
            OutButton.UseVisualStyleBackColor = true;
            OutButton.Click += button2_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(647, 710);
            SaveButton.Margin = new Padding(3, 2, 3, 2);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(170, 84);
            SaveButton.TabIndex = 5;
            SaveButton.Text = "保存数据";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += button3_Click;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(36, 36);
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // NameListBox
            // 
            NameListBox.BackColor = SystemColors.Window;
            NameListBox.FormattingEnabled = true;
            NameListBox.Location = new Point(100, 220);
            NameListBox.Name = "NameListBox";
            NameListBox.Size = new Size(164, 599);
            NameListBox.TabIndex = 7;
            NameListBox.SelectedIndexChanged += NameListBox_SelectedIndexChanged;
            // 
            // SearchValue
            // 
            SearchValue.Font = new Font("Microsoft YaHei UI", 16F);
            SearchValue.Location = new Point(343, 85);
            SearchValue.Margin = new Padding(3, 2, 3, 2);
            SearchValue.Name = "SearchValue";
            SearchValue.Size = new Size(279, 68);
            SearchValue.TabIndex = 8;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(36, 36);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 功能ToolStripMenuItem, toolStripMenuItem1, 帮助ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1194, 43);
            menuStrip1.TabIndex = 10;
            menuStrip1.Text = "menuStrip1";
            // 
            // 功能ToolStripMenuItem
            // 
            功能ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddControlButton, 重新载入数据ToolStripMenuItem });
            功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            功能ToolStripMenuItem.Size = new Size(129, 39);
            功能ToolStripMenuItem.Text = "功能(G)";
            // 
            // AddControlButton
            // 
            AddControlButton.Name = "AddControlButton";
            AddControlButton.Size = new Size(325, 48);
            AddControlButton.Text = "添加联系人";
            AddControlButton.Click += AddControlButton_Click;
            // 
            // 重新载入数据ToolStripMenuItem
            // 
            重新载入数据ToolStripMenuItem.Name = "重新载入数据ToolStripMenuItem";
            重新载入数据ToolStripMenuItem.Size = new Size(325, 48);
            重新载入数据ToolStripMenuItem.Text = "重新载入数据";
            重新载入数据ToolStripMenuItem.Click += 重新载入数据ToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(22, 39);
            // 
            // 帮助ToolStripMenuItem
            // 
            帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            帮助ToolStripMenuItem.Size = new Size(126, 39);
            帮助ToolStripMenuItem.Text = "帮助(B)";
            // 
            // NameInfo
            // 
            NameInfo.Location = new Point(144, 93);
            NameInfo.Name = "NameInfo";
            NameInfo.Size = new Size(225, 42);
            NameInfo.TabIndex = 1;
            // 
            // PhoneInfo
            // 
            PhoneInfo.Location = new Point(144, 165);
            PhoneInfo.Name = "PhoneInfo";
            PhoneInfo.Size = new Size(225, 42);
            PhoneInfo.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 100);
            label2.Name = "label2";
            label2.Size = new Size(69, 35);
            label2.TabIndex = 3;
            label2.Text = "姓名";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 165);
            label3.Name = "label3";
            label3.Size = new Size(69, 35);
            label3.TabIndex = 4;
            label3.Text = "电话";
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(30, 257);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(199, 65);
            UpdateButton.TabIndex = 5;
            UpdateButton.Text = "修改联系人";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DeleteButton);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(NameInfo);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(PhoneInfo);
            groupBox1.Controls.Add(UpdateButton);
            groupBox1.Location = new Point(647, 233);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(448, 358);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "修改/删除联系人";
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(243, 257);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(199, 65);
            DeleteButton.TabIndex = 6;
            DeleteButton.Text = "删除联系人";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // SearchLabel
            // 
            SearchLabel.AutoSize = true;
            SearchLabel.Location = new Point(268, 102);
            SearchLabel.Name = "SearchLabel";
            SearchLabel.Size = new Size(69, 35);
            SearchLabel.TabIndex = 6;
            SearchLabel.Text = "姓名";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Green;
            label5.Font = new Font("Microsoft YaHei UI", 20F, FontStyle.Italic);
            label5.ForeColor = SystemColors.Info;
            label5.Location = new Point(880, 86);
            label5.Name = "label5";
            label5.Size = new Size(273, 78);
            label5.TabIndex = 12;
            label5.Text = "欢迎使用";
            // 
            // PhoneListBox
            // 
            PhoneListBox.FormattingEnabled = true;
            PhoneListBox.Location = new Point(259, 220);
            PhoneListBox.Name = "PhoneListBox";
            PhoneListBox.Size = new Size(339, 599);
            PhoneListBox.TabIndex = 13;
            // 
            // SelectSearchKey
            // 
            SelectSearchKey.DropDownStyle = ComboBoxStyle.DropDownList;
            SelectSearchKey.Font = new Font("Microsoft YaHei UI", 10F);
            SelectSearchKey.FormattingEnabled = true;
            SelectSearchKey.Location = new Point(100, 97);
            SelectSearchKey.Name = "SelectSearchKey";
            SelectSearchKey.Size = new Size(152, 47);
            SelectSearchKey.TabIndex = 14;
            SelectSearchKey.SelectedIndexChanged += SelectSearchKey_SelectedIndexChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Index
            // 
            AutoScaleDimensions = new SizeF(16F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Moccasin;
            ClientSize = new Size(1194, 1032);
            Controls.Add(SelectSearchKey);
            Controls.Add(PhoneListBox);
            Controls.Add(label5);
            Controls.Add(SearchLabel);
            Controls.Add(groupBox1);
            Controls.Add(SearchValue);
            Controls.Add(NameListBox);
            Controls.Add(menuStrip1);
            Controls.Add(SaveButton);
            Controls.Add(OutButton);
            Controls.Add(SearchButton);
            Font = new Font("Microsoft YaHei UI", 9F);
            ForeColor = SystemColors.ControlText;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Index";
            Text = "联系人电话簿";
            ((System.ComponentModel.ISupportInitialize)contactBindingSource).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button SearchButton;
        private ContextMenuStrip contextMenuStrip1;
        private Button OutButton;
        private Button SaveButton;
        private ContextMenuStrip contextMenuStrip2;
        private BindingSource contactBindingSource;
        private ListBox NameListBox;
        private TextBox SearchValue;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 功能ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private TextBox NameInfo;
        private TextBox PhoneInfo;
        private Label label2;
        private Label label3;
        private Button UpdateButton;
        private GroupBox groupBox1;
        private ToolStripMenuItem AddControlButton;
        private ToolStripMenuItem 帮助ToolStripMenuItem;
        private ToolStripMenuItem 重新载入数据ToolStripMenuItem;
        private Label SearchLabel;
        private Label label5;
        private ListBox PhoneListBox;
        private Button DeleteButton;
        private ComboBox SelectSearchKey;
        private FolderBrowserDialog folderBrowserDialog1;
        private OpenFileDialog openFileDialog1;
    }
}
