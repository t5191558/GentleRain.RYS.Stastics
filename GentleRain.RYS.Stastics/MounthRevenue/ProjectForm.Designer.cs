namespace MonthRevenue
{
    partial class ProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            dgvProject = new DataGridView();
            btnAdd = new Button();
            txtName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPerformance = new TextBox();
            label3 = new Label();
            txtCardinal = new TextBox();
            button1 = new Button();
            label4 = new Label();
            txtCategory = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProject).BeginInit();
            SuspendLayout();
            // 
            // dgvProject
            // 
            dgvProject.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProject.Location = new Point(37, 77);
            dgvProject.Name = "dgvProject";
            dgvProject.RowHeadersWidth = 51;
            dgvProject.Size = new Size(1277, 596);
            dgvProject.TabIndex = 0;
            dgvProject.CellDoubleClick += dgvProject_CellDoubleClick;
            dgvProject.CellEndEdit += dgvProject_CellEndEdit;
            dgvProject.DefaultValuesNeeded += dgvProject_DefaultValuesNeeded;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(953, 36);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(106, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "新增";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(316, 36);
            txtName.Name = "txtName";
            txtName.Size = new Size(140, 27);
            txtName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(255, 36);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 4;
            label1.Text = "名称";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(723, 36);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 5;
            label2.Text = "提成";
            // 
            // txtPerformance
            // 
            txtPerformance.Location = new Point(786, 36);
            txtPerformance.Name = "txtPerformance";
            txtPerformance.Size = new Size(140, 27);
            txtPerformance.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(482, 36);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 7;
            label3.Text = "业绩";
            // 
            // txtCardinal
            // 
            txtCardinal.Location = new Point(548, 36);
            txtCardinal.Name = "txtCardinal";
            txtCardinal.Size = new Size(140, 27);
            txtCardinal.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(1078, 36);
            button1.Name = "button1";
            button1.Size = new Size(106, 29);
            button1.TabIndex = 9;
            button1.Text = "修改";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 36);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 10;
            label4.Text = "分类";
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(89, 36);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(140, 27);
            txtCategory.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(43, 8);
            label5.Name = "label5";
            label5.Size = new Size(568, 20);
            label5.TabIndex = 12;
            label5.Text = "项目的唯一性为分类+名称，分类可以为空，导出excel的时候相同分类的数据会挨着";
            // 
            // ProjectForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1383, 704);
            Controls.Add(label5);
            Controls.Add(txtCategory);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(txtCardinal);
            Controls.Add(label3);
            Controls.Add(txtPerformance);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(btnAdd);
            Controls.Add(dgvProject);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ProjectForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "项目管理";
            ((System.ComponentModel.ISupportInitialize)dgvProject).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProject;
        private Button btnAdd;
        private TextBox txtName;
        private Label label1;
        private Label label2;
        private TextBox txtPerformance;
        private Label label3;
        private TextBox txtCardinal;
        private Button button1;
        private Label label4;
        private TextBox txtCategory;
        private Label label5;
    }
}