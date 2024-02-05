using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class Order
    {
        public Dictionary<Project, int> Projects { get; set; } = new Dictionary<Project, int>();
        public DateTime CreateTime { get; set; }
        public User User { get; set; }
        public Order(User user,DateTime dt, Project proj, int count)
        {
            User = user;
            CreateTime = dt;
            Projects.TryAdd(proj, count);
        }        

        public Money SalesAmount()
        {
            throw new Exception();
        }

        public Money PureSalesAmount()
        {
            throw new Exception();
        }

        public Money SalaryAmount()
        {
            throw new Exception();
        }


    }
}
