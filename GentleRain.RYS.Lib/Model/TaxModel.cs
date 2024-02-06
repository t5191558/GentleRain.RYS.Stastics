using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class TaxModel
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 社保
        /// </summary>
        public decimal SocialSecurity { get; set; }
        /// <summary>
        /// 住房公积金
        /// </summary>
        public decimal HousingFund { get; set; } 
        public int IsEnable { get; set; }
    }

    public class TaxCreateModel
    {
        [Required(ErrorMessage = RequiredMessageText.TaxName)]
        public string Name { get; set; } = string.Empty;
        public decimal SocialSecurity { get; set; }
        public decimal HousingFund { get; set; } 
    }
    public class TaxUpdateModel
    {
        [Required(ErrorMessage = RequiredMessageText.TaxCode)]
        public string Code { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessageText.TaxName)]
        public string Name { get; set; } = string.Empty;
        public decimal SocialSecurity { get; set; }
        public decimal HousingFund { get; set; }
        public int IsEnable { get; set; }
    }
}
