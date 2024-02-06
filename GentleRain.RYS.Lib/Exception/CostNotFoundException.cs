using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class CostNotFoundException : Exception
    {
        public CostNotFoundException(string userName,int year,int month) : base(string.Format(ExceptionMessageText.CostNotFound, userName,year,month))
        {
        }
    }
}
