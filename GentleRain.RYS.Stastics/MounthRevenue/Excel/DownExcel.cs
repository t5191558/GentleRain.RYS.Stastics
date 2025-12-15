using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using MonthRevenue.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthRevenue
{
    public static class DownExcel
    {
        private static (List<BonusEntity> rules, decimal basicPay) GetEmployeeBonusScheme(MonthContext context, EmployeeEntity employee)
        {
            BonusMainEntity? bonusMain = null;
            
            if (employee.BonusMainId.HasValue)
            {
                bonusMain = context.BonusMain.Find(employee.BonusMainId.Value);
            }
            
            if (bonusMain == null)
            {
                bonusMain = context.BonusMain
                    .Where(m => m.IsActive && m.IsDefault)
                    .OrderBy(m => m.Id)
                    .FirstOrDefault();
            }
            
            if (bonusMain == null)
            {
                bonusMain = context.BonusMain
                    .Where(m => m.IsActive)
                    .OrderBy(m => m.Id)
                    .FirstOrDefault();
            }
            
            if (bonusMain == null)
            {
                return (new List<BonusEntity>(), 0m);
            }
            
            var rules = context.Bonus.Where(b => b.BonusMainId == bonusMain.Id).ToList();
            var basicPay = bonusMain.BasicPay ?? 0m;
            
            return (rules, basicPay);
        }

        //推拿统计
        public static void DownMassageExcel(DateTime start, DateTime end, string filepath)
        {
            MonthContext context = new MonthContext();
            var datas = context.RevenueDay.Where(w => w.RevenueDate >= start && w.RevenueDate <= end);
            var projects = context.Projects.ToList();
            var employees = context.Employees.ToList();
            
            Dictionary<string, Dictionary<DateTime, List<RevenueDayEntity>>> dics = new Dictionary<string, Dictionary<DateTime, List<RevenueDayEntity>>>();
            foreach (var data in datas)
            {
                if (dics.ContainsKey(data.EmployeeName))
                {
                    if (dics[data.EmployeeName].ContainsKey(data.RevenueDate))
                    {
                        dics[data.EmployeeName][data.RevenueDate].Add(data);
                    }
                    else
                    {
                        dics[data.EmployeeName][data.RevenueDate] = new List<RevenueDayEntity> { data };
                    }
                }
                else
                {
                    dics[data.EmployeeName] = new Dictionary<DateTime, List<RevenueDayEntity>> { { data.RevenueDate, new List<RevenueDayEntity> { data } } };
                }
            }
            // 创建一个新的 Excel 工作簿
            using (var workbook = new XLWorkbook())
            {
                foreach (var employee in employees)
                {
                    var (rule, basicPay) = GetEmployeeBonusScheme(context, employee);
                    if (!rule.Any())
                    {
                        continue;
                    }
                    
                    var worksheet = workbook.Worksheets.Add(employee.Name);
                    //第一行条件标题
                    worksheet.Range(1, 1, 2, 1).Merge();
                    worksheet.Cell(1, 1).Value = "日期";
                    int column = 2;
                    ExcelHeadColumn(worksheet,ref column, projects);

                    if (dics.ContainsKey(employee.Name))
                    {
                        int row = 3;
                        foreach (var data in dics[employee.Name])
                        {
                            worksheet.Cell(row, 1).Value = data.Key;
                            MatchProjectCount(worksheet, row, 2, projects, data.Value);
                            row++;
                        }
                        //合计
                        worksheet.Cell(row, 1).Value = "小计";
                        for (int i = 2; i < projects.Count + 2; i++)
                        {
                            var columCategory = GetColumnCategory(worksheet, i);
                            var columName = GetColumnName(worksheet, i); 
                            worksheet.Cell(row, i).Value = dics[employee.Name].Values.Sum(s => s.Where(w => w.ProjectName.Equals(columName,StringComparison.OrdinalIgnoreCase) && (w.ProjectCategory ?? "").Equals(columCategory,StringComparison.OrdinalIgnoreCase)).Sum(s => s.Count));
                        }
                        row++;
                        worksheet.Cell(row, 1).Value = "业绩";
                        for (int i = 2; i < projects.Count + 2; i++)
                        {
                            var columCategory = GetColumnCategory(worksheet, i);
                            var columName = GetColumnName(worksheet,i);
                            worksheet.Cell(row, i).Value = dics[employee.Name].Values.Sum(s => s.Where(w => w.ProjectName.Equals(columName, StringComparison.OrdinalIgnoreCase) && (w.ProjectCategory ?? "").Equals(columCategory, StringComparison.OrdinalIgnoreCase)).Sum(s => s.Count * s.UnitCardinal));
                        }
                        row++;
                        worksheet.Cell(row, 1).Value = "提成";
                        for (int i = 2; i < projects.Count + 2; i++)
                        {
                            var columCategory = GetColumnCategory(worksheet, i);
                            var columName = GetColumnName(worksheet, i); 
                            worksheet.Cell(row, i).Value = dics[employee.Name].Values.Sum(s => s.Where(w => w.ProjectName.Equals(columName, StringComparison.OrdinalIgnoreCase) && (w.ProjectCategory ?? "").Equals(columCategory, StringComparison.OrdinalIgnoreCase)).Sum(s => s.Count * s.UnitPerformance));
                        }
                        row++;
                        worksheet.Cell(row, 1).Value = "业绩合计";
                        decimal totalCardinal = dics[employee.Name].Values.Sum(s => s.Sum(RevenueFormula.Cardinal));
                        worksheet.Cell(row, 2).Value = "会员业绩";
                        decimal vipCardinal = dics[employee.Name].Values.Sum(s => s.Sum(RevenueFormula.CardinalWithOutPerformance));
                        worksheet.Cell(row, 3).Value = "核算提成业绩(减掉168)";
                        decimal actualCardinal = vipCardinal - RevenueFormula.CardinalFixSbu();
                        actualCardinal = actualCardinal < 0 ? 0 : actualCardinal;
                        worksheet.Cell(row, 4).Value = "业绩提成";
                        decimal cardinalperformance = actualCardinal * rule.Where(w => w.Low <= totalCardinal && w.High > totalCardinal).First().Rate;
                        worksheet.Cell(row, 5).Value = "团购提成";
                        decimal vipPerformance = dics[employee.Name].Values.Sum(s => s.Sum(RevenueFormula.Performance));
                        worksheet.Cell(row, 6).Value = "底薪";
                        worksheet.Cell(row, 7).Value = "合计";
                        decimal totalPerformance = cardinalperformance + vipPerformance + basicPay;
                        worksheet.Cell(row, 8).Value = "提成比率";
                        decimal ratePerformance = rule.Where(w => w.Low <= totalCardinal && w.High > totalCardinal).First().Rate;
                        row++;
                        worksheet.Cell(row, 1).Value = totalCardinal;
                        worksheet.Cell(row, 2).Value = vipCardinal;
                        worksheet.Cell(row, 3).Value = actualCardinal;
                        worksheet.Cell(row, 4).Value = cardinalperformance;
                        worksheet.Cell(row, 5).Value = vipPerformance;
                        worksheet.Cell(row, 6).Value = basicPay;
                        worksheet.Cell(row, 7).Value = totalPerformance;
                        worksheet.Cell(row, 8).Value = ratePerformance;

                        MergeColumnHead(worksheet, column);
                        Center(worksheet, column);
                    }
                }

                // 保存工作簿
                workbook.SaveAs(filepath);
            }
        }

        public static void DownDayExcel(DateTime start, DateTime end, string filepath)
        {
            MonthContext context = new MonthContext();
            var datas = context.RevenueDay.Where(w => w.RevenueDate >= start && w.RevenueDate <= end);
            var projects = context.Projects.ToList();
            
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(start.ToString("yyyy-MM"));
                //第一行条件标题
                worksheet.Range(1, 1, 3, 1).Merge();
                worksheet.Cell(1, 1).Value = "日期";
                int column = 2;
                foreach (var project in projects)
                {
                    worksheet.Cell(3, column).Value = "数量";
                    worksheet.Cell(3, column + 1).Value = "金额";
                    if (string.IsNullOrWhiteSpace(project.Category))
                    {
                        worksheet.Range(1, column, 2, column + 1).Merge();
                        worksheet.Cell(1, column).Value = project.Name;
                    }
                    else
                    {
                        worksheet.Range(1, column, 1, column + 1).Merge();
                        worksheet.Range(2, column, 2, column + 1).Merge();
                        worksheet.Cell(1, column).Value = project.Category;
                        worksheet.Cell(2, column).Value = project.Name;
                    }
                    column += 2;
                }
                //填充数据
                int row = 4;
                foreach(var data in datas.OrderBy(o=> o.RevenueDate).GroupBy(g=> g.RevenueDate))
                {
                    worksheet.Cell(row, 1).Value = data.Key;
                    for (int i = 2; i < column; i += 2)
                    {
                        var columCategory = GetColumnCategory(worksheet, i);
                        var columName = GetColumnName(worksheet, i);
                        var counts = data.Where(w => w.ProjectName.Equals(columName, StringComparison.OrdinalIgnoreCase) && (w.ProjectCategory ?? "").Equals(columCategory, StringComparison.OrdinalIgnoreCase)).Sum(s=> s.Count);
                        var revenue = data.Where(w => w.ProjectName.Equals(columName, StringComparison.OrdinalIgnoreCase) && (w.ProjectCategory ?? "").Equals(columCategory, StringComparison.OrdinalIgnoreCase)).Sum(s => s.Count * s.UnitCardinal);
                        var vip = data.Where(w => w.ProjectName.Equals(columName, StringComparison.OrdinalIgnoreCase) && (w.ProjectCategory ?? "").Equals(columCategory, StringComparison.OrdinalIgnoreCase)).Sum(s => s.Count * s.UnitPerformance);
                        worksheet.Cell(row,i).Value = counts;
                        worksheet.Cell(row, i + 1).Value = 0;// vip <= 0 ? revenue : vip;
                    }
                    row++;
                }


                MergeColumnHead(worksheet, column,minCell: 1);
                Center(worksheet, column);

                // 保存工作簿
                workbook.SaveAs(filepath);
            }

        }

        public static void DownRevenueExcel(DateTime start, DateTime end, string filepath)
        {
            MonthContext context = new MonthContext();
            var datas = context.RevenueDay.Where(w => w.RevenueDate >= start && w.RevenueDate <= end);
            var projects = context.Projects.ToList();
            var employees = context.Employees.ToList();
            
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(start.ToString("yyyy-MM"));
                //第一行条件标题
                worksheet.Range(1, 1, 2, 1).Merge();
                worksheet.Cell(1, 1).Value = "姓名";
                int column = 2;
                ExcelHeadColumn(worksheet, ref column, projects);
                //固定列头
                int fixcolumn = column;
                worksheet.Range(1, column, 2, column).Merge();
                worksheet.Cell(1, column).Value = "业绩合计（含团购业绩）";
                column++;
                worksheet.Range(1, column, 2, column).Merge();
                worksheet.Cell(1, column).Value = "不含团购业绩";
                column++;
                worksheet.Range(1, column, 2, column).Merge();
                worksheet.Cell(1, column).Value = "业绩扣除168";
                column++;
                worksheet.Range(1, column, 2, column).Merge();
                worksheet.Cell(1, column).Value = "业绩提成";
                column++;
                worksheet.Range(1, column, 2, column).Merge();
                worksheet.Cell(1, column).Value = "会员卡";
                column++;
                worksheet.Range(1, column, 2, column).Merge();
                worksheet.Cell(1, column).Value = "底薪";
                column++;
                worksheet.Range(1, column, 2, column).Merge();
                worksheet.Cell(1, column).Value = "提成合计(含团购提成）";
                column++;
                worksheet.Range(1, column, 2, column).Merge();
                worksheet.Cell(1, column).Value = "社保";
                column++;
                worksheet.Range(1, column, 2, column).Merge();
                worksheet.Cell(1, column).Value = "公积金";
                column++;
                worksheet.Range(1, column, 2, column).Merge();
                worksheet.Cell(1, column).Value = "水电费";
                column++;
                worksheet.Range(1, column, 2, column).Merge();
                worksheet.Cell(1, column).Value = "应发提成";
                column++;
                worksheet.Range(1, column, 2, column).Merge();
                worksheet.Cell(1, column).Value = "签名";
                column++;
                
                

                //MergeColumnHead(worksheet, column,minCell: 1);

                //填充数据
                int row = 3;
                foreach(var employee in employees)
                {
                    var needDatas = datas.Where(w => w.EmployeeId == employee.Id);
                    if (!needDatas.Any())
                        continue;
                    
                    var (rule, basicPay) = GetEmployeeBonusScheme(context, employee);
                    if (!rule.Any())
                    {
                        continue;
                    }
                    
                    worksheet.Range(row, 1, row + 2, 1).Merge();
                    worksheet.Cell(row, 1).Value = employee.Name;
                    MatchProjectCount(worksheet, row, 2, projects, needDatas.ToList());
                    MatchProjectCardinal(worksheet, row + 1, 2, projects, needDatas.ToList());
                    MatchProjectPerforman(worksheet,row + 2,2, projects, needDatas.ToList());
                    //固定列
                    decimal totalCardinal = needDatas.Sum(RevenueFormula.Cardinal);//业绩合计（含团购业绩）
                    decimal vipCardinal = needDatas.Sum(RevenueFormula.CardinalWithOutPerformance);//不含团购业绩
                    decimal actualCardinal = vipCardinal - RevenueFormula.CardinalFixSbu();
                    actualCardinal = actualCardinal < 0 ? 0 : actualCardinal;
                    decimal cardinalperformance = actualCardinal * rule.Where(w => w.Low <= totalCardinal && w.High > totalCardinal).First().Rate;//业绩提成
                    decimal vipPerformance = needDatas.Sum(RevenueFormula.Performance);//团购提成
                    decimal totalPerformance = cardinalperformance + vipPerformance + basicPay;//提成合计(含团购提成+底薪）
                    decimal socialAmount = employee.SocialAmount;//社保
                    decimal housFund = employee.HousFund;//公积金
                    decimal waterElectricity = 0;//水电费  
                    int fcolumn = fixcolumn;
                    for(int i = fixcolumn;i < column;i++)
                    {
                        worksheet.Range(row, i, row + 2, i).Merge();
                    }
                    worksheet.Cell(row, fcolumn++).Value = totalCardinal;
                    worksheet.Cell(row, fcolumn++).Value = vipCardinal;
                    worksheet.Cell(row, fcolumn++).Value = actualCardinal;
                    worksheet.Cell(row, fcolumn++).Value = cardinalperformance;
                    worksheet.Cell(row, fcolumn++).Value = 0;
                    worksheet.Cell(row, fcolumn++).Value = basicPay;
                    worksheet.Cell(row, fcolumn++).Value = totalPerformance;
                    worksheet.Cell(row, fcolumn++).Value = socialAmount;
                    worksheet.Cell(row, fcolumn++).Value = housFund;
                    worksheet.Cell(row, fcolumn++).Value = waterElectricity;
                    worksheet.Cell(row, fcolumn++).Value = totalPerformance - socialAmount - housFund - waterElectricity;
                    row += 4;
                }

                MergeColumnHead(worksheet, column,minCell: 1);
                Center(worksheet, column);
                // 保存工作簿
                workbook.SaveAs(filepath);
            }

        }

        private static void ExcelHeadColumn(IXLWorksheet worksheet,ref int column,List<ProjectEntity> projects)
        {
            foreach (var project in projects)
            {
                if (string.IsNullOrWhiteSpace(project.Category))
                {
                    worksheet.Range(1, column, 2, column).Merge();
                    worksheet.Cell(1, column++).Value = project.Name;
                }
                else
                {
                    worksheet.Cell(1, column).Value = project.Category;
                    worksheet.Cell(2, column++).Value = project.Name;
                }
            }
        }

        private static void MatchProjectCount(IXLWorksheet worksheet,int row,int beginColumn, List<ProjectEntity> projects, List<RevenueDayEntity> datas)
        {
            for (int i = beginColumn; i < projects.Count + 2; i++)
            {
                var columCategory = GetColumnCategory(worksheet, i);
                var columName = GetColumnName(worksheet, i);
                worksheet.Cell(row, i).Value = datas.Where(w => w.ProjectName.Equals(columName, StringComparison.OrdinalIgnoreCase) && (w.ProjectCategory ?? "").Equals(columCategory, StringComparison.OrdinalIgnoreCase)).Sum(s => s.Count);
            }
        }

        private static void MatchProjectCardinal(IXLWorksheet worksheet, int row, int beginColumn, List<ProjectEntity> projects, List<RevenueDayEntity> datas)
        {
            for (int i = beginColumn; i < projects.Count + 2; i++)
            {
                var columCategory = GetColumnCategory(worksheet, i);
                var columName = GetColumnName(worksheet, i);
                worksheet.Cell(row, i).Value = datas.Where(w => w.ProjectName.Equals(columName, StringComparison.OrdinalIgnoreCase) && (w.ProjectCategory ?? "").Equals(columCategory, StringComparison.OrdinalIgnoreCase)).Sum(s => s.Count * s.UnitCardinal);
            }
        }

        private static void MatchProjectPerforman(IXLWorksheet worksheet, int row, int beginColumn, List<ProjectEntity> projects, List<RevenueDayEntity> datas)
        {
            for (int i = beginColumn; i < projects.Count + 2; i++)
            {
                var columCategory = GetColumnCategory(worksheet, i);
                var columName = GetColumnName(worksheet, i);
                worksheet.Cell(row, i).Value = datas.Where(w => w.ProjectName.Equals(columName, StringComparison.OrdinalIgnoreCase) && (w.ProjectCategory ?? "").Equals(columCategory, StringComparison.OrdinalIgnoreCase)).Sum(s => s.Count * s.UnitPerformance);
            }
        }

        private static string GetColumnCategory(IXLWorksheet worksheet,int columnIndex)
        {
            var category = worksheet.Cell(1, columnIndex).GetString();
            var columName = worksheet.Cell(2, columnIndex).GetString();
            if(string.IsNullOrEmpty(columName))
            {
                return "";
            }

            if (category.Equals(columName, StringComparison.OrdinalIgnoreCase))
            {
                return "";
            }

            return category;
        }

        private static string GetColumnName(IXLWorksheet worksheet,int columnIndex )
        {
            var category = worksheet.Cell(1, columnIndex).GetString();
            var columName = worksheet.Cell(2, columnIndex).GetString();
            if (string.IsNullOrWhiteSpace(columName))
            {
                return category;
            }
            return columName;
        }

        private static void MergeColumnHead(IXLWorksheet worksheet,int column,int row = 1,int minCell = 0)
        {
            string sameHeadName = "";
            int sameCount = 0;
            for (int cIndex = 2; cIndex < column; cIndex++)
            {
                var headName = worksheet.Cell(row, cIndex).GetString();
                if (string.IsNullOrWhiteSpace(headName))
                {
                    sameCount++;
                }else if (headName.Equals(sameHeadName, StringComparison.OrdinalIgnoreCase))
                {
                    sameCount++;
                }
                else
                {
                    if(sameCount > minCell)
                    {
                        worksheet.Range(row,cIndex - 1 - sameCount,row,cIndex - 1).Merge();
                        worksheet.Cell(row, cIndex - 1 - sameCount).Value = sameHeadName;
                    }
                    sameHeadName = headName;
                    sameCount = 0;
                }
            }
        }

        private static void Center(IXLWorksheet worksheet,int column,int row = 1)
        {
            for (int cIndex = 1; cIndex < column; cIndex++)
            {
                var cell = worksheet.Cell(row,cIndex);
                // 设置单元格的对齐方式为居中
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            }
        }
    }
}
