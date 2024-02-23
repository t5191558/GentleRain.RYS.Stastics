using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using MonthRevenue.Repository;
using System;
using System.Collections;
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

                //在第一列读取到"姓名"字符串时,该行为列头
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

        /// <summary>
        /// 读取区域数据
        /// </summary>
        /// <param name="worksheet">当前sheet表</param>        
        /// <returns></returns>
        private static Dictionary<string, Dictionary<string,decimal>> ReadData(IXLWorksheet worksheet)
        {
            Dictionary<string, Dictionary<string,decimal>> result = new Dictionary<string, Dictionary<string,decimal>>();
            int lastRow = worksheet.LastRowUsed().RowNumber();
            for(int row = 0; row < lastRow; row++)
            {
                //有效区域
                if (IsValidArea(worksheet.Cell(row, 1)))
                {
                    var readedValues = ReadArea(worksheet,row);
                    row = readedValues.Item1;
                    foreach(var line in readedValues.Item3)
                    {
                        foreach(var key in readedValues.Item2)
                        {
                            int index = readedValues.Item2.IndexOf(key);
                            //行首
                            if(index == 0)
                            {
                                if (!result.ContainsKey(line[index]))
                                {
                                    result.Add(line[index], new Dictionary<string, decimal>());
                                }
                            }
                            else
                            {
                                if (result[line[0]].ContainsKey(key))
                                {
                                    result[line[0]][key] = result[line[0]][key] + decimal.Parse(line[index]);
                                }
                                else
                                {
                                    result[line[0]][key] = decimal.Parse(line[index]);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        private static Tuple<int, List<string>, List<List<string>>> ReadArea(IXLWorksheet worksheet,int row)
        {
            var heads = ReadHead(worksheet,row);
            var values = ReadValue();
            return new Tuple<int, List<string>, List<List<string>>>(row, heads, values);
        }

        private static List<string> ReadHead(IXLWorksheet worksheet,int row)
        {
            //读取列头
            if (IsCurrentRowIsColumnRow(worksheet, row))
            {
                int column = 2;
                IXLCell cell = worksheet.Cell(row, column);
                while (HasColumn(cell))
                {
                    string key = GetColumn(cell);
                    cell = worksheet.Cell(row, ++column);
                }
            }
            return new List<string>();
        }

        private static List<List<string>> ReadValue()
        {
            return new List<List<string>>();
        }

        private static bool IsValidArea(IXLCell cell)
        {
            return cell.GetString().Equals("姓名", StringComparison.OrdinalIgnoreCase);
        }

        private static bool HasColumn(IXLCell cell)
        {
            return !string.IsNullOrEmpty(GetColumn(cell));
        }

        private static string GetColumn(IXLCell cell)
        {
            return cell.GetString();
        }

        private static bool IsCurrentRowIsColumnRow(IXLWorksheet worksheet ,int row)
        {
            return worksheet.Cell(row,1).GetString().Equals("姓名", StringComparison.OrdinalIgnoreCase);
        }


    }
}
