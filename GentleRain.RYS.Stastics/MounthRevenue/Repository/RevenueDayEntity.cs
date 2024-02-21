using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthRevenue.Repository
{
    [Table("RevenueDay")]
    public class RevenueDayEntity
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [DisplayName("日期")]
        public DateTime RevenueDate { get; set; }
        [DisplayName("员工姓名")]
        public string EmployeeName { get; set; } = string.Empty;
        public int ProjectId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [DisplayName("项目名称")]
        public string ProjectName { get; set; } = string.Empty;
        /// <summary>
        /// 项目数量
        /// </summary>
        [DisplayName("项目数量")]
        public decimal Count { get; set; }
        /// <summary>
        /// 单个项目业绩
        /// </summary>
        [DisplayName("单个项目业绩")]
        public decimal UnitCardinal { get; set; }
        /// <summary>
        /// 单个项目提成
        /// </summary>
        [DisplayName("单个项目提成")]
        public decimal UnitPerformance { get; set; }
    }
}
