using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonthRevenue.Repository
{
    [Table("BonusMain")]
    public class BonusMainEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Desc { get; set; }

        public bool IsActive { get; set; }

        public bool IsDefault { get; set; }

        [DisplayName("底薪")]
        public decimal? BasicPay { get; set; }

        [Browsable(false)]
        public List<BonusEntity> BonusRules { get; set; } = new();
    }
}
