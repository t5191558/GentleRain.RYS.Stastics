using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthRevenue.Repository
{
    /// <summary>
    /// 项目表
    /// </summary>
    [Table("Project")]
    public class ProjectEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// 项目类别 
        /// </summary>
        [DisplayName("项目类别")]
        public string? Category { get; set; }
        [DisplayName("项目名称")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 业绩
        /// </summary>
        [DisplayName("项目业绩")]
        public decimal Cardinal { get; set; }
        /// <summary>
        /// 提成-直接收入
        /// </summary>
        [DisplayName("项目提成(某些项目有)")]
        public decimal Performance{ get; set; }


        public string Key()
        {
            return (Category ?? "") + Name;
        }

    }
}
