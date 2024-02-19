using AutoMapper;
using GentleRain.RYS.Lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class Tax : BaseEntity, ITax
    {
        private ITaxRepository TaxRepository { get; set; }
        private IMapper mapper { get; set; }
        

        public Tax(ITaxRepository taxRepository, IMapper mapper)
        {
            TaxRepository = taxRepository;
            this.mapper = mapper;
        }

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
            var tempTax = mapper.Map<Tax>(tax);
            var taxCreated = TaxRepository.AddAsync(tempTax ?? throw new TaxNotFoundException(tax.Name)).Result;
            return mapper.Map<TaxModel>(taxCreated) ?? throw new TaxNotFoundException(tax.Name);
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
