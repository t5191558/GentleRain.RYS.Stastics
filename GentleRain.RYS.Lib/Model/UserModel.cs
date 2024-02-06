using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class UserModel
    {
        [Required(ErrorMessage = RequiredMessageText.UserCode)]
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string PositionCode { get; set; } = string.Empty;
        public string PositionName { get; set; } = string.Empty;
        public int IsEnable { get; set; }
        public TaxModel? Tax{ get; set; }
    }

    public class UserCreateModel
    {
        [Required(ErrorMessage = RequiredMessageText.UserName)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessageText.Position)]
        public string PositionCode { get; set; } = string.Empty;
        public string? TaxCode { get; set; }
    }   

    public class UserUpdateModel 
    { 
        [Required(ErrorMessage = RequiredMessageText.UserCode)]
       public string Code { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessageText.UserName)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = RequiredMessageText.Position)]
        public string PositionCode { get; set; } = string.Empty;
        public string? TaxCode { get; set; }
    }
}
