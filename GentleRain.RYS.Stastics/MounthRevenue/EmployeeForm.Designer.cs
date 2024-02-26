namespace MonthRevenue
{
    partial class EmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm));
            dgvEmployee = new DataGridView();
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtSocial = new TextBox();
            label3 = new Label();
            txtFound = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployee
            // 
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Location = new Point(33, 74);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.RowHeadersWidth = 51;
            dgvEmployee.Size = new Size(1177, 458);
            dgvEmployee.TabIndex = 0;
            dgvEmployee.CellDoubleClick += dgvEmployee_CellDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 35);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 1;
            label1.Text = "姓名";
            // 
            // txtName
            // 
            txtName.Location = new Point(101, 28);
            txtName.Name = "txtName";
            txtName.Size = new Size(140, 27);
            txtName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(272, 35);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 3;
            label2.Text = "社保";
            // 
            // txtSocial
            // 
            txtSocial.Location = new Point(342, 28);
            txtSocial.Name = "txtSocial";
            txtSocial.Size = new Size(140, 27);
            txtSocial.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(533, 35);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 5;
            label3.Text = "公积金";
            // 
            // txtFound
            // 
            txtFound.Location = new Point(623, 28);
            txtFound.Name = "txtFound";
            txtFound.Size = new Size(140, 27);
            txtFound.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(832, 28);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(106, 29);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "新增";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(989, 31);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(106, 29);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "修改";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 561);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtFound);
            Controls.Add(label3);
            Controls.Add(txtSocial);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(dgvEmployee);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "员工管理";
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmployee;
        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtSocial;
        private Label label3;
        private TextBox txtFound;
        private Button btnAdd;
        private Button btnUpdate;
    }
}