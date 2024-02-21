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
            dgvRule = new DataGridView();
            label1 = new Label();
            txtLow = new TextBox();
            label2 = new Label();
            txtHigh = new TextBox();
            label3 = new Label();
            txtRate = new TextBox();
            txtAdd = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRule).BeginInit();
            SuspendLayout();
            // 
            // dgvRule
            // 
            dgvRule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRule.Location = new Point(28, 96);
            dgvRule.Name = "dgvRule";
            dgvRule.RowHeadersWidth = 51;
            dgvRule.Size = new Size(890, 308);
            dgvRule.TabIndex = 0;
            dgvRule.CellDoubleClick += dgvRule_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 15);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 1;
            label1.Text = "金额开始(包含)";
            // 
            // txtLow
            // 
            txtLow.Location = new Point(157, 12);
            txtLow.Name = "txtLow";
            txtLow.Size = new Size(125, 27);
            txtLow.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(305, 15);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 3;
            label2.Text = "金额结束(不包含)";
            // 
            // txtHigh
            // 
            txtHigh.Location = new Point(458, 15);
            txtHigh.Name = "txtHigh";
            txtHigh.Size = new Size(125, 27);
            txtHigh.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(610, 18);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 5;
            label3.Text = "提成比率(小于1)";
            // 
            // txtRate
            // 
            txtRate.Location = new Point(745, 17);
            txtRate.Name = "txtRate";
            txtRate.Size = new Size(125, 27);
            txtRate.TabIndex = 6;
            // 
            // txtAdd
            // 
            txtAdd.Location = new Point(32, 55);
            txtAdd.Name = "txtAdd";
            txtAdd.Size = new Size(94, 29);
            txtAdd.TabIndex = 7;
            txtAdd.Text = "新增";
            txtAdd.UseVisualStyleBackColor = true;
            txtAdd.Click += txtAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(157, 55);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "修改";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // Rule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 450);
            Controls.Add(btnUpdate);
            Controls.Add(txtAdd);
            Controls.Add(txtRate);
            Controls.Add(label3);
            Controls.Add(txtHigh);
            Controls.Add(label2);
            Controls.Add(txtLow);
            Controls.Add(label1);
            Controls.Add(dgvRule);
            Name = "Rule";
            Text = "Rule";
            ((System.ComponentModel.ISupportInitialize)dgvRule).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRule;
        private Label label1;
        private TextBox txtLow;
        private Label label2;
        private TextBox txtHigh;
        private Label label3;
        private TextBox txtRate;
        private Button txtAdd;
        private Button btnUpdate;
    }
}