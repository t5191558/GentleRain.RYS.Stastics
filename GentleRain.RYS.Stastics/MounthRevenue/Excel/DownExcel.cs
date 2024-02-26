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
        //推拿统计
        public static void DownMassageExcel(DateTime start, DateTime end, string filepath)
        {
            MonthContext context = new MonthContext();
            var datas = context.RevenueDay.Where(w => w.RevenueDate >= start && w.RevenueDate <= end);
            var projects = context.Projects.ToList();
            var employees = context.Employees.ToList();
            var rule = context.Bonus.ToList();
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
                    var worksheet = workbook.Worksheets.Add(employee.Name);
                    //第一行条件标题
                    worksheet.Range(1, 1, 2, 1).Merge();
                    worksheet.Cell(1, 1).Value = "日期";
                    int column = 2;
                    foreach (var project in projects)
                    {
                        if(string.IsNullOrWhiteSpace(project.Category))
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
                    
                    if (dics.ContainsKey(employee.Name))
                    {
                        int row = 3;
                        foreach (var data in dics[employee.Name])
                        {
                            worksheet.Cell(row, 1).Value = data.Key;
                            for (int i = 2; i < projects.Count + 2; i++)
                            {
                                var columCategory = GetColumnCategory(worksheet, i);
                                var columName = GetColumnName(worksheet, i);
                                worksheet.Cell(row, i).Value = data.Value.Where(w => w.ProjectName.Equals(columName,StringComparison.OrdinalIgnoreCase) &&  (w.ProjectCategory ?? "").Equals(columCategory,StringComparison.OrdinalIgnoreCase)).Sum(s => s.Count);
                            }
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
                            var columName = worksheet.Cell(1, i).GetString();
                            worksheet.Cell(row, i).Value = dics[employee.Name].Values.Sum(s => s.Where(w => w.ProjectName.Equals(columName, StringComparison.OrdinalIgnoreCase) && (w.ProjectCategory ?? "").Equals(columCategory, StringComparison.OrdinalIgnoreCase)).Sum(s => s.Count * s.UnitCardinal));
                        }
                        row++;
                        worksheet.Cell(row, 1).Value = "提成";
                        for (int i = 2; i < projects.Count + 2; i++)
                        {
                            var columCategory = GetColumnCategory(worksheet, i);
                            var columName = worksheet.Cell(1, i).GetString();
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
                        worksheet.Cell(row, 6).Value = "合计";
                        decimal totalPerformance = cardinalperformance + vipPerformance;
                        worksheet.Cell(row, 7).Value = "提成比率";
                        decimal ratePerformance = rule.Where(w => w.Low <= totalCardinal && w.High > totalCardinal).First().Rate;
                        row++;
                        worksheet.Cell(row, 1).Value = totalCardinal;
                        worksheet.Cell(row, 2).Value = vipCardinal;
                        worksheet.Cell(row, 3).Value = actualCardinal;
                        worksheet.Cell(row, 4).Value = cardinalperformance;
                        worksheet.Cell(row, 5).Value = vipPerformance;
                        worksheet.Cell(row, 6).Value = totalPerformance;
                        worksheet.Cell(row, 7).Value = ratePerformance;

                        MergeColumnHead(worksheet, column);
                        AdjustToContents(worksheet, column);
                        Center(worksheet, column);
                    }
                }

                // 保存工作簿
                workbook.SaveAs(filepath);
            }
        }

        //推拿提成 
        public static void DownRevenueExcel(DateTime start, DateTime end, string filepath)
        {
            MonthContext context = new MonthContext();
            var datas = context.RevenueDay.Where(w => w.RevenueDate >= start && w.RevenueDate <= end);
            var projects = context.Projects.ToList();
            var employees = context.Employees.ToList();
            var rule = context.Bonus.ToList();
            Dictionary<string, Dictionary<string, decimal>> dics = new Dictionary<string, Dictionary<string, decimal>>();
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

        private static void MergeColumnHead(IXLWorksheet worksheet,int column)
        {
            string sameHeadName = "";
            int sameCount = 0;
            for (int cIndex = 2; cIndex < column; cIndex++)
            {
                var headName = worksheet.Cell(1, cIndex).GetString();
                if (headName.Equals(sameHeadName, StringComparison.OrdinalIgnoreCase))
                {
                    sameCount++;
                }
                else
                {
                    if(sameCount > 0)
                    {
                        worksheet.Range(1,cIndex - 1 - sameCount,1,cIndex - 1).Merge();
                        worksheet.Cell(1, cIndex - 1 - sameCount).Value = sameHeadName;
                    }
                    sameHeadName = headName;
                    sameCount = 0;
                }
            }
        }

        private static void AdjustToContents(IXLWorksheet worksheet,int column)
        {
            //worksheet.Columns().AdjustToContents();
        }

        private static void Center(IXLWorksheet worksheet,int column)
        {
            for (int cIndex = 1; cIndex < column; cIndex++)
            {
                var cell = worksheet.Cell(1,cIndex);
                // 设置单元格的对齐方式为居中
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            }
        }
    }
}
