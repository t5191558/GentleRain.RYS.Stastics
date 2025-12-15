namespace MounthRevenue
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnProject = new Button();
            btnEmployee = new Button();
            btnBonusRule = new Button();
            btnRevenue = new Button();
            lblVersion = new Label();
            SuspendLayout();
            // 
            // btnProject
            // 
            btnProject.Location = new Point(70, 67);
            btnProject.Name = "btnProject";
            btnProject.Size = new Size(191, 74);
            btnProject.TabIndex = 0;
            btnProject.Text = "项目管理";
            btnProject.UseVisualStyleBackColor = true;
            btnProject.Click += btnProject_Click;
            // 
            // btnEmployee
            // 
            btnEmployee.Location = new Point(411, 67);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Size = new Size(191, 74);
            btnEmployee.TabIndex = 1;
            btnEmployee.Text = "员工管理";
            btnEmployee.UseVisualStyleBackColor = true;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // btnBonusRule
            // 
            btnBonusRule.Location = new Point(70, 225);
            btnBonusRule.Name = "btnBonusRule";
            btnBonusRule.Size = new Size(191, 74);
            btnBonusRule.TabIndex = 2;
            btnBonusRule.Text = "提成规则管理";
            btnBonusRule.UseVisualStyleBackColor = true;
            btnBonusRule.Click += btnBonusRule_Click;
            // 
            // btnRevenue
            // 
            btnRevenue.Location = new Point(411, 225);
            btnRevenue.Name = "btnRevenue";
            btnRevenue.Size = new Size(191, 74);
            btnRevenue.TabIndex = 3;
            btnRevenue.Text = "提成管理";
            btnRevenue.UseVisualStyleBackColor = true;
            btnRevenue.Click += btnRevenue_Click;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.ForeColor = SystemColors.ControlDarkDark;
            lblVersion.Location = new Point(12, 417);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(69, 20);
            lblVersion.TabIndex = 4;
            lblVersion.Text = "版本: 1.0.0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblVersion);
            Controls.Add(btnRevenue);
            Controls.Add(btnBonusRule);
            Controls.Add(btnEmployee);
            Controls.Add(btnProject);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "统计系统";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnProject;
        private Button btnEmployee;
        private Button btnBonusRule;
        private Button btnRevenue;
        private Label lblVersion;
    }
}
