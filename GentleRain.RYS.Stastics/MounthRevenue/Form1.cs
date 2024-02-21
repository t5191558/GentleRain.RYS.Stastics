using MonthRevenue;

namespace MounthRevenue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
