using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class RevenueModel
    {
        public string Code { get; set; } = string.Empty;
        public string UserCode { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public int Year { get; set;}
        public int Month { get; set; }
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
        public decimal TotalSalary { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalRatio { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal Ratio { get; set; }

    }

    public class RevenueCreateModel
    {
        public string UserCode { get; set; } = string.Empty;
        public int Year { get; set; }
        public int Month { get; set; }
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }

    public class RevenueUpdateModel
    {
        public string Code { get; set; } = string.Empty;
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}
