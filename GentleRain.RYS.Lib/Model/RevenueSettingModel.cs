using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class RevenueSettingModel
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int IsEnable { get; set; }
        public List<RevenueRatio> Setting { get; set; } = new List<RevenueRatio>();
    }

    public class RevenueSettingCreateModel
    {
        [Required(ErrorMessage = RequiredMessageText.RenevueSettingName)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessageText.RenevueSettingDetail)]
        public List<RevenueRatio> Setting { get; set; } = new List<RevenueRatio>();
    }

    public class RevenueSettingUpdateModel
    { 
        [Required(ErrorMessage = RequiredMessageText.RenevueSettingCode)]
        public string Code { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessageText.RenevueSettingName)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessageText.RenevueSettingDetail)]
        public List<RevenueRatio> Setting { get; set; } = new List<RevenueRatio>();
        public int IsEnable { get; set; }
    }


    public class  RevenueRatio
    {
        public decimal LowRevenue { get; set; }
        public decimal HighRevenue{ get; set; }
        public decimal Ratio { get; set; } 
    }
}
