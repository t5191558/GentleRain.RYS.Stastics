using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GentleRain.RYS.Lib
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;        
        public Position? Position { get; set; }
        public User(string name, string code, Position posi)
        {
            Name = name;
            Code = code;
            Position = posi;
        }


    }
}
