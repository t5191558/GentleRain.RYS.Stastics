using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class MoneyOption : IMoneyOption
    {
        public int Fraction { get;}
        public RoundRule Rule { get;}
        public decimal RoundValue { get; }

        public MoneyOption()
        {
            Fraction = 2;
            Rule = RoundRule.Bank;
        }

        public IMoneyOption Build()
        {
            return new MoneyOption();
        }

        public decimal GetValue(decimal value)
        {
            return Rule switch 
            {
                RoundRule.Bank => Math.Round(value, Fraction, MidpointRounding.ToEven),
                RoundRule.FromZero => Math.Round(value, Fraction, MidpointRounding.AwayFromZero),
                RoundRule.ToZero => Math.Round(value, Fraction, MidpointRounding.ToZero),
                RoundRule.AlwaysUp => Math.Ceiling(value),
                RoundRule.AlwaysDown => Math.Floor(value),
                _ => value
            };
        }

        public string View(decimal money)
        {
            if(money < 0)
            {
                return $"-￥{GetValue(money)}";
            }
            else
            {
                return $"￥{GetValue(money)}";
            }
        }
    }
}
