using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthRevenue.Repository
{
    [Table("RevenueDetail")]
    public class RevenueDetailEntity
    {
        public int Id { get; set; }
        public int RevenueId { get; set; }
        public int EmployeeId { get; set; }
        [DisplayName("员工姓名")]
        public string EmployeeName { get; set; } = string.Empty;
        public int ProjectId { get; set; }
        [DisplayName("项目名称")]
        public int ProjectName { get; set; }
        [DisplayName("项目数量")]
        public decimal Count { get; set; }
        [DisplayName("单个项目业绩")]
        public decimal UnitCardinal { get; set; }
        [DisplayName("单个项目提成")]
        public decimal UnitPerformance { get; set; }
    }
}
