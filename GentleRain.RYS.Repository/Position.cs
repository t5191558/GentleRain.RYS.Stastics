using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Repository
{
    [Table("Position")]
    public class Position : BaseEntity
    {        
        public string Name { get; set; } = string.Empty;  
        public string Desc { get; set; } = string.Empty;
        public string SalaryCode { get; set; } = string.Empty;  
        public string SalaryName { get; set; } = string.Empty;
    }
}
