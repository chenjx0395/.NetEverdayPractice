﻿namespace _15_综合案例
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox1.Location = new System.Drawing.Point(27, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1511, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询信息";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.Location = new System.Drawing.Point(1309, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(981, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(292, 44);
            this.textBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(822, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "电话号码";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(502, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 44);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(417, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(132, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(223, 41);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "分组";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox2.Location = new System.Drawing.Point(27, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1511, 521);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "展示信息";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.pname,
            this.phoneNum,
            this.gid});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1505, 478);
            this.dataGridView1.TabIndex = 0;
            // 
            // pid
            // 
            this.pid.DataPropertyName = "pid";
            this.pid.HeaderText = "编号";
            this.pid.MinimumWidth = 10;
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            // 
            // pname
            // 
            this.pname.DataPropertyName = "pname";
            this.pname.HeaderText = "姓名";
            this.pname.MinimumWidth = 10;
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            // 
            // phoneNum
            // 
            this.phoneNum.DataPropertyName = "phoneNum";
            this.phoneNum.HeaderText = "电话号码";
            this.phoneNum.MinimumWidth = 10;
            this.phoneNum.Name = "phoneNum";
            this.phoneNum.ReadOnly = true;
            // 
            // gid
            // 
            this.gid.DataPropertyName = "gid";
            this.gid.HeaderText = "分组";
            this.gid.MinimumWidth = 10;
            this.gid.Name = "gid";
            this.gid.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.textBox7);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBox6);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox3.Location = new System.Drawing.Point(27, 704);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1511, 275);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "                                                             ";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.PaleVioletRed;
            this.button4.Location = new System.Drawing.Point(1374, 212);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 63);
            this.button4.TabIndex = 15;
            this.button4.Text = "删除";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Cyan;
            this.button3.Location = new System.Drawing.Point(1374, 131);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 63);
            this.button3.TabIndex = 14;
            this.button3.Text = "添加";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.button2.Location = new System.Drawing.Point(1374, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 63);
            this.button2.TabIndex = 7;
            this.button2.Text = "修改";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(1045, 167);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(292, 44);
            this.textBox7.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(896, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 33);
            this.label10.TabIndex = 12;
            this.label10.Text = "电话号码";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(713, 167);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(161, 44);
            this.textBox6.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(615, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 33);
            this.label9.TabIndex = 10;
            this.label9.Text = "姓名";
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(146, 178);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(223, 41);
            this.comboBox3.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 33);
            this.label8.TabIndex = 8;
            this.label8.Text = "分组";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(1045, 84);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(292, 44);
            this.textBox5.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(896, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 33);
            this.label7.TabIndex = 7;
            this.label7.Text = "电话号码";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(713, 79);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(161, 44);
            this.textBox4.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(615, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 33);
            this.label6.TabIndex = 7;
            this.label6.Text = "姓名";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox3.Location = new System.Drawing.Point(512, 79);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(76, 44);
            this.textBox3.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(417, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 33);
            this.label5.TabIndex = 7;
            this.label5.Text = "编号";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(146, 79);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(223, 41);
            this.comboBox2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 33);
            this.label4.TabIndex = 7;
            this.label4.Text = "分组";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1550, 991);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn gid;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
    }
}

