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
            lblMainTitle = new Label();
            lblRuleTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRule).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBonusMain).BeginInit();
            SuspendLayout();
            // 
            // dgvRule
            // 
            dgvRule.AllowUserToAddRows = true;
            dgvRule.AllowUserToDeleteRows = true;
            dgvRule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRule.Location = new Point(28, 340);
            dgvRule.Name = "dgvRule";
            dgvRule.RowHeadersWidth = 51;
            dgvRule.Size = new Size(950, 280);
            dgvRule.TabIndex = 3;
            // 
            // dgvBonusMain
            // 
            dgvBonusMain.AllowUserToAddRows = true;
            dgvBonusMain.AllowUserToDeleteRows = true;
            dgvBonusMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBonusMain.Location = new Point(28, 40);
            dgvBonusMain.Name = "dgvBonusMain";
            dgvBonusMain.RowHeadersWidth = 51;
            dgvBonusMain.Size = new Size(950, 250);
            dgvBonusMain.TabIndex = 1;
            dgvBonusMain.SelectionChanged += dgvBonusMain_SelectionChanged;
            // 
            // lblMainTitle
            // 
            lblMainTitle.AutoSize = true;
            lblMainTitle.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            lblMainTitle.Location = new Point(28, 15);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(500, 22);
            lblMainTitle.TabIndex = 0;
            lblMainTitle.Text = "提成方案 (双击编辑 | 右键或Delete键删除)";
            // 
            // lblRuleTitle
            // 
            lblRuleTitle.AutoSize = true;
            lblRuleTitle.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold);
            lblRuleTitle.Location = new Point(28, 310);
            lblRuleTitle.Name = "lblRuleTitle";
            lblRuleTitle.Size = new Size(500, 22);
            lblRuleTitle.TabIndex = 2;
            lblRuleTitle.Text = "提成规则 (双击编辑 | 右键或Delete键删除)";
            // 
            // RuleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 640);
            Controls.Add(lblRuleTitle);
            Controls.Add(lblMainTitle);
            Controls.Add(dgvBonusMain);
            Controls.Add(dgvRule);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RuleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "规则管理 - 表格内直接编辑";
            ((System.ComponentModel.ISupportInitialize)dgvRule).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBonusMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRule;
        private DataGridView dgvBonusMain;
        private Label lblMainTitle;
        private Label lblRuleTitle;
    }
}