using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class Order
    {
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public DateTime CreateTime { get; set; }
        public User User { get; set; }
        public Order(User user,DateTime dt, Project proj)
        {
            User = user;
            CreateTime = dt;
            Projects.Add(proj);
        }        

        public Money SalesAmount()
        {
            decimal total = Projects.Sum(p => p.SalesAmount);
            return new Money(total, new AmountMoneyOption());
        }

        public Money PureSalesAmount()
        {
            decimal total = Projects.Sum(p => p.PureSalesAmount);
            return new Money(total, new AmountMoneyOption());
        }

        public Money SalaryAmount()
        {
            decimal total = Projects.Sum(p => p.SalaryAmount);
            return new Money(total, new AmountMoneyOption());
        }


    }
}
