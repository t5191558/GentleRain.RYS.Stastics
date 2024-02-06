using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public static class ExceptionMessageText
    {
        public const string SameNameUser = "已经存在名为{0}的用户";
        public const string UserDeleted = "用户{0}已经被删除";
        public const string UserDisable = "用户{0}已经被禁用";
        public const string UserNotFound = "用户{0}不存在";
        public const string UserCanNotDelete = "用户已经被{0}使用,无法删除";

        public const string PositionNotExists = "职位{0}不存在";
        public const string PositionExists = "职位{0}已存在";
        public const string PositionDisable = "职位{0}已经被禁用";
        public const string PositionCanNotDelete = "职位已经被{0}使用,无法删除";

        public const string TaxExists = "{0}税种已存在";
        public const string TaxDisable = "税种{0}已经被禁用";
        public const string TaxNotFound = "{0}税种不存在";
        public const string TaxCanNotDelete = "税种已经被{0}使用,无法删除";

        public const string RevenueSettingNotFound = "{0}提成设置不存在";
        public const string RevenueSettingExists = "{0}提成设置已存在";
        public const string RevenueSettingCanNotDelete = "提成设置已经被{0}使用,无法删除";

        public const string CostNotFound = "人员{0} {1}年{2}月 费用不存在";
        public const string CostExists = "人员{0} {1}年{2}月 费用已存在";

    }
}
