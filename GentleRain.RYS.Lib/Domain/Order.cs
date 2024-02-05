using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class Order
    {
        private Dictionary<Project, int> Projects = new Dictionary<Project, int>();
        public DateTime CreateTime { get; set; }
        public User User { get; set; }
        public Order(User user,DateTime dt)
        {
            User = user;
            CreateTime = dt;
        }
        
        public void AddProject(Project project, int count)
        {
            if (Projects.ContainsKey(project))
            {
                Projects[project] += count;
            }
            else
            {
                Projects.Add(project, count);
            }
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
