namespace MonthRevenue
{
    partial class RevenueForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RevenueForm));
            dgvRevenue = new DataGridView();
            label1 = new Label();
            date1 = new DateTimePicker();
            label2 = new Label();
            date2 = new DateTimePicker();
            btnSearch = new Button();
            btnFileUpload = new Button();
            btnMassage = new Button();
            btnDel = new Button();
            btnDayRevenue = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).BeginInit();
            SuspendLayout();
            // 
            // dgvRevenue
            // 
            dgvRevenue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenue.Location = new Point(14, 92);
            dgvRevenue.Name = "dgvRevenue";
            dgvRevenue.RowHeadersWidth = 51;
            dgvRevenue.Size = new Size(1626, 432);
            dgvRevenue.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 19);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 1;
            label1.Text = "日期";
            // 
            // date1
            // 
            date1.Location = new Point(89, 20);
            date1.Name = "date1";
            date1.Size = new Size(281, 27);
            date1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(394, 23);
            label2.Name = "label2";
            label2.Size = new Size(27, 20);
            label2.TabIndex = 3;
            label2.Text = "---";
            // 
            // date2
            // 
            date2.Location = new Point(453, 21);
            date2.Name = "date2";
            date2.Size = new Size(281, 27);
            date2.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(18, 57);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(106, 29);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "查询";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnFileUpload
            // 
            btnFileUpload.Location = new Point(754, 20);
            btnFileUpload.Name = "btnFileUpload";
            btnFileUpload.Size = new Size(106, 29);
            btnFileUpload.TabIndex = 6;
            btnFileUpload.Text = "导入Excel文件";
            btnFileUpload.UseVisualStyleBackColor = true;
            btnFileUpload.Click += btnFileUpload_Click;
            // 
            // btnMassage
            // 
            btnMassage.Location = new Point(926, 20);
            btnMassage.Name = "btnMassage";
            btnMassage.Size = new Size(159, 29);
            btnMassage.TabIndex = 7;
            btnMassage.Text = "导出人员项目业绩";
            btnMassage.UseVisualStyleBackColor = true;
            btnMassage.Click += btnMassage_Click;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(183, 57);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(94, 29);
            btnDel.TabIndex = 8;
            btnDel.Text = "删除数据";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // btnDayRevenue
            // 
            btnDayRevenue.Location = new Point(1169, 21);
            btnDayRevenue.Name = "btnDayRevenue";
            btnDayRevenue.Size = new Size(168, 29);
            btnDayRevenue.TabIndex = 9;
            btnDayRevenue.Text = "导出日期项目业绩";
            btnDayRevenue.UseVisualStyleBackColor = true;
            btnDayRevenue.Click += btnDayRevenue_Click;
            // 
            // RevenueForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1675, 580);
            Controls.Add(btnDayRevenue);
            Controls.Add(btnDel);
            Controls.Add(btnMassage);
            Controls.Add(btnFileUpload);
            Controls.Add(btnSearch);
            Controls.Add(date2);
            Controls.Add(label2);
            Controls.Add(date1);
            Controls.Add(label1);
            Controls.Add(dgvRevenue);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RevenueForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "业绩管理";
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRevenue;
        private Label label1;
        private DateTimePicker date1;
        private Label label2;
        private DateTimePicker date2;
        private Button btnSearch;
        private Button btnFileUpload;
        private Button btnMassage;
        private Button btnDel;
        private Button btnDayRevenue;
    }
}