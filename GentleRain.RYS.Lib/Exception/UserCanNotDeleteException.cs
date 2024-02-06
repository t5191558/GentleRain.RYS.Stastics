using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class UserCanNotDeleteException : Exception
    {
        public UserCanNotDeleteException(string source) : base(string.Format(ExceptionMessageText.UserCanNotDelete, source))
        {
        }
    }
}
