using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    /// <summary>
    /// 定义金钱类,用来描述金钱
    /// </summary>
    public class Money
    {
        private readonly IMoneyOption option = new AmountMoneyOption();
        /// <summary>
        /// 金额
        /// </summary>
        private decimal Value;

        public Money(IMoneyOption option)
        {
            this.option = option;
            Value = 0;
        }


        public Money(decimal value, IMoneyOption option)
        {
            Value = value;
            this.option = option;
        }



        public decimal GetValue()
        {
            return option.GetValue(Value);
        }

        public static Money operator +(Money x) => x;

        public static Money operator -(Money x)
        {
            x.Value = -x.Value;
            return x;
        }

        public static Money operator +(Money x, decimal v)
        {
            x.Value += v;
            return x;
        }

        public static Money operator -(Money x, decimal v)
        {
            x.Value -= v;
            return x;
        }

        public static Money operator *(Money x, decimal v)
        {
            x.Value *= v;
            return x;
        }

        public static Money operator /(Money x, decimal v)
        {
            if (v == 0)
            {
                throw new DivideByZeroException();
            }
            x.Value /= v;
            return x;
        }

        public static Money operator +(Money x, Money y)
        {
            return new Money(x.Value + y.Value);
        }

        public static Money operator -(Money x, Money y)
        {
            return new Money(x.Value - y.Value);
        }

        public static Money operator *(Money x, Money y)
        {
            return new Money(x.Value * y.Value);
        }

        public static Money operator /(Money x, Money y)
        {
            if (y.Value == 0)
            {
                throw new DivideByZeroException();
            }
            return new Money(x.Value / y.Value);
        }
        public static bool operator ==(Money x, Money y) => x.Equals(y);
        public static bool operator !=(Money x, Money y) => !(x.Value == y.Value);
        public static bool operator >(Money x, Money y) => x.Value > y.Value;
        public static bool operator >=(Money x, Money y) => x.Value >= y.Value;
        public static bool operator <(Money x, Money y) => x.Value < y.Value;
        public static bool operator <=(Money x, Money y) => x.Value <= y.Value;
        public static implicit operator decimal(Money x) => x.Value;        
        public override bool Equals(object? obj)
        {            
            return obj is Money money && Value == money.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override string ToString()
        {
            return option.View(Value);
        }


    }

}
