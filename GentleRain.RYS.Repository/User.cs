using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Repository
{
    [Table("User")]
    public class User : BaseEntity
    {        
        public string Name { get; set; } = string.Empty;        
        public Tax? Tax { get; set; }
        public Position? Position { get; set; }
    }
}
