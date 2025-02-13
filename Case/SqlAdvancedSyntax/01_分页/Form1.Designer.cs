namespace _01_分页
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._02_School_LearnDataSet = new _01_分页._02_School_LearnDataSet();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productsTableAdapter = new _01_分页._02_School_LearnDataSetTableAdapters.ProductsTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._02_School_LearnDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.pname,
            this.price,
            this.flag,
            this.cid});
            this.dataGridView1.Location = new System.Drawing.Point(42, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1152, 645);
            this.dataGridView1.TabIndex = 0;
            // 
            // _02_School_LearnDataSet
            // 
            this._02_School_LearnDataSet.DataSetName = "_02_School_LearnDataSet";
            this._02_School_LearnDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "Products";
            this.productsBindingSource.DataSource = this._02_School_LearnDataSet;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 724);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(389, 130);
            this.button1.TabIndex = 1;
            this.button1.Text = "上一页";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(805, 724);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(389, 130);
            this.button2.TabIndex = 2;
            this.button2.Text = "下一页";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(524, 770);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 33);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(682, 770);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 33);
            this.label2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(589, 770);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = "/";
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
            this.pname.HeaderText = "名称";
            this.pname.MinimumWidth = 10;
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "价格";
            this.price.MinimumWidth = 10;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // flag
            // 
            this.flag.DataPropertyName = "flag";
            this.flag.HeaderText = "是否可用";
            this.flag.MinimumWidth = 10;
            this.flag.Name = "flag";
            this.flag.ReadOnly = true;
            // 
            // cid
            // 
            this.cid.DataPropertyName = "cid";
            this.cid.HeaderText = "类别编号";
            this.cid.MinimumWidth = 10;
            this.cid.Name = "cid";
            this.cid.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 952);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._02_School_LearnDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private _02_School_LearnDataSet _02_School_LearnDataSet;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private _02_School_LearnDataSetTableAdapters.ProductsTableAdapter productsTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn cid;
    }
}

