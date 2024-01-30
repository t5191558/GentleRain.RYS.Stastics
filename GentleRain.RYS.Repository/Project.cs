using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Repository
{
    [Table("Project")]
    public class Project : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal PureSalesAmount { get; set; }
        public decimal SalaryAmount { get; set; }
    }
}
