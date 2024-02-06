using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public static class RequiredMessageText
    {
        public const string UserName = "用户名不能为空";
        public const string Position = "职位不能为空";
        public const string UserCode = "用户编码不能空";

        public const string PositionName = "职位名称不能为空"; 
        public const string PositionCode = "职位编码不能为空"; 

        public const string RenevueSettingCode = "提成设置编码不能为空";
        public const string RenevueSettingName = "提成设置名称不能为空";
        public const string RenevueSettingDetail = "提成设置明细不能为空";

        public const string TaxCode = "税率编码不能为空";
        public const string TaxName = "税率名称不能为空";

        public const string Year = "年份不能在2024-3000之外";
        public const string Month = "月份不能在1-12之外";
        public const string CostCode = "费用编码不能为空";
    }
}
