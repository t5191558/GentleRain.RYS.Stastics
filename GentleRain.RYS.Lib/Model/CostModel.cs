using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class CostModel
    {
        public string UserCode { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Month { get; set; }
        /// <summary>
        /// 水费
        /// </summary>
        public decimal Water { get; set; }
        /// <summary>
        /// 电费
        /// </summary>
        public decimal Electric { get; set; }
        /// <summary>
        /// 杂费
        /// </summary>
        public decimal Other { get; set; }
        /// <summary>
        /// 考勤费
        /// </summary>
        public decimal Checking { get; set; }
    }

    public class CostCreateModel
    {
        [Required(ErrorMessage = RequiredMessageText.UserCode)]
        public string UserCode { get; set; } = string.Empty;
        [Range(2024,3000,ErrorMessage = RequiredMessageText.Year)]
        public int Year { get; set; }
        [Range(1,12,ErrorMessage = RequiredMessageText.Month)]
        public int Month { get; set; }
        /// <summary>
        /// 水费
        /// </summary>
        public decimal Water { get; set; }
        /// <summary>
        /// 电费
        /// </summary>
        public decimal Electric { get; set; }
        /// <summary>
        /// 杂费
        /// </summary>
        public decimal Other { get; set; }
        /// <summary>
        /// 考勤费
        /// </summary>
        public decimal Checking { get; set; }
    }

    public class CostUpdateModel
    {
        [Required(ErrorMessage = RequiredMessageText.CostCode)]
        public string Code { get; set; } = string.Empty;
        [Range(2024, 3000, ErrorMessage = RequiredMessageText.Year)]
        public int Year { get; set; }
        [Range(1, 12, ErrorMessage = RequiredMessageText.Month)]
        public int Month { get; set; }
        /// <summary>
        /// 水费
        /// </summary>
        public decimal Water { get; set; }
        /// <summary>
        /// 电费
        /// </summary>
        public decimal Electric { get; set; }
        /// <summary>
        /// 杂费
        /// </summary>
        public decimal Other { get; set; }
        /// <summary>
        /// 考勤费
        /// </summary>
        public decimal Checking { get; set; }
    }

}
