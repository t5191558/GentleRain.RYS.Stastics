using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class PriceMoneyOption : IMoneyOption
    {
        public decimal GetValue(decimal value)
        {
            return Math.Round(value, 3);
        }

        public string View(decimal money)
        {
            if(money < 0)
            {
                return $"-￥{GetValue(money)}";
            }
            else
            {
                return $"￥{GetValue(money)}";
            }
        }
    }
}
