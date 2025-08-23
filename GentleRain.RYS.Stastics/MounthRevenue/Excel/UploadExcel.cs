using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Office;
using MonthRevenue.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MonthRevenue.UploadExcel;

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
            using (XLWorkbook workbook = new XLWorkbook(filename, new LoadOptions {  }))
            {
                // 获取工作簿中的第一个工作表
                IXLWorksheet worksheet = workbook.Worksheet(1);
                DateTime date = DateTime.Parse(worksheet.Name);
                var excelDatas = ReadData(worksheet);
                //解析数据到业务实体
                foreach(var excelData in excelDatas)
                {
                    foreach(var lineValue in excelData.Value)
                    {
                        string employeeName = lineValue[0];
                        int employeeId = employees.Find(e => e.Name == employeeName)?.Id ?? 0;
                        if (employeeId == 0)
                        {
                            continue;
                        }
                        for(int i = 1; i < excelData.Head.Count; i++)
                        {
                            RevenueDayEntity entity = new RevenueDayEntity();
                            entity.RevenueDate = date;
                            entity.EmployeeName = employeeName;
                            entity.EmployeeId = employeeId;
                            string projectName = excelData.Head[i];
                            var p = projects.Find(p => (p.Category + p.Name) == projectName);
                            if (p == null)
                                continue;
                            entity.ProjectCategory = p.Category;
                            entity.ProjectName = p.Name;
                            entity.ProjectId = p.Id;
                            entity.UnitCardinal = p.Cardinal;
                            entity.UnitPerformance = p.Performance;
                            decimal count = 0;
                            decimal.TryParse(lineValue[i], out count);
                            entity.Count = count;
                            result.Add(entity);
                        }
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
        private static List<AreaData> ReadData(IXLWorksheet worksheet)
        {
            List<AreaData> result = new List<AreaData>();
            int lastRow = worksheet.LastRowUsed().RowNumber();
            for(int row = 1; row < lastRow; row++)
            {
                //有效区域
                if (IsValidArea(worksheet.Cell(row, 1)))
                {
                    var data = ReadArea(worksheet,row);
                    row = data.Item1;
                    result.Add(data.Item2);
                }
            }
            return result;
        }

        private static Tuple<int, AreaData> ReadArea(IXLWorksheet worksheet,int row)
        {
            var heads = ReadHead(worksheet,ref row);
            var values = ReadValue(worksheet,heads.Count,ref row);
            return new Tuple<int, AreaData>(row, new AreaData { Head = heads, Value = values }) ; 
        }

        /// <summary>
        /// 读取head
        /// </summary>
        /// <param name="worksheet"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static List<string> ReadHead(IXLWorksheet worksheet,ref int row)
        {
            List<List<string>> heads = new List<List<string>>();
            //是否是列头
            while(IsCurrentRowIsColumnRow(worksheet, row))
            {
                List<string> rowHead = new List<string>();
                for(int column = 1; HasColumn(worksheet.Cell(row, column));column++)
                {
                    IXLCell cell = worksheet.Cell(row, column);
                    string headString = GetColumn(cell);
                    rowHead.Add(headString);
                }
                heads.Add(rowHead);
                row++;
            }
            List<string> result = new List<string>();
            //合并多行的列头(因为有merge的存在,列可能占多行)
            foreach(var head in heads)
            {
                for(int index=0;index< head.Count;index++)
                {
                    string key = head[index];
                    if (result.Count <= index)
                    {
                        result.Add(key);
                    }
                    else
                    {
                        if (!result[index].Equals(key, StringComparison.OrdinalIgnoreCase))
                        {
                            result[index] += key;
                        }
                    }
                }              
            }
            return result;
        }

        private static List<List<string>> ReadValue(IXLWorksheet worksheet,int columnLength, ref int row)
        {
            List<List<string>> result = new List<List<string>>();
            while (HasColumn(worksheet.Cell(row,1)))
            {
                List<string> value = new List<string>();
                for (int column = 1; column < columnLength + 2; column++)
                {
                    value.Add(GetColumn(worksheet.Cell(row, column)));
                }
                result.Add(value);
                row++;
            }
            return result;
        }

        private static string GetColumn(IXLCell cell)
        {
            if (cell.IsMerged())
            {
                return cell.MergedRange().FirstCell().GetString();
            }
            else
            {
                return cell.GetString();
            }
        }

        private static bool IsValidArea(IXLCell cell)
        {
            return GetColumn(cell).Equals("姓名", StringComparison.OrdinalIgnoreCase);            
        }

        private static bool HasColumn(IXLCell cell)
        {
            return !string.IsNullOrEmpty(GetColumn(cell));
        }


        private static bool IsCurrentRowIsColumnRow(IXLWorksheet worksheet ,int row)
        {
            var cell = worksheet.Cell(row, 1);
            return GetColumn(cell).Equals("姓名", StringComparison.OrdinalIgnoreCase);
        }

        public class AreaData
        {
            public List<string> Head { get; set; } = new List<string>();
            public List<List<string>> Value { get; set; } = new List<List<string>>();
        }


    }
}
