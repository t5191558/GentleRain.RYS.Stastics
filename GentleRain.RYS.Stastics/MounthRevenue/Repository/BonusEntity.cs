using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("业绩范围低(包含)")]
        [Range(0,100000000)]
        public decimal Low { get; set; }
        [DisplayName("业绩范围高(不包含)")]
        [Range(0,100000000)]
        public decimal High { 
            get { return high; } 
            set { 
                    if(value <= Low)
                        throw new DataFormatInValidException("业绩范围高", "必须大于业绩范围低");
                    high = value;
                } 
        }
        [DisplayName("提成比率")]
        [Range(0,1,MaximumIsExclusive =true)]
        public decimal Rate { get; set; }

        private decimal high { get; set; }

        public int BonusMainId { get; set; }

        [Browsable(false)]
        [ForeignKey(nameof(BonusMainId))]
        public BonusMainEntity? BonusMain { get; set; }

    }
}
