
namespace contact_telephone_directory
{
    partial class AddContactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            AddNameText = new TextBox();
            AddPhoneText = new TextBox();
            AddAffirmButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 16F);
            label1.Location = new Point(105, 49);
            label1.Name = "label1";
            label1.Size = new Size(135, 62);
            label1.TabIndex = 0;
            label1.Text = "姓名:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 16F);
            label2.Location = new Point(105, 152);
            label2.Name = "label2";
            label2.Size = new Size(135, 62);
            label2.TabIndex = 1;
            label2.Text = "电话:";
            label2.Click += label2_Click;
            // 
            // AddNameText
            // 
            AddNameText.Font = new Font("Microsoft YaHei UI", 14F);
            AddNameText.Location = new Point(272, 52);
            AddNameText.Name = "AddNameText";
            AddNameText.Size = new Size(304, 61);
            AddNameText.TabIndex = 2;
            // 
            // AddPhoneText
            // 
            AddPhoneText.Font = new Font("Microsoft YaHei UI", 14F);
            AddPhoneText.Location = new Point(272, 152);
            AddPhoneText.Name = "AddPhoneText";
            AddPhoneText.Size = new Size(304, 61);
            AddPhoneText.TabIndex = 3;
            // 
            // AddAffirmButton
            // 
            AddAffirmButton.DialogResult = DialogResult.OK;
            AddAffirmButton.Location = new Point(272, 302);
            AddAffirmButton.Name = "AddAffirmButton";
            AddAffirmButton.Size = new Size(224, 83);
            AddAffirmButton.TabIndex = 4;
            AddAffirmButton.Text = "确认";
            AddAffirmButton.UseVisualStyleBackColor = true;
            AddAffirmButton.Click += button1_Click;
            // 
            // AddContactForm
            // 
            AutoScaleDimensions = new SizeF(16F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddAffirmButton);
            Controls.Add(AddPhoneText);
            Controls.Add(AddNameText);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddContactForm";
            Text = "AddContactForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox AddNameText;
        private TextBox AddPhoneText;
        private Button AddAffirmButton;
    }
}