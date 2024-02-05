using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public interface IMoneyOption
    {
        public int Fraction{ get; } 
        public RoundRule Rule { get; }
        public decimal RoundValue { get; }
        decimal GetValue(decimal money);
        string View(decimal money);
    }

    public enum RoundRule 
    {
        [Description("银行家舍入,舍入到最接近的偶数")]
        Bank,
        [Description("四舍五入到远离零的方向")]
        FromZero,
        [Description("四舍五入到近零的方向")]
        ToZero,
        [Description("只要有小数则向上取整")]
        AlwaysUp,
        [Description("只要有小数则向下取整")]
        AlwaysDown,
    }

}
