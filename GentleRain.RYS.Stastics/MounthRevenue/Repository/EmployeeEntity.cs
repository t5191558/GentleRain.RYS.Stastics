using System;
using System.Collections.Generic;
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
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 社保
        /// </summary>
        public decimal SocialAmount { get; set; }
        /// <summary>
        /// 公积金
        /// </summary>
        public decimal HousFund { get; set; }
    }
}
