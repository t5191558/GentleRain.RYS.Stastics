using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthRevenue.Repository
{
    [Table("Employee")]
    public class EmployeeEntity
    {
        public int Id { get; set; }
        
        [DisplayName("员工姓名")]
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// 社保
        /// </summary>
        [DisplayName("社保")]
        public decimal SocialAmount { get; set; }
        
        /// <summary>
        /// 公积金
        /// </summary>
        [DisplayName("公积金")]
        public decimal HousFund { get; set; }
        
        /// <summary>
        /// 提成方案ID
        /// </summary>
        [DisplayName("提成方案")]
        public int? BonusMainId { get; set; }
        
        [ForeignKey("BonusMainId")]
        [Browsable(false)]
        public BonusMainEntity? BonusMain { get; set; }
    }
}
