using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class AmountMoneyOption : IMoneyOption
    {
        public decimal GetValue(Money money)
        {
            return Math.Round(money.Value, 2);
        }

        public string View(Money money)
        {
            return $"￥{GetValue(money)}";
        }
    }
}
