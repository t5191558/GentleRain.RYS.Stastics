using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class TaxCanNotDeleteException : Exception
    {
        public TaxCanNotDeleteException(string source) : base(string.Format(ExceptionMessageText.TaxCanNotDelete, source))
        {
        }
    }
}
