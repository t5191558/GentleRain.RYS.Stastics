using GentleRain.RYS.Lib.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class Project : BaseEntity
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 收入(业绩)
        /// </summary>
        public ProductRevenue  Revenue{ get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public Money UnitPrice { get; set; } = new Money(new MoneyOption());        
        public int IsDelete { get; set; }
        public int IsEnable { get; set; }

        public Project(string name,string code, decimal unitPrice, ProductRevenue revenue, int isDelete, int isEnable)
        {
            Name = name;
            Code = code;
            UnitPrice = new Money(unitPrice,new MoneyOption());
            Revenue = revenue;
            IsDelete = isDelete;
            IsEnable = isEnable;
        }



    }
}
