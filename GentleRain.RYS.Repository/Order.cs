using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Repository
{
    [Table("Order")]
    public class Order : BaseEntity
    {
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public DateTime CreateTime { get; set; }
        public User? User { get; set; }  
    }
}
