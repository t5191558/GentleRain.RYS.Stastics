using System;
using System.Collections.Generic;
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
        public decimal Low { get; set; }
        public decimal High { get; set; }
        public decimal Rate { get; set; }
    }
}
