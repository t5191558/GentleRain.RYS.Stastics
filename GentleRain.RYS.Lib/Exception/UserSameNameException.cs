using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class UserSameNameException :  Exception
    {
        public UserSameNameException(string name):base(string.Format(ExceptionMessageText.SameNameUser,name)) { }
    }
}
