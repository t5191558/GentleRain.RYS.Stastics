using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class Tax : BaseEntity
    {
        /// <summary>
        /// 社保
        /// </summary>
        public Money SocialSecurity { get; set; } = new Money(new AmountMoneyOption());
        /// <summary>
        /// 住房公积金
        /// </summary>
        public Money HousingFund { get; set; } = new Money(new AmountMoneyOption());

    }
}
