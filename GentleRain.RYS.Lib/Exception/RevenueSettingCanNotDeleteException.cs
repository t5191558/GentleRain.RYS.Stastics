using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class RevenueSettingCanNotDeleteException : Exception
    {
        public RevenueSettingCanNotDeleteException(string code) : base(string.Format(ExceptionMessageText.RevenueSettingCanNotDelete, code))
        {
        }
    }
}
