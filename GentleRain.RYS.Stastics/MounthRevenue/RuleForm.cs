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
        private BindingList<BonusMainEntity> mainBindingList = new();
        private int selectedBonusId = -1;
        private int selectedMainId = -1;
        private bool isBindingMainForm;

        public RuleForm()
        {
            InitializeComponent();
            InitData();
        }
        private void InitData()
        {
            LoadMainList();
        }

        private void LoadMainList(int? mainIdToSelect = null)
        {
            EnsureDefaultScheme();
            var mainList = context.BonusMain.OrderByDescending(m => m.IsActive).ThenBy(m => m.Name).ToList();
            mainBindingList = new BindingList<BonusMainEntity>(mainList);
            mainBindingList.ListChanged += MainBindingList_ListChanged;
            dgvBonusMain.DataSource = mainBindingList;
            if (!mainBindingList.Any())
            {
                selectedMainId = -1;
                ResetMainForm();
                LoadBonusRules();
                return;
            }

            var target = mainIdToSelect.HasValue ? mainBindingList.FirstOrDefault(m => m.Id == mainIdToSelect.Value) : mainBindingList.First();
            target ??= mainBindingList.First();
            BindMainForm(target);
            HighlightMainRow(target.Id);
        }

        private void MainBindingList_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                dgvBonusMain.Refresh();
            }
        }

        private void HighlightMainRow(int id)
        {
            foreach (DataGridViewRow row in dgvBonusMain.Rows)
            {
                if (row.DataBoundItem is BonusMainEntity entity && entity.Id == id)
                {
                    row.Selected = true;
                    dgvBonusMain.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private void BindMainForm(BonusMainEntity entity)
        {
            isBindingMainForm = true;
            selectedMainId = entity.Id;
            txtMainName.Text = entity.Name;
            txtMainDesc.Text = entity.Desc ?? string.Empty;
            txtBasicPay.Text = (entity.BasicPay ?? 0).ToString("F2");
            chkMainActive.Checked = entity.IsActive;
            chkMainDefault.Checked = entity.IsActive && entity.IsDefault;
            chkMainDefault.Enabled = entity.IsActive;
            isBindingMainForm = false;
            LoadBonusRules();
        }

        private void ResetMainForm()
        {
            isBindingMainForm = true;
            txtMainName.Text = string.Empty;
            txtMainDesc.Text = string.Empty;
            txtBasicPay.Text = "0.00";
            chkMainActive.Checked = true;
            chkMainDefault.Checked = false;
            chkMainDefault.Enabled = true;
            isBindingMainForm = false;
        }

        private void LoadBonusRules()
        {
            if (selectedMainId <= 0)
            {
                dgvRule.DataSource = null;
                selectedBonusId = -1;
                ResetBonusForm();
                return;
            }

            var rules = context.Bonus.Where(b => b.BonusMainId == selectedMainId).OrderBy(b => (double)b.Low).ToList();
            dgvRule.DataSource = rules;
            selectedBonusId = -1;
            ResetBonusForm();
        }

        private void ResetBonusForm()
        {
            txtLow.Text = string.Empty;
            txtHigh.Text = string.Empty;
            txtRate.Text = string.Empty;
        }

        private bool ValidData(out decimal low, out decimal high, out decimal rate)
        {
            low = high = rate = 0;
            if (!decimal.TryParse(txtLow.Text, out low))
            {
                MessageBox.Show("金额开始必须为数字");
                return false;
            }

            if (!decimal.TryParse(txtHigh.Text, out high))
            {
                MessageBox.Show("金额结束必须为数字");
                return false;
            }

            if (high <= low)
            {
                MessageBox.Show("金额结束必须大于金额开始");
                return false;
            }

            if (!decimal.TryParse(txtRate.Text, out rate))
            {
                MessageBox.Show("比率必须为数字");
                return false;
            }
            if (rate >= 1)
            {
                MessageBox.Show("比率必须小于1");
                return false;
            }

            if (selectedMainId <= 0)
            {
                MessageBox.Show("请选择提成方案");
                return false;
            }

            return true;
        }

        private bool ValidMainData()
        {
            if (string.IsNullOrWhiteSpace(txtMainName.Text))
            {
                MessageBox.Show("请输入方案名称");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtBasicPay.Text))
            {
                if (!decimal.TryParse(txtBasicPay.Text, out decimal basicPay))
                {
                    MessageBox.Show("底薪必须为数字");
                    return false;
                }

                if (basicPay < 0)
                {
                    MessageBox.Show("底薪不能为负数");
                    return false;
                }
            }

            return true;
        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            if (!ValidData(out var low, out var high, out var rate))
            {
                return;
            }
            BonusEntity entity = new BonusEntity();
            entity.Low = low;
            entity.High = high;
            entity.Rate = rate;
            entity.BonusMainId = selectedMainId;
            context.Bonus.Add(entity);
            context.SaveChanges();
            LoadBonusRules();
        }

        private void dgvRule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvRule.Rows[e.RowIndex].DataBoundItem is not BonusEntity entity)
            {
                return;
            }

            selectedBonusId = entity.Id;
            txtLow.Text = entity.Low.ToString();
            txtHigh.Text = entity.High.ToString();
            txtRate.Text = entity.Rate.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedBonusId <= 0)
            {
                MessageBox.Show("请选择要修改的规则");
                return;
            }

            if (!ValidData(out var low, out var high, out var rate))
            {
                return;
            }

            var entity = context.Bonus.FirstOrDefault(b => b.Id == selectedBonusId && b.BonusMainId == selectedMainId);
            if (entity == null)
            {
                MessageBox.Show("该记录不存在");
                selectedBonusId = -1;
                return;
            }
            entity.Low = low;
            entity.High = high;
            entity.Rate = rate;
            context.SaveChanges();
            selectedBonusId = -1;
            LoadBonusRules();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBonusId <= 0)
            {
                MessageBox.Show("请选择要删除的规则");
                return;
            }

            var entity = context.Bonus.FirstOrDefault(b => b.Id == selectedBonusId && b.BonusMainId == selectedMainId);
            if (entity == null)
            {
                MessageBox.Show("该记录不存在");
                selectedBonusId = -1;
                return;
            }
            context.Bonus.Remove(entity);
            context.SaveChanges();
            selectedBonusId = -1;
            LoadBonusRules();
        }

        private void btnMainAdd_Click(object sender, EventArgs e)
        {
            if (!ValidMainData())
            {
                return;
            }

            var isActive = chkMainActive.Checked;
            var requestDefault = chkMainDefault.Checked && isActive;
            var desc = txtMainDesc.Text.Trim();
            
            decimal? basicPay = null;
            if (!string.IsNullOrWhiteSpace(txtBasicPay.Text) && decimal.TryParse(txtBasicPay.Text, out decimal parsedBasicPay))
            {
                basicPay = parsedBasicPay;
            }
            
            if (requestDefault)
            {
                var otherMains = context.BonusMain.Where(m => m.IsDefault).ToList();
                foreach (var other in otherMains)
                {
                    other.IsDefault = false;
                }
            }

            var entity = new BonusMainEntity
            {
                Name = txtMainName.Text.Trim(),
                Desc = string.IsNullOrEmpty(desc) ? null : desc,
                BasicPay = basicPay,
                IsActive = isActive,
                IsDefault = requestDefault
            };
            context.BonusMain.Add(entity);
            context.SaveChanges();
            
            if (!requestDefault)
            {
                EnsureDefaultScheme();
            }
            
            LoadMainList(entity.Id);
        }

        private void btnMainUpdate_Click(object sender, EventArgs e)
        {
            if (selectedMainId <= 0)
            {
                MessageBox.Show("请选择要修改的方案");
                return;
            }

            if (!ValidMainData())
            {
                return;
            }

            var entity = context.BonusMain.Find(selectedMainId);
            if (entity == null)
            {
                MessageBox.Show("该记录不存在");
                selectedMainId = -1;
                return;
            }

            var hasRules = context.Bonus.Any(b => b.BonusMainId == selectedMainId);
            if (!hasRules)
            {
                MessageBox.Show("该方案没有任何提成规则，无法保存");
                return;
            }

            var isActive = chkMainActive.Checked;
            var requestDefault = chkMainDefault.Checked && isActive;
            var desc = txtMainDesc.Text.Trim();
            
            decimal? basicPay = null;
            if (!string.IsNullOrWhiteSpace(txtBasicPay.Text) && decimal.TryParse(txtBasicPay.Text, out decimal parsedBasicPay))
            {
                basicPay = parsedBasicPay;
            }

            if (requestDefault)
            {
                var otherMains = context.BonusMain.Where(m => m.Id != selectedMainId && m.IsDefault).ToList();
                foreach (var other in otherMains)
                {
                    other.IsDefault = false;
                }
            }

            entity.Name = txtMainName.Text.Trim();
            entity.Desc = string.IsNullOrEmpty(desc) ? null : desc;
            entity.BasicPay = basicPay;
            entity.IsActive = isActive;
            entity.IsDefault = requestDefault;
            context.SaveChanges();
            
            if (!requestDefault)
            {
                EnsureDefaultScheme();
            }
            
            LoadMainList(entity.Id);
        }

        private void btnMainDelete_Click(object sender, EventArgs e)
        {
            if (selectedMainId <= 0)
            {
                MessageBox.Show("请选择要删除的方案");
                return;
            }

            var confirm = MessageBox.Show("删除该方案会同时删除所有规则，是否继续？", "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirm != DialogResult.OK)
            {
                return;
            }

            var entity = context.BonusMain.Find(selectedMainId);
            if (entity == null)
            {
                MessageBox.Show("该记录不存在");
                selectedMainId = -1;
                return;
            }

            var rules = context.Bonus.Where(b => b.BonusMainId == entity.Id).ToList();
            if (rules.Any())
            {
                context.Bonus.RemoveRange(rules);
            }
            context.BonusMain.Remove(entity);
            context.SaveChanges();
            EnsureDefaultScheme();
            LoadMainList();
        }

        private void dgvBonusMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dgvBonusMain.Rows[e.RowIndex].DataBoundItem is BonusMainEntity entity)
            {
                BindMainForm(entity);
                HighlightMainRow(entity.Id);
            }
        }

        private void dgvBonusMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBonusMain.CurrentRow?.DataBoundItem is not BonusMainEntity entity)
            {
                return;
            }

            if (entity.Id == selectedMainId)
            {
                return;
            }

            BindMainForm(entity);
        }

        private void chkMainActive_CheckedChanged(object sender, EventArgs e)
        {
            if (isBindingMainForm)
            {
                return;
            }

            if (!chkMainActive.Checked)
            {
                chkMainDefault.Checked = false;
                chkMainDefault.Enabled = false;
            }
            else
            {
                chkMainDefault.Enabled = true;
            }
        }

        private void chkMainDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (isBindingMainForm)
            {
                return;
            }

            if (!chkMainActive.Checked)
            {
                chkMainDefault.Checked = false;
                return;
            }

            if (chkMainDefault.Checked && selectedMainId > 0)
            {
                UncheckOtherDefaults(selectedMainId);
                
                var currentEntity = mainBindingList.FirstOrDefault(m => m.Id == selectedMainId);
                if (currentEntity != null)
                {
                    currentEntity.IsDefault = true;
                }
            }
            else if (!chkMainDefault.Checked && selectedMainId > 0)
            {
                var currentEntity = mainBindingList.FirstOrDefault(m => m.Id == selectedMainId);
                if (currentEntity != null)
                {
                    currentEntity.IsDefault = false;
                }
            }
        }

        private void HandleDefaultAfterSave(int entityId, bool requestDefault, bool isActive)
        {
            if (!isActive)
            {
                EnsureDefaultScheme();
                return;
            }

            if (requestDefault)
            {
                SetDefaultScheme(entityId);
            }
            else
            {
                EnsureDefaultScheme();
            }
        }

        private void SetDefaultScheme(int defaultId)
        {
            var mains = context.BonusMain.ToList();
            var changed = false;
            foreach (var main in mains)
            {
                var shouldBeDefault = main.Id == defaultId && main.IsActive;
                if (main.IsDefault != shouldBeDefault)
                {
                    main.IsDefault = shouldBeDefault;
                    changed = true;
                }
            }

            if (changed)
            {
                context.SaveChanges();
            }
        }

        private void UncheckOtherDefaults(int exceptId)
        {
            if (mainBindingList == null)
            {
                return;
            }

            foreach (var main in mainBindingList)
            {
                if (main.Id != exceptId && main.IsDefault)
                {
                    main.IsDefault = false;
                }
            }

            dgvBonusMain.Refresh();
        }

        private void EnsureDefaultScheme()
        {
            var activeDefaults = context.BonusMain.Where(m => m.IsActive && m.IsDefault).OrderBy(m => m.Id).ToList();
            if (activeDefaults.Count > 1)
            {
                SetDefaultScheme(activeDefaults.First().Id);
                return;
            }

            if (activeDefaults.Count == 1)
            {
                return;
            }

            var firstActive = context.BonusMain.Where(m => m.IsActive).OrderBy(m => m.Id).FirstOrDefault();
            if (firstActive == null)
            {
                var needReset = context.BonusMain.Where(m => m.IsDefault).ToList();
                if (!needReset.Any())
                {
                    return;
                }

                foreach (var item in needReset)
                {
                    item.IsDefault = false;
                }
                context.SaveChanges();
                return;
            }

            SetDefaultScheme(firstActive.Id);
        }
    }
}
