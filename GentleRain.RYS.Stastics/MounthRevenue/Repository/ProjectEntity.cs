using System;
using System.Collections.Generic;
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
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 业绩
        /// </summary>
        public decimal Cardinal { get; set; }
        /// <summary>
        /// 提成-直接收入
        /// </summary>
        public decimal Performance{ get; set; }

    }
}
