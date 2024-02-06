using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class RevenueSettingExistsException : Exception
    {
        public RevenueSettingExistsException(string code) : base(string.Format(ExceptionMessageText.RevenueSettingExists, code))
        {
        }
    }
}
