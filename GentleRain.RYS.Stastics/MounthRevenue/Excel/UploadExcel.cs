using ClosedXML.Excel;
using MonthRevenue.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthRevenue
{
    public static class UploadExcel
    {
        public static List<RevenueDayEntity> Upload(string filename)
        {
            List<RevenueDayEntity> result = new List<RevenueDayEntity>();
            MonthContext context = new MonthContext();
            var projects = context.Projects.ToList();
            var employees = context.Employees.ToList();
            using (XLWorkbook workbook = new XLWorkbook(filename))
            {
                // 获取工作簿中的第一个工作表
                IXLWorksheet worksheet = workbook.Worksheet(1);

                // 遍历工作表中的所有行和列
                // 假设第一行是标题行，并且你想从第二行开始处理
                IXLRow columnRow = worksheet.Row(1);
                IXLRow columnRow2 = worksheet.Row(2);
                int lastRow = worksheet.LastRowUsed().RowNumber();
                int lastColumn = worksheet.LastColumnUsed().ColumnNumber();
                for (int rowNum = 3; rowNum <= lastRow; rowNum++)
                {
                    // 获取当前行
                    IXLRow row = worksheet.Row(rowNum);
                    for(int columnNum = 2;columnNum <= lastColumn; columnNum++)
                    {
                        RevenueDayEntity entity = new RevenueDayEntity();
                        entity.RevenueDate = DateTime.Parse(worksheet.Name);
                        entity.EmployeeName = row.Cell(1).GetString();
                        entity.EmployeeId = employees.Find(e => e.Name == entity.EmployeeName)?.Id ?? 0;
                        if (entity.EmployeeId == 0)
                            continue;
                        var projectName = columnRow.Cell(columnNum).GetString() + columnRow2.Cell(columnNum).GetString();
                        var p = projects.Find(p => p.Name == projectName);
                        if (p == null)
                            continue;
                        entity.ProjectName = projectName;
                        entity.ProjectId = p.Id;
                        entity.UnitCardinal = p.Cardinal;
                        entity.UnitPerformance = p.Performance;
                        decimal count = 0;
                        decimal.TryParse(row.Cell(columnNum).GetString(), out count);
                        entity.Count = count;
                        result.Add(entity);
                    }
                }

            }
            return result;
        }

    }
}
