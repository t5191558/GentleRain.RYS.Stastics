using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class TaxNotFoundException : Exception
    {
        public TaxNotFoundException(string code) : base(string.Format(ExceptionMessageText.TaxNotFound, code))
        {
        }
    }
}
