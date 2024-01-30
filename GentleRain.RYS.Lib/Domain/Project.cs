using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class Project : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 单价
        /// </summary>
        public Money UnitPrice { get; set; } = new Money(new PriceMoneyOption());        
        /// <summary>
        /// 业绩-实际销售金额
        /// </summary>
        public Money SalesAmount { get; set; } = new Money(new AmountMoneyOption());
        /// <summary>
        /// 纯业绩-给员工算提成的金额
        /// </summary>
        public Money PureSalesAmount { get; set; }  = new Money(new AmountMoneyOption());
        /// <summary>
        /// 提成金额
        /// </summary>
        public Money SalaryAmount { get; set; } = new Money(new AmountMoneyOption());
        public int IsDelete { get; set; }
        public int IsEnable { get; set; }

        public Project(string name,string code, decimal unitPrice, decimal salesAmount,decimal pureSalesAmount, decimal salaryAmount, int isDelete, int isEnable)
        {
            Name = name;
            Code = code;
            UnitPrice = new Money(unitPrice,new PriceMoneyOption());
            SalesAmount = new Money(salesAmount, new AmountMoneyOption());
            PureSalesAmount = new Money(pureSalesAmount, new AmountMoneyOption());
            SalaryAmount = new Money(salaryAmount, new AmountMoneyOption());
            IsDelete = isDelete;
            IsEnable = isEnable;
        }

        public Order Sell(User user, DateTime dt)
        {
            return new Order(user, dt, this);
        }

    }
}
