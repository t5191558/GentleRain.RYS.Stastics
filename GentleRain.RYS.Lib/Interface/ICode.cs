using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public interface ICode
    {
        string Generator();
    }

    public enum CodeObject 
    { 
        User,
        Position,
        Revenue,
        Project,
        Order
    }

}
