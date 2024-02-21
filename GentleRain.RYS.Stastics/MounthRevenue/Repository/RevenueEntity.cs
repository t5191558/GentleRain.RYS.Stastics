using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthRevenue.Repository
{
    [Table("Revenue")]
    public class RevenueEntity
    {
        public int Id { get; set; }
        public DateTime RevenueDate { get; set; }
        /// <summary>
        /// 总业绩
        /// </summary>
        public decimal TotalPerformance { get; set; }
        /// <summary>
        /// 会员业绩
        /// </summary>
        public decimal VipPerformance { get; set; }
        /// <summary>
        /// 提成业绩-用来计算提成
        /// </summary>
        public decimal BonusPerformance { get; set; }
        /// <summary>
        /// 总提成
        /// </summary>
        public decimal TotalBonus { get; set; }
        /// <summary>
        /// 业绩提成
        /// </summary>
        public decimal PerformanceBonus { get; set; }
        /// <summary>
        /// 团购提成
        /// </summary>
        public decimal VipBonus { get; set; }
    }
}
