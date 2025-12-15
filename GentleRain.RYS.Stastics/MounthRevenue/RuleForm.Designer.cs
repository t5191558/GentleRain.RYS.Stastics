namespace MonthRevenue
{
    partial class RuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuleForm));
            dgvRule = new DataGridView();
            dgvBonusMain = new DataGridView();
            label1 = new Label();
            txtLow = new TextBox();
            label2 = new Label();
            txtHigh = new TextBox();
            label3 = new Label();
            txtRate = new TextBox();
            txtAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            label4 = new Label();
            txtMainName = new TextBox();
            label5 = new Label();
            txtMainDesc = new TextBox();
            label6 = new Label();
            txtBasicPay = new TextBox();
            chkMainActive = new CheckBox();
            chkMainDefault = new CheckBox();
            btnMainAdd = new Button();
            btnMainUpdate = new Button();
            btnMainDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBonusMain).BeginInit();
            SuspendLayout();
            // 
            // dgvRule
            // 
            dgvRule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRule.Location = new Point(28, 330);
            dgvRule.Name = "dgvRule";
            dgvRule.RowHeadersWidth = 51;
            dgvRule.Size = new Size(950, 350);
            dgvRule.TabIndex = 11;
            dgvRule.CellDoubleClick += dgvRule_CellDoubleClick;
            // 
            // dgvBonusMain
            // 
            dgvBonusMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBonusMain.Location = new Point(28, 75);
            dgvBonusMain.Name = "dgvBonusMain";
            dgvBonusMain.RowHeadersWidth = 51;
            dgvBonusMain.Size = new Size(950, 155);
            dgvBonusMain.TabIndex = 10;
            dgvBonusMain.CellDoubleClick += dgvBonusMain_CellDoubleClick;
            dgvBonusMain.SelectionChanged += dgvBonusMain_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 250);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 1;
            label1.Text = "金额开始(包含)";
            // 
            // txtLow
            // 
            txtLow.Location = new Point(155, 247);
            txtLow.Name = "txtLow";
            txtLow.Size = new Size(125, 27);
            txtLow.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(305, 250);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 3;
            label2.Text = "金额结束(不包含)";
            // 
            // txtHigh
            // 
            txtHigh.Location = new Point(458, 247);
            txtHigh.Name = "txtHigh";
            txtHigh.Size = new Size(125, 27);
            txtHigh.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(610, 250);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 5;
            label3.Text = "提成比率(小于1)";
            // 
            // txtRate
            // 
            txtRate.Location = new Point(745, 247);
            txtRate.Name = "txtRate";
            txtRate.Size = new Size(125, 27);
            txtRate.TabIndex = 6;
            // 
            // txtAdd
            // 
            txtAdd.Location = new Point(28, 290);
            txtAdd.Name = "txtAdd";
            txtAdd.Size = new Size(94, 29);
            txtAdd.TabIndex = 7;
            txtAdd.Text = "新增";
            txtAdd.UseVisualStyleBackColor = true;
            txtAdd.Click += txtAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(140, 290);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "修改";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(252, 290);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 15);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 12;
            label4.Text = "方案名称";
            // 
            // txtMainName
            // 
            txtMainName.Location = new Point(120, 12);
            txtMainName.Name = "txtMainName";
            txtMainName.Size = new Size(150, 27);
            txtMainName.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(290, 15);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 14;
            label5.Text = "方案说明";
            // 
            // txtMainDesc
            // 
            txtMainDesc.Location = new Point(380, 12);
            txtMainDesc.Name = "txtMainDesc";
            txtMainDesc.Size = new Size(180, 27);
            txtMainDesc.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 48);
            label6.Name = "label6";
            label6.Size = new Size(39, 20);
            label6.TabIndex = 21;
            label6.Text = "底薪";
            // 
            // txtBasicPay
            // 
            txtBasicPay.Location = new Point(120, 45);
            txtBasicPay.Name = "txtBasicPay";
            txtBasicPay.Size = new Size(150, 27);
            txtBasicPay.TabIndex = 22;
            // 
            // chkMainActive
            // 
            chkMainActive.AutoSize = true;
            chkMainActive.Checked = true;
            chkMainActive.CheckState = CheckState.Checked;
            chkMainActive.Location = new Point(585, 14);
            chkMainActive.Name = "chkMainActive";
            chkMainActive.Size = new Size(61, 24);
            chkMainActive.TabIndex = 16;
            chkMainActive.Text = "启用";
            chkMainActive.UseVisualStyleBackColor = true;
            chkMainActive.CheckedChanged += chkMainActive_CheckedChanged;
            // 
            // chkMainDefault
            // 
            chkMainDefault.AutoSize = true;
            chkMainDefault.Location = new Point(655, 14);
            chkMainDefault.Name = "chkMainDefault";
            chkMainDefault.Size = new Size(61, 24);
            chkMainDefault.TabIndex = 17;
            chkMainDefault.Text = "默认";
            chkMainDefault.UseVisualStyleBackColor = true;
            chkMainDefault.CheckedChanged += chkMainDefault_CheckedChanged;
            // 
            // btnMainAdd
            // 
            btnMainAdd.Location = new Point(720, 28);
            btnMainAdd.Name = "btnMainAdd";
            btnMainAdd.Size = new Size(80, 29);
            btnMainAdd.TabIndex = 18;
            btnMainAdd.Text = "新增方案";
            btnMainAdd.UseVisualStyleBackColor = true;
            btnMainAdd.Click += btnMainAdd_Click;
            // 
            // btnMainUpdate
            // 
            btnMainUpdate.Location = new Point(805, 28);
            btnMainUpdate.Name = "btnMainUpdate";
            btnMainUpdate.Size = new Size(80, 29);
            btnMainUpdate.TabIndex = 19;
            btnMainUpdate.Text = "修改方案";
            btnMainUpdate.UseVisualStyleBackColor = true;
            btnMainUpdate.Click += btnMainUpdate_Click;
            // 
            // btnMainDelete
            // 
            btnMainDelete.Location = new Point(890, 28);
            btnMainDelete.Name = "btnMainDelete";
            btnMainDelete.Size = new Size(80, 29);
            btnMainDelete.TabIndex = 20;
            btnMainDelete.Text = "删除方案";
            btnMainDelete.UseVisualStyleBackColor = true;
            btnMainDelete.Click += btnMainDelete_Click;
            // 
            // RuleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 720);
            Controls.Add(txtBasicPay);
            Controls.Add(label6);
            Controls.Add(btnMainDelete);
            Controls.Add(btnMainUpdate);
            Controls.Add(btnMainAdd);
            Controls.Add(chkMainDefault);
            Controls.Add(chkMainActive);
            Controls.Add(txtMainDesc);
            Controls.Add(label5);
            Controls.Add(txtMainName);
            Controls.Add(label4);
            Controls.Add(dgvBonusMain);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(txtAdd);
            Controls.Add(txtRate);
            Controls.Add(label3);
            Controls.Add(txtHigh);
            Controls.Add(label2);
            Controls.Add(txtLow);
            Controls.Add(label1);
            Controls.Add(dgvRule);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RuleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "规则管理";
            ((System.ComponentModel.ISupportInitialize)dgvRule).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBonusMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRule;
        private DataGridView dgvBonusMain;
        private Label label1;
        private TextBox txtLow;
        private Label label2;
        private TextBox txtHigh;
        private Label label3;
        private TextBox txtRate;
        private Button txtAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label label4;
        private TextBox txtMainName;
        private Label label5;
        private TextBox txtMainDesc;
        private Label label6;
        private TextBox txtBasicPay;
        private CheckBox chkMainActive;
        private CheckBox chkMainDefault;
        private Button btnMainAdd;
        private Button btnMainUpdate;
        private Button btnMainDelete;
    }
}