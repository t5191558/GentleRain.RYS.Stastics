using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    /// <summary>
    /// 职位
    /// </summary>
    public class Position : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public int IsDelete { get; set; }
        public int IsEnable { get; set; }        

        public Position(string name, string code, string desc, int isDelete, int isEnable)
        {
            Name = name;
            Code = code;
            Desc = desc;
            IsDelete = isDelete;
            IsEnable = isEnable;
        }


    }
}
