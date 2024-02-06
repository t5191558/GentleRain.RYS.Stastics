using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class TaxExistsException : Exception
    {
        public TaxExistsException(string code) : base(string.Format(ExceptionMessageText.TaxExists, code))
        {
        }
    }
}
