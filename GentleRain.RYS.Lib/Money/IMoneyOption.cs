using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public interface IMoneyOption
    {
        decimal GetValue(Money money);
        string View(Money money);
    }
}
