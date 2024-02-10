﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string name) : base(string.Format(ExceptionMessageText.UserNotFound,name))
        {
        }
    }
}
