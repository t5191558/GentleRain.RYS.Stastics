using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class Tax : BaseEntity, ITax
    {
        /// <summary>
        /// 社保
        /// </summary>
        public Money SocialSecurity { get; set; } = new Money(new MoneyOption());
        /// <summary>
        /// 住房公积金
        /// </summary>
        public Money HousingFund { get; set; } = new Money(new MoneyOption());

        public TaxModel Create(TaxCreateModel tax)
        {
            throw new NotImplementedException();
        }

        public void Delete(string code)
        {
            throw new NotImplementedException();
        }

        public TaxModel GetFromCode(string code)
        {
            throw new NotImplementedException();
        }

        public TaxModel GetFromName(string name)
        {
            throw new NotImplementedException();
        }

        public List<TaxModel> Gets()
        {
            throw new NotImplementedException();
        }

        public void Update(TaxUpdateModel tax)
        {
            throw new NotImplementedException();
        }
    }
}
