using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class RevenueSettingNotFoundException : Exception
    {
        public RevenueSettingNotFoundException(string code) : base(string.Format(ExceptionMessageText.RevenueSettingNotFound, code))
        {
        }
    }
}
