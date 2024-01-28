using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public static bool operator ==(BaseEntity left, BaseEntity right) => left.Equals(right);
        public static bool operator !=(BaseEntity left, BaseEntity right) => !(left == right);

        public override bool Equals(object? obj)
        {
            return obj is BaseEntity entity && Code == entity.Code;
        }


        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }
    }
}
