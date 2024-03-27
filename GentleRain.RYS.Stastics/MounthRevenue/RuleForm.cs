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
    public partial class RuleForm : Form
    {
        private readonly MonthContext context = new MonthContext();
        private int updateId = -1;
        public RuleForm()
        {
            InitializeComponent();
            InitData();
        }
        private void InitData()
        {
            dgvRule.DataSource = context.Bonus.ToList();
        }

        private bool ValidData()
        {
            decimal temp;
            if (!decimal.TryParse(txtLow.Text, out temp))
            {
                MessageBox.Show("金额开始必须为数字");
                return false;
            }

            if (!decimal.TryParse(txtHigh.Text, out temp))
            {
                MessageBox.Show("金额结束必须为数字");
                return false;
            }

            if (!decimal.TryParse(txtRate.Text, out temp))
            {
                MessageBox.Show("比率必须为数字");
                return false;
            }
            if (temp >= 1)
            {
                MessageBox.Show("比率必须小于1");
                return false;
            }

            return true;
        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                return;
            }
            BonusEntity entity = new BonusEntity();
            entity.Low = decimal.Parse(txtLow.Text);
            entity.High = decimal.Parse(txtHigh.Text);
            entity.Rate = decimal.Parse(txtRate.Text);
            context.Bonus.Add(entity);
            context.SaveChanges();
            InitData();
        }

        private void dgvRule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            updateId = e.RowIndex >= 0 ? int.Parse(dgvRule.Rows[e.RowIndex].Cells["Id"].Value.ToString() ?? "0") : 0;
            txtLow.Text = e.RowIndex >= 0 ? dgvRule.Rows[e.RowIndex].Cells["Low"].Value.ToString() : "";
            txtHigh.Text = e.RowIndex >= 0 ? dgvRule.Rows[e.RowIndex].Cells["High"].Value.ToString() : "0";
            txtRate.Text = e.RowIndex >= 0 ? dgvRule.Rows[e.RowIndex].Cells["Rate"].Value.ToString() : "0";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                return;
            }
            var entity = context.Bonus.Find(updateId);
            if (entity == null)
            {
                MessageBox.Show("该记录不存在");
                updateId = -1;
                return;
            }
            entity.Low = decimal.Parse(txtLow.Text);
            entity.High = decimal.Parse(txtHigh.Text);
            entity.Rate = decimal.Parse(txtRate.Text);
            context.SaveChanges();
            updateId = -1;
            InitData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                return;
            }
            var entity = context.Bonus.Find(updateId);
            if (entity == null)
            {
                MessageBox.Show("该记录不存在");
                updateId = -1;
                return;
            }
            context.Bonus.Remove(entity);
            context.SaveChanges();
            updateId = -1;
            InitData();
        }
    }
}
