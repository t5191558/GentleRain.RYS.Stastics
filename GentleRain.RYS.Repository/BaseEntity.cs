using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Repository
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public int IsDelete { get; set; }
        public int IsEnable { get; set; }
    }
}
