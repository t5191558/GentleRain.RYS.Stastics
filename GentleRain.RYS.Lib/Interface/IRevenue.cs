using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public interface IRevenue
    {
        RevenueModel Create(RevenueCreateModel revenue);
        RevenueModel Upate(RevenueUpdateModel revenue);
        void Delete(string code);
        RevenueModel Get(string userCode,int year,int month);
    }
}
