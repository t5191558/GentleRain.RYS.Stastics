using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class UserDeletedException : Exception
    {
        public UserDeletedException(string name) : base(string.Format(ExceptionMessageText.UserDeleted, name)) { }
    }
}
