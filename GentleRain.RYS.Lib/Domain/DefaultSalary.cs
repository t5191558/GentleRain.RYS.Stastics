using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class DefaultSalary : ISalary
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Desc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public decimal GetMoney(ICollection<Order> pureSalesAmount)
        {
            throw new NotImplementedException();
        }

        public decimal GetRatio(ICollection<Order> salesAmount)
        {
            throw new NotImplementedException();
        }
    }
}
