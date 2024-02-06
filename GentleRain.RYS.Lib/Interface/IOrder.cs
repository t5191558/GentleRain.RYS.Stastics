using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public interface IOrder
    {
        OrderModel Create(OrderCreateModel order);
        void Update(OrderUpdateModel order);
        void Delete(string code);
        List<OrderModel> Gets(string userCode, DateTime orderDateStart, DateTime orderDateEnd);
    }
}
