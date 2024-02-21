using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("日期")]
        public DateTime RevenueDate { get; set; }
        /// <summary>
        /// 总业绩
        /// </summary>
        [DisplayName("总业绩")]
        public decimal TotalPerformance { get; set; }
        /// <summary>
        /// 会员业绩
        /// </summary>
        [DisplayName("会员业绩")]
        public decimal VipPerformance { get; set; }
        /// <summary>
        /// 提成业绩-用来计算提成
        /// </summary>
        [DisplayName("提成业绩")]
        public decimal BonusPerformance { get; set; }
        /// <summary>
        /// 总提成
        /// </summary>
        [DisplayName("总提成")]
        public decimal TotalBonus { get; set; }
        /// <summary>
        /// 业绩提成
        /// </summary>
        [DisplayName("业绩提成")]
        public decimal PerformanceBonus { get; set; }
        /// <summary>
        /// 团购提成
        /// </summary>
        [DisplayName("团购提成")]
        public decimal VipBonus { get; set; }
    }
}
