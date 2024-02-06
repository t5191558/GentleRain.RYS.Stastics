using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class TaxDisableException : Exception
    {
        public TaxDisableException(string code) : base(string.Format(ExceptionMessageText.TaxDisable, code))
        {
        }
    }
}
