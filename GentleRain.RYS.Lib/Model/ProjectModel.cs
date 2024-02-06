using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class ProjectModel
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal SalryPrice { get; set; }
        public decimal RatioPrice { get; set; }
        public decimal RevenuePrice { get; set; }
    }

    public class ProjectCreateModel
    { 
        public string Name { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal SalryPrice { get; set; }
        public decimal RatioPrice { get; set; }
        public decimal RevenuePrice { get; set; }   
    }

    public class ProjectUpdateModel
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal SalryPrice { get; set; }
        public decimal RatioPrice { get; set; }
        public decimal RevenuePrice { get; set; }
    }

}
