using MonthRevenue;
using System.Reflection;

namespace MounthRevenue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadVersionInfo();
        }

        private void LoadVersionInfo()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var version = assembly.GetName().Version;
                
                if (version != null)
                {
                    lblVersion.Text = $"版本: {version.Major}.{version.Minor}.{version.Build}";
                }
                else
                {
                    lblVersion.Text = "版本: 未知";
                }
            }
            catch (Exception ex)
            {
                lblVersion.Text = $"版本: 读取失败 ({ex.Message})";
            }
        }

        private void btnProject_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm();
            projectForm.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.Show();
        }

        private void btnBonusRule_Click(object sender, EventArgs e)
        {
            RuleForm ruleForm = new RuleForm();
            ruleForm.Show();
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            RevenueForm revenueForm = new RevenueForm();
            revenueForm.Show();
        }
    }
}
