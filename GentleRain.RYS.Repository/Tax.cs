using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Repository
{
    [Table("Tax")]
    public class Tax : BaseEntity
    {        
        public decimal SocialSecurity { get; set; }
        public decimal HousingFund { get; set; }
    }
}
