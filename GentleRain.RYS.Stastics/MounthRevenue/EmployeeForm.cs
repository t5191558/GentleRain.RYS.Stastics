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
    public partial class EmployeeForm : Form
    {
        private readonly MonthContext context = new MonthContext();
        private int updateId = -1;
        public EmployeeForm()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            dgvEmployee.DataSource = context.Employees.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                return;
            }
            if (Exists(txtName.Text))
            {
                MessageBox.Show("该员工已经存在");
                return;
            }
            EmployeeEntity employee = new EmployeeEntity();
            employee.Name = txtName.Text;
            employee.SocialAmount = decimal.Parse(txtSocial.Text);
            employee.HousFund = decimal.Parse(txtFound.Text);
            context.Employees.Add(employee);
            context.SaveChanges();
            InitData();
        }

        private bool ValidData()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("姓名不能为空");
                return false;
            }

            decimal temp;
            if (!decimal.TryParse(txtSocial.Text, out temp))
            {
                MessageBox.Show("社保必须为数字");
                return false;
            }

            if (!decimal.TryParse(txtFound.Text, out temp))
            {
                MessageBox.Show("公积金必须为数字");
                return false;
            }
            return true;


        }

        private bool Exists(string name)
        {
            return context.Employees.Any(a => a.Name == name);
        }

        private void dgvEmployee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            updateId = e.RowIndex >= 0 ? int.Parse(dgvEmployee.Rows[e.RowIndex].Cells["Id"].Value.ToString() ?? "0") : 0;
            txtName.Text = e.RowIndex >= 0 ? dgvEmployee.Rows[e.RowIndex].Cells["Name"].Value.ToString() : "";
            txtSocial.Text = e.RowIndex >= 0 ? dgvEmployee.Rows[e.RowIndex].Cells["SocialAmount"].Value.ToString() : "0";
            txtFound.Text = e.RowIndex >= 0 ? dgvEmployee.Rows[e.RowIndex].Cells["HousFund"].Value.ToString() : "0";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                return;
            }
            var entity = context.Employees.Find(updateId);
            if (entity == null)
            {
                MessageBox.Show("该员工不存在");
                updateId = -1;
                return;
            }
            entity.Name = txtName.Text;
            entity.SocialAmount = decimal.Parse(txtSocial.Text);
            entity.HousFund = decimal.Parse(txtFound.Text);
            context.SaveChanges();
            updateId = -1;
            InitData();
        }

        private void dgvEmployee_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            context.SaveChanges();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                return;
            }
            var entity = context.Employees.Find(updateId);
            if (entity == null)
            {
                MessageBox.Show("该员工不存在");
                updateId = -1;
                return;
            }
            context.Employees.Remove(entity);
            context.SaveChanges();
            updateId = -1;
            InitData();
        }
    }
}
