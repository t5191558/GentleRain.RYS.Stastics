using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class PositionModel
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set;} = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public string RevenueSettingCode { get; set; } = string.Empty;
        public string RevenueSettingName { get; set; } = string.Empty;
        public int IsEnable { get; set; }
    }

    public class PositionCreateModel
    {
        [Required(ErrorMessage =RequiredMessageText.PositionName)]
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessageText.RenevueSettingCode)]
        public string RevenueSettingCode { get; set; } = string.Empty;

    }

    public class PositionUpdateModel
    {
        [Required(ErrorMessage =RequiredMessageText.PositionCode)]
        public string Code { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessageText.PositionName)]
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessageText.RenevueSettingCode)]
        public string RevenueSettingCode { get; set; } = string.Empty;
        public int IsEnable { get; set; }
    }

}
