using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public class OrderModel
    {
        public string Code { get; set; } = string.Empty;
        public string UserCode { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public List<OrderDetailModel> Detail{ get; set; } = new List<OrderDetailModel>();
    }

    public class OrderCreateModel
    { 
        public string UserCode { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public Dictionary<string,int> Detail { get; set; } = new Dictionary<string, int>();
    
    }

    public class OrderUpdateModel
    { 
        public string Code { get; set; } = string.Empty;
        public Dictionary<string,int> Detail { get; set; } = new Dictionary<string, int>();
    }

    public class OrderDetailModel
    {
        public ProjectModel Proj { get; set; } = new ProjectModel();
        public int Count { get; set; }
    }

}
