using ClosedXML.Excel;
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
        public static void DownMassageExcel(DateTime start,DateTime end,string filepath)
        {
            MonthContext context = new MonthContext();
            var datas = context.RevenueDay.Where(w => w.RevenueDate >= start && w.RevenueDate <= end);
            var projects = context.Projects.ToList();
            var employees = context.Employees.ToList();
            var rule = context.Bonus.ToList();
            Dictionary<string, Dictionary<DateTime,List<RevenueDayEntity>>> dics = new Dictionary<string, Dictionary<DateTime,List<RevenueDayEntity>> >();
            foreach(var data in datas)
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
                foreach(var employee in employees)
                {
                    var worksheet = workbook.Worksheets.Add(employee.Name);
                    //第一行条件标题
                    worksheet.Cell(1,1).Value = "日期";
                    int column = 2;
                    foreach(var project in projects)
                    {
                        worksheet.Cell(1, column++).Value = project.Name;
                    }
                    if(dics.ContainsKey(employee.Name))
                    {
                        int row = 2;
                        foreach(var data in dics[employee.Name])
                        {
                            worksheet.Cell(row,1).Value = data.Key;
                            for(int i = 2;i<projects.Count + 2;i++)
                            {
                                var columName = worksheet.Cell(1, i).GetString();
                                worksheet.Cell(row,i).Value = data.Value.Where(w => w.ProjectName.Equals(columName)).Sum(s => s.Count);
                            }
                            row++;
                        }
                        //合计
                        worksheet.Cell(row,1).Value = "小计";
                        for (int i = 2; i < projects.Count + 2; i++)
                        {
                            var columName = worksheet.Cell(1, i).GetString();
                            worksheet.Cell(row, i).Value = dics[employee.Name].Values.Sum(s => s.Where(w => w.ProjectName.Equals(columName)).Sum(s => s.Count));
                        }
                        row++;
                        worksheet.Cell(row, 1).Value = "业绩";
                        for (int i = 2; i < projects.Count + 2; i++)
                        {
                            var columName = worksheet.Cell(1, i).GetString();
                            worksheet.Cell(row, i).Value = dics[employee.Name].Values.Sum(s => s.Where(w => w.ProjectName.Equals(columName)).Sum(s => s.Count * s.UnitCardinal));
                        }
                        row++;
                        worksheet.Cell(row, 1).Value = "提成";
                        for (int i = 2; i < projects.Count + 2; i++)
                        {
                            var columName = worksheet.Cell(1, i).GetString();
                            worksheet.Cell(row, i).Value = dics[employee.Name].Values.Sum(s => s.Where(w => w.ProjectName.Equals(columName)).Sum(s => s.Count * s.UnitPerformance));
                        }
                        row++;
                        worksheet.Cell(row, 1).Value = "业绩合计";
                        decimal totalCardinal = dics[employee.Name].Values.Sum(s => s.Sum(ss => ss.Count * ss.UnitCardinal));                        
                        worksheet.Cell(row, 2).Value = "会员业绩";
                        decimal vipCardinal = dics[employee.Name].Values.Sum(s => s.Where(w => w.UnitPerformance == 0).Sum(ss => ss.Count * ss.UnitCardinal));                        
                        worksheet.Cell(row, 3).Value = "核算提成业绩(减掉168)";
                        decimal actualCardinal =  vipCardinal - 168;
                        worksheet.Cell(row, 4).Value = "业绩提成";
                        decimal cardinalperformance = actualCardinal * rule.Where(w => w.Low <= totalCardinal && w.High > totalCardinal).First().Rate;
                        worksheet.Cell(row, 5).Value = "团购提成";
                        decimal vipPerformance = dics[employee.Name].Values.Sum(s => s.Where(w => w.UnitPerformance != 0).Sum(ss => ss.Count * ss.UnitPerformance));
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
                    }
                }

                // 设置保存路径
                //string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Sample.xlsx");

                // 保存工作簿
                workbook.SaveAs(filepath);
            }
        }
    }
}
