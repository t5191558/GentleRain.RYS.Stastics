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
        public int IsDelete { get; set; }
        public int IsEnable { get; set; }
        public Position? Position { get; set; }
        public Tax? Tax { get; set; }
        public User(string name, string code, Position posi)
        {
            Name = name;
            Code = code;
            Position = posi;
        }

        public User(string name, string code, Position posi, Tax tax)
        {
            Name = name;
            Code = code;
            Position = posi;
            Tax = tax;
        }

    }
}
