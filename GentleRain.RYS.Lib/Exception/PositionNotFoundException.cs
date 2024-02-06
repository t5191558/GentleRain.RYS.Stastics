using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class PositionNotFoundException : Exception
    {
        public PositionNotFoundException(string code) : base(string.Format(ExceptionMessageText.PositionNotExists,code))
        {
        }
    }
}
