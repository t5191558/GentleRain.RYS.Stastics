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
    public partial class ProjectForm : Form
    {
        private readonly MonthContext context = new MonthContext();
        private int updateId = -1;
        public ProjectForm()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            dgvProject.DataSource = context.Projects.ToList();
        }

        private void dgvProject_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            context.SaveChanges();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
            InitData();
        }

        private void dgvProject_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Name"].Value = "";
            e.Row.Cells["Cardinal"].Value = 0;
            e.Row.Cells["Performance"].Value = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                return;
            }
            if (Exists(txtName.Text))
            {
                MessageBox.Show("该项目已经存在");
                return;
            }
            ProjectEntity project = new ProjectEntity();
            project.Name = txtName.Text;
            project.Cardinal = decimal.Parse(txtCardinal.Text);
            project.Performance = decimal.Parse(txtPerformance.Text);
            context.Projects.Add(project);
            context.SaveChanges();
            InitData();
        }

        private bool ValidData()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("项目名称不能为空");
                return false;
            }

            decimal temp;
            if (!decimal.TryParse(txtCardinal.Text, out temp))
            {
                MessageBox.Show("项目业绩必须为数字");
                return false;
            }

            if (!decimal.TryParse(txtPerformance.Text, out temp))
            {
                MessageBox.Show("项目提成必须为数字");
                return false;
            }
            return true;


        }

        private bool Exists(string name)
        {
            return context.Projects.Any(a => a.Name == name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                return;
            }
            var entity = context.Projects.Find(updateId);
            if(entity == null)
            {
                MessageBox.Show("该项目不存在");
                updateId = -1;
                return;
            }
            entity.Name = txtName.Text;
            entity.Cardinal = decimal.Parse(txtCardinal.Text);
            entity.Performance = decimal.Parse(txtPerformance.Text);
            context.SaveChanges();
            updateId = -1;
            InitData();
        }

        private void dgvProject_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            updateId = e.RowIndex >= 0 ? int.Parse(dgvProject.Rows[e.RowIndex].Cells["Id"].Value.ToString() ?? "0") : 0;
            txtName.Text = e.RowIndex >= 0 ? dgvProject.Rows[e.RowIndex].Cells["Name"].Value.ToString() : "";
            txtCardinal.Text = e.RowIndex >= 0 ? dgvProject.Rows[e.RowIndex].Cells["Cardinal"].Value.ToString() : "0";
            txtPerformance.Text = e.RowIndex >= 0 ? dgvProject.Rows[e.RowIndex].Cells["Performance"].Value.ToString() : "0";
        }
    }
}
