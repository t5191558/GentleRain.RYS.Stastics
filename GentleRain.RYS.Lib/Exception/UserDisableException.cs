using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class UserDisableException : Exception
    {
        public UserDisableException(string name) : base(string.Format(ExceptionMessageText.UserDisable, name)) { }
    }
}
