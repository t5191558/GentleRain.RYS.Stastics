using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthRevenue.Repository
{
    [Table("BonusRule")]
    public class BonusEntity
    {
        public int Id { get; set; }
        [DisplayName("业绩范围开始(包含)")]
        public decimal Low { get; set; }
        [DisplayName("业绩范围结束(不包含)")]
        public decimal High { get; set; }
        [DisplayName("提成比率")]
        public decimal Rate { get; set; }
    }
}
