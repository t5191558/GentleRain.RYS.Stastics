using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class PositionExistsException : Exception
    {
        public PositionExistsException(string code) : base(string.Format(ExceptionMessageText.PositionExists, code))
        {
        }
    }
}
