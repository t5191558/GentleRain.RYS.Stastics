using Microsoft.EntityFrameworkCore;
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
            LoadBonusMainList();
            
            var employees = context.Employees
                .Include(e => e.BonusMain)
                .Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.SocialAmount,
                    e.HousFund,
                    e.BonusMainId,
                    提成方案 = e.BonusMain != null ? e.BonusMain.Name : ""
                })
                .ToList();
            
            dgvEmployee.DataSource = employees;
            
            if (dgvEmployee.Columns["Id"] != null)
            {
                dgvEmployee.Columns["Id"].Visible = false;
            }
            if (dgvEmployee.Columns["BonusMainId"] != null)
            {
                dgvEmployee.Columns["BonusMainId"].Visible = false;
            }
        }

        private void LoadBonusMainList()
        {
            var bonusMains = context.BonusMain
                .Where(m => m.IsActive)
                .OrderBy(m => m.Name)
                .ToList();
            
            cmbBonusMain.Items.Clear();
            cmbBonusMain.Items.Add(new ComboBoxItem { Text = "(无)", Value = null });
            
            foreach (var bonusMain in bonusMains)
            {
                cmbBonusMain.Items.Add(new ComboBoxItem 
                { 
                    Text = bonusMain.Name, 
                    Value = bonusMain.Id 
                });
            }
            
            cmbBonusMain.DisplayMember = "Text";
            cmbBonusMain.ValueMember = "Value";
            cmbBonusMain.SelectedIndex = 0;
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
            employee.BonusMainId = (cmbBonusMain.SelectedItem as ComboBoxItem)?.Value;
            
            context.Employees.Add(employee);
            context.SaveChanges();
            InitData();
            ClearForm();
        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            txtSocial.Text = string.Empty;
            txtFound.Text = string.Empty;
            cmbBonusMain.SelectedIndex = 0;
            updateId = -1;
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
            if (e.RowIndex < 0)
            {
                return;
            }
            
            var row = dgvEmployee.Rows[e.RowIndex];
            updateId = int.Parse(row.Cells["Id"].Value?.ToString() ?? "0");
            txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
            txtSocial.Text = row.Cells["SocialAmount"].Value?.ToString() ?? "0";
            txtFound.Text = row.Cells["HousFund"].Value?.ToString() ?? "0";
            
            var bonusMainId = row.Cells["BonusMainId"].Value;
            if (bonusMainId == null || bonusMainId == DBNull.Value)
            {
                cmbBonusMain.SelectedIndex = 0;
            }
            else
            {
                int bonusId = Convert.ToInt32(bonusMainId);
                for (int i = 0; i < cmbBonusMain.Items.Count; i++)
                {
                    var item = cmbBonusMain.Items[i] as ComboBoxItem;
                    if (item?.Value == bonusId)
                    {
                        cmbBonusMain.SelectedIndex = i;
                        break;
                    }
                }
            }
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
            entity.BonusMainId = (cmbBonusMain.SelectedItem as ComboBoxItem)?.Value;
            
            context.SaveChanges();
            InitData();
            ClearForm();
        }

        private void dgvEmployee_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            context.SaveChanges();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (updateId <= 0)
            {
                MessageBox.Show("请选择要删除的员工");
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
            InitData();
            ClearForm();
        }
        
        private class ComboBoxItem
        {
            public string Text { get; set; } = string.Empty;
            public int? Value { get; set; }
        }
    }
}
