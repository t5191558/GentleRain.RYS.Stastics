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
            dgvRevenue = new DataGridView();
            label1 = new Label();
            date1 = new DateTimePicker();
            label2 = new Label();
            date2 = new DateTimePicker();
            btnSearch = new Button();
            btnFileUpload = new Button();
            btnMassage = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).BeginInit();
            SuspendLayout();
            // 
            // dgvRevenue
            // 
            dgvRevenue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenue.Location = new Point(12, 92);
            dgvRevenue.Name = "dgvRevenue";
            dgvRevenue.RowHeadersWidth = 51;
            dgvRevenue.Size = new Size(1176, 432);
            dgvRevenue.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 19);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 1;
            label1.Text = "日期";
            // 
            // date1
            // 
            date1.Location = new Point(79, 20);
            date1.Name = "date1";
            date1.Size = new Size(250, 27);
            date1.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(350, 23);
            label2.Name = "label2";
            label2.Size = new Size(27, 20);
            label2.TabIndex = 3;
            label2.Text = "---";
            // 
            // date2
            // 
            date2.Location = new Point(403, 21);
            date2.Name = "date2";
            date2.Size = new Size(250, 27);
            date2.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(16, 57);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "查询";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnFileUpload
            // 
            btnFileUpload.Location = new Point(725, 21);
            btnFileUpload.Name = "btnFileUpload";
            btnFileUpload.Size = new Size(94, 29);
            btnFileUpload.TabIndex = 6;
            btnFileUpload.Text = "导入Excel文件";
            btnFileUpload.UseVisualStyleBackColor = true;
            btnFileUpload.Click += btnFileUpload_Click;
            // 
            // btnMassage
            // 
            btnMassage.Location = new Point(850, 23);
            btnMassage.Name = "btnMassage";
            btnMassage.Size = new Size(94, 29);
            btnMassage.TabIndex = 7;
            btnMassage.Text = "导出推拿统计";
            btnMassage.UseVisualStyleBackColor = true;
            btnMassage.Click += btnMassage_Click;
            // 
            // RevenueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 580);
            Controls.Add(btnMassage);
            Controls.Add(btnFileUpload);
            Controls.Add(btnSearch);
            Controls.Add(date2);
            Controls.Add(label2);
            Controls.Add(date1);
            Controls.Add(label1);
            Controls.Add(dgvRevenue);
            Name = "RevenueForm";
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
    }
}