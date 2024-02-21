using MonthRevenue.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonthRevenue
{
    public partial class RevenueForm : Form
    {
        MonthContext context = new MonthContext();
        public RevenueForm()
        {
            InitializeComponent();
            InitDate();
            InitData();
        }

        private void InitDate()
        {
            var date = DateTime.Now;
            date1.Value = new DateTime(date.Year, date.Month, date.Day);
            date2.Value = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }

        private void InitData()
        {
            var datas = context.RevenueDay.Where(w => w.RevenueDate >= date1.Value && w.RevenueDate <= date2.Value).OrderBy(o => o.RevenueDate).OrderBy(o => o.EmployeeId);
            Dictionary<string, List<RevenueDayEntity>> dic = new Dictionary<string, List<RevenueDayEntity>>();
            foreach (var data in datas)
            {
                if (dic.ContainsKey($"{data.RevenueDate:yyyyMMdd}{data.EmployeeName}"))
                {
                    dic[$"{data.RevenueDate:yyyyMMdd}{data.EmployeeName}"].Add(data);
                }
                else
                {
                    dic[$"{data.RevenueDate:yyyyMMdd}{data.EmployeeName}"] = new List<RevenueDayEntity> { data };
                }
            }

            var dt = CreateDT();
            foreach (var data in dic)
            {
                DataRow dr = dt.NewRow();
                dr["日期"] = data.Value[0].RevenueDate;
                dr["姓名"] = data.Value[0].EmployeeName;
                foreach (var d in data.Value)
                {
                    if (dt.Columns.Contains(d.ProjectName))
                    {
                        decimal tempValue = 0;
                        decimal.TryParse(dr[d.ProjectName].ToString() ?? "0", out tempValue);
                        tempValue += d.Count;
                        dr[d.ProjectName] = tempValue;
                    }
                }
                dt.Rows.Add(dr);
            }

            dgvRevenue.DataSource = dt;
        }

        private DataTable CreateDT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("日期");
            dt.Columns.Add("姓名");
            foreach (var project in context.Projects)
            {
                dt.Columns.Add(project.Name);
            }
            return dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitData();
        }

        private void btnFileUpload_Click(object sender, EventArgs e)
        {
            // 创建一个 OpenFileDialog 实例
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 设置文件对话框的标题
            openFileDialog.Title = "请选择Excel文件";

            // 设置文件过滤器来限定文件类型，例如 Excel 文件
            openFileDialog.Filter = "Excel文件 (*.xlsx)|*.xlsx|所有文件 (*.*)|*.*";

            // 设置对话框的初始目录（可选）
            openFileDialog.InitialDirectory = @"C:\";

            // 允许对话框选择多个文件（可选）
            openFileDialog.Multiselect = false;

            // 如果用户点击了对话框的“打开”按钮
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取选定的文件名
                string fileName = openFileDialog.FileName;
                var datas = UploadExcel.Upload(fileName);
                context.RevenueDay.AddRange(datas);
                context.SaveChanges();
                InitData();
            }
        }

        private void btnMassage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx"; // 只显示 Excel 文件
                saveFileDialog.Title = "导出excel文件";
                saveFileDialog.CheckPathExists = true; // 检查路径是否存在
                saveFileDialog.DefaultExt = "xlsx"; // 默认扩展名
                saveFileDialog.AddExtension = true; // 自动添加扩展名
                saveFileDialog.FileName =$"{date1.Value:yyyyMMdd}-{date2.Value:yyyyMMdd}推拿统计"; 
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // 默认目录

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 用户选择了有效的文件路径并点击了"保存"
                    string filePath = saveFileDialog.FileName;

                    // 保存工作簿到用户指定的路径
                    DownExcel.DownMassageExcel(date1.Value, date2.Value, filePath);
                    MessageBox.Show($"excel导出到 {filePath}", "导出成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
