using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib.Domain
{
    public class ProductRevenue
    {
        public Money RatioRevenue { get; set; } = new Money(new MoneyOption());
        public Money SalaryRevenue { get; set; } = new Money(new MoneyOption());    
    }
}
