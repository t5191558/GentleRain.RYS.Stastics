using System;
using System.Collections.Generic;
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
        public string EmployeeName { get; set; } = string.Empty;
        public int ProjectId { get; set; }
        public int ProjectName { get; set; }
        public decimal Count { get; set; }
        public decimal UnitCardinal { get; set; }
        public decimal UnitPerformance { get; set; }
    }
}
