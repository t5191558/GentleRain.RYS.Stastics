using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public interface ISalary
    {
        string Name { get; set; }
        string Desc { get; set; }
        
        /// <summary>
        /// 获取提成比例
        /// </summary>
        /// <param name="salesAmount"></param>
        /// <returns></returns>
        decimal GetRatio(ICollection<Order> salesAmount);
        /// <summary>
        /// 获取提成金额
        /// </summary>
        /// <param name="pureSalesAmount"></param>
        /// <returns></returns>
        decimal GetMoney(ICollection<Order> pureSalesAmount);


    }
}
