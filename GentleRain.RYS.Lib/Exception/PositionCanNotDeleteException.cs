using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class PositionCanNotDeleteException : Exception
    {
        public PositionCanNotDeleteException(string source) : base(string.Format(ExceptionMessageText.PositionCanNotDelete, source))
        {
        }
    }
}
