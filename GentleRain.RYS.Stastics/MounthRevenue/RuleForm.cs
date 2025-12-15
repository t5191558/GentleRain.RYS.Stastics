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
        private BindingList<BonusEntity> ruleBindingList = new();
        private int selectedMainId = -1;
        private bool isBindingMainForm;

        public RuleForm()
        {
            InitializeComponent();
            InitializeDataGridViewStyle();
            InitData();
        }
        
        private void InitializeDataGridViewStyle()
        {
            // 设置 BonusMain 表格 - 可编辑
            dgvBonusMain.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBonusMain.MultiSelect = false;
            dgvBonusMain.AllowUserToAddRows = true;
            dgvBonusMain.AllowUserToDeleteRows = true;
            dgvBonusMain.ReadOnly = false;
            dgvBonusMain.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvBonusMain.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvBonusMain.RowHeadersVisible = true;
            dgvBonusMain.AutoGenerateColumns = false;
            dgvBonusMain.EditMode = DataGridViewEditMode.EditOnEnter;
            
            // 配置 BonusMain 列
            ConfigureBonusMainColumns();
            
            // 设置 Rule 表格 - 可编辑
            dgvRule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRule.MultiSelect = false;
            dgvRule.AllowUserToAddRows = true;
            dgvRule.AllowUserToDeleteRows = true;
            dgvRule.ReadOnly = false;
            dgvRule.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvRule.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvRule.RowHeadersVisible = true;
            dgvRule.AutoGenerateColumns = false;
            dgvRule.EditMode = DataGridViewEditMode.EditOnEnter;
            
            // 配置 Rule 列
            ConfigureRuleColumns();
            
            // 添加右键菜单
            AddContextMenus();
            
            // 绑定事件
            dgvBonusMain.UserDeletingRow += dgvBonusMain_UserDeletingRow;
            dgvBonusMain.CellValueChanged += dgvBonusMain_CellValueChanged;
            dgvBonusMain.RowValidating += dgvBonusMain_RowValidating;
            dgvBonusMain.KeyDown += dgvBonusMain_KeyDown;
            
            dgvRule.UserDeletingRow += dgvRule_UserDeletingRow;
            dgvRule.CellValueChanged += dgvRule_CellValueChanged;
            dgvRule.RowValidating += dgvRule_RowValidating;
            dgvRule.KeyDown += dgvRule_KeyDown;
        }

        private void AddContextMenus()
        {
            // 为 BonusMain 表格添加右键菜单
            var mainContextMenu = new ContextMenuStrip();
            var mainDeleteItem = new ToolStripMenuItem("删除方案 (Delete)", null, (s, e) => DeleteSelectedMainRow());
            mainDeleteItem.ShortcutKeys = Keys.Delete;
            mainContextMenu.Items.Add(mainDeleteItem);
            dgvBonusMain.ContextMenuStrip = mainContextMenu;
            
            // 为 Rule 表格添加右键菜单
            var ruleContextMenu = new ContextMenuStrip();
            var ruleDeleteItem = new ToolStripMenuItem("删除规则 (Delete)", null, (s, e) => DeleteSelectedRuleRow());
            ruleDeleteItem.ShortcutKeys = Keys.Delete;
            ruleContextMenu.Items.Add(ruleDeleteItem);
            dgvRule.ContextMenuStrip = ruleContextMenu;
        }

        private void dgvBonusMain_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && !dgvBonusMain.IsCurrentCellInEditMode)
            {
                DeleteSelectedMainRow();
                e.Handled = true;
            }
        }

        private void dgvRule_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && !dgvRule.IsCurrentCellInEditMode)
            {
                DeleteSelectedRuleRow();
                e.Handled = true;
            }
        }

        private void DeleteSelectedMainRow()
        {
            if (dgvBonusMain.CurrentRow == null || dgvBonusMain.CurrentRow.IsNewRow)
            {
                return;
            }

            if (dgvBonusMain.CurrentRow.DataBoundItem is not BonusMainEntity entity || entity.Id <= 0)
            {
                return;
            }

            var confirm = MessageBox.Show(
                $"确定要删除方案 '{entity.Name}' 吗？\n\n删除该方案会同时删除所有关联的提成规则！",
                "删除确认",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.OK)
            {
                return;
            }

            try
            {
                var rules = context.Bonus.Where(b => b.BonusMainId == entity.Id).ToList();
                if (rules.Any())
                {
                    context.Bonus.RemoveRange(rules);
                }
                context.BonusMain.Remove(entity);
                context.SaveChanges();
                
                mainBindingList.Remove(entity);
                EnsureDefaultScheme();
                
                MessageBox.Show("方案删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteSelectedRuleRow()
        {
            if (dgvRule.CurrentRow == null || dgvRule.CurrentRow.IsNewRow)
            {
                return;
            }

            if (dgvRule.CurrentRow.DataBoundItem is not BonusEntity entity || entity.Id <= 0)
            {
                return;
            }

            var confirm = MessageBox.Show(
                $"确定要删除该提成规则吗？\n\n金额范围：{entity.Low:N2} - {entity.High:N2}\n提成比率：{entity.Rate:P2}",
                "删除确认",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirm != DialogResult.OK)
            {
                return;
            }

            try
            {
                context.Bonus.Remove(entity);
                context.SaveChanges();
                
                ruleBindingList.Remove(entity);
                
                MessageBox.Show("规则删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ConfigureBonusMainColumns()
        {
            dgvBonusMain.Columns.Clear();
            
            // ID 列 - 隐藏
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false,
                ReadOnly = true
            };
            dgvBonusMain.Columns.Add(colId);
            
            // 方案名称
            var colName = new DataGridViewTextBoxColumn
            {
                Name = "Name",
                DataPropertyName = "Name",
                HeaderText = "方案名称",
                Width = 150,
                ReadOnly = false
            };
            dgvBonusMain.Columns.Add(colName);
            
            // 方案说明
            var colDesc = new DataGridViewTextBoxColumn
            {
                Name = "Desc",
                DataPropertyName = "Desc",
                HeaderText = "方案说明",
                Width = 200,
                ReadOnly = false
            };
            dgvBonusMain.Columns.Add(colDesc);
            
            // 底薪
            var colBasicPay = new DataGridViewTextBoxColumn
            {
                Name = "BasicPay",
                DataPropertyName = "BasicPay",
                HeaderText = "底薪",
                Width = 100,
                ReadOnly = false,
                DefaultCellStyle = { Format = "N2" }
            };
            dgvBonusMain.Columns.Add(colBasicPay);
            
            // 启用
            var colIsActive = new DataGridViewCheckBoxColumn
            {
                Name = "IsActive",
                DataPropertyName = "IsActive",
                HeaderText = "启用",
                Width = 60,
                ReadOnly = false
            };
            dgvBonusMain.Columns.Add(colIsActive);
            
            // 默认
            var colIsDefault = new DataGridViewCheckBoxColumn
            {
                Name = "IsDefault",
                DataPropertyName = "IsDefault",
                HeaderText = "默认",
                Width = 60,
                ReadOnly = false
            };
            dgvBonusMain.Columns.Add(colIsDefault);
        }

        private void ConfigureRuleColumns()
        {
            dgvRule.Columns.Clear();
            
            // ID 列 - 隐藏
            var colId = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Visible = false,
                ReadOnly = true
            };
            dgvRule.Columns.Add(colId);
            
            // BonusMainId - 隐藏
            var colMainId = new DataGridViewTextBoxColumn
            {
                Name = "BonusMainId",
                DataPropertyName = "BonusMainId",
                HeaderText = "BonusMainId",
                Visible = false,
                ReadOnly = true
            };
            dgvRule.Columns.Add(colMainId);
            
            // 金额开始
            var colLow = new DataGridViewTextBoxColumn
            {
                Name = "Low",
                DataPropertyName = "Low",
                HeaderText = "金额开始(包含)",
                Width = 150,
                ReadOnly = false,
                DefaultCellStyle = { Format = "N2" }
            };
            dgvRule.Columns.Add(colLow);
            
            // 金额结束
            var colHigh = new DataGridViewTextBoxColumn
            {
                Name = "High",
                DataPropertyName = "High",
                HeaderText = "金额结束(不包含)",
                Width = 150,
                ReadOnly = false,
                DefaultCellStyle = { Format = "N2" }
            };
            dgvRule.Columns.Add(colHigh);
            
            // 提成比率
            var colRate = new DataGridViewTextBoxColumn
            {
                Name = "Rate",
                DataPropertyName = "Rate",
                HeaderText = "提成比率(小于1)",
                Width = 150,
                ReadOnly = false,
                DefaultCellStyle = { Format = "N4" }
            };
            dgvRule.Columns.Add(colRate);
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
            
            if (mainBindingList.Any())
            {
                if (mainIdToSelect.HasValue)
                {
                    var target = mainBindingList.FirstOrDefault(m => m.Id == mainIdToSelect.Value);
                    if (target != null)
                    {
                        selectedMainId = target.Id;
                        HighlightMainRow(target.Id);
                    }
                }
                else if (selectedMainId <= 0)
                {
                    selectedMainId = mainBindingList.First().Id;
                    HighlightMainRow(selectedMainId);
                }
                LoadBonusRules();
            }
            else
            {
                selectedMainId = -1;
                LoadBonusRules();
            }
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
                    if (dgvBonusMain.Columns.Count > 0)
                    {
                        dgvBonusMain.CurrentCell = row.Cells[1]; // 选中第一个可见列
                    }
                    break;
                }
            }
        }

        private void LoadBonusRules()
        {
            if (selectedMainId <= 0)
            {
                ruleBindingList = new BindingList<BonusEntity>();
                dgvRule.DataSource = ruleBindingList;
                return;
            }

            var rules = context.Bonus.Where(b => b.BonusMainId == selectedMainId).OrderBy(b => (double)b.Low).ToList();
            ruleBindingList = new BindingList<BonusEntity>(rules);
            dgvRule.DataSource = ruleBindingList;
        }

        private void dgvBonusMain_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBonusMain.CurrentRow?.DataBoundItem is BonusMainEntity entity)
            {
                if (entity.Id != selectedMainId)
                {
                    selectedMainId = entity.Id;
                    LoadBonusRules();
                }
            }
        }

        private void dgvBonusMain_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.DataBoundItem is not BonusMainEntity entity || entity.Id <= 0)
            {
                return;
            }

            var confirm = MessageBox.Show($"确定要删除方案'{entity.Name}'吗？\n删除该方案会同时删除所有关联的提成规则！", 
                "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
            if (confirm != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                var rules = context.Bonus.Where(b => b.BonusMainId == entity.Id).ToList();
                if (rules.Any())
                {
                    context.Bonus.RemoveRange(rules);
                }
                context.BonusMain.Remove(entity);
                context.SaveChanges();
                EnsureDefaultScheme();
                MessageBox.Show("方案删除成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show($"删除失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBonusMain_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || isBindingMainForm)
            {
                return;
            }

            try
            {
                var row = dgvBonusMain.Rows[e.RowIndex];
                if (row.DataBoundItem is not BonusMainEntity entity)
                {
                    return;
                }

                // 处理 IsDefault 互斥逻辑
                if (e.ColumnIndex == dgvBonusMain.Columns["IsDefault"].Index && entity.IsDefault)
                {
                    if (!entity.IsActive)
                    {
                        MessageBox.Show("只有启用的方案才能设为默认", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        entity.IsDefault = false;
                        dgvBonusMain.RefreshEdit();
                        return;
                    }

                    // 取消其他方案的默认状态
                    foreach (var item in mainBindingList.Where(m => m.Id != entity.Id && m.IsDefault))
                    {
                        item.IsDefault = false;
                    }
                    dgvBonusMain.Refresh();
                }

                // 处理 IsActive 和 IsDefault 关联
                if (e.ColumnIndex == dgvBonusMain.Columns["IsActive"].Index && !entity.IsActive)
                {
                    if (entity.IsDefault)
                    {
                        entity.IsDefault = false;
                    }
                }

                if (entity.Id > 0)
                {
                    // 更新现有记录
                    context.SaveChanges();
                    EnsureDefaultScheme();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBonusMain_RowValidating(object? sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvBonusMain.Rows[e.RowIndex];
            if (row.IsNewRow)
            {
                return;
            }

            if (row.DataBoundItem is not BonusMainEntity entity)
            {
                return;
            }

            // 验证新增的行
            if (entity.Id <= 0)
            {
                if (string.IsNullOrWhiteSpace(entity.Name))
                {
                    MessageBox.Show("请输入方案名称", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                if (entity.BasicPay.HasValue && entity.BasicPay.Value < 0)
                {
                    MessageBox.Show("底薪不能为负数", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                try
                {
                    if (entity.IsDefault && !entity.IsActive)
                    {
                        MessageBox.Show("只有启用的方案才能设为默认", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        entity.IsDefault = false;
                    }

                    if (entity.IsDefault)
                    {
                        var otherDefaults = context.BonusMain.Where(m => m.IsDefault).ToList();
                        foreach (var other in otherDefaults)
                        {
                            other.IsDefault = false;
                        }
                    }

                    context.BonusMain.Add(entity);
                    context.SaveChanges();
                    
                    if (!entity.IsDefault)
                    {
                        EnsureDefaultScheme();
                    }

                    LoadMainList(entity.Id);
                    MessageBox.Show("方案新增成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                    MessageBox.Show($"保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvRule_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.DataBoundItem is not BonusEntity entity || entity.Id <= 0)
            {
                return;
            }

            var confirm = MessageBox.Show("确定要删除该提成规则吗？", "删除确认", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
            if (confirm != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }

            try
            {
                context.Bonus.Remove(entity);
                context.SaveChanges();
                MessageBox.Show("规则删除成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show($"删除失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRule_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            try
            {
                var row = dgvRule.Rows[e.RowIndex];
                if (row.DataBoundItem is not BonusEntity entity)
                {
                    return;
                }

                if (entity.Id > 0)
                {
                    // 更新现有记录
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRule_RowValidating(object? sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgvRule.Rows[e.RowIndex];
            if (row.IsNewRow)
            {
                return;
            }

            if (row.DataBoundItem is not BonusEntity entity)
            {
                return;
            }

            // 验证新增的行
            if (entity.Id <= 0)
            {
                if (selectedMainId <= 0)
                {
                    MessageBox.Show("请先选择提成方案", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                if (entity.High <= entity.Low)
                {
                    MessageBox.Show("金额结束必须大于金额开始", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                if (entity.Rate >= 1 || entity.Rate < 0)
                {
                    MessageBox.Show("比率必须在0到1之间", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                try
                {
                    entity.BonusMainId = selectedMainId;
                    context.Bonus.Add(entity);
                    context.SaveChanges();
                    LoadBonusRules();
                    MessageBox.Show("规则新增成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    e.Cancel = true;
                    MessageBox.Show($"保存失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
