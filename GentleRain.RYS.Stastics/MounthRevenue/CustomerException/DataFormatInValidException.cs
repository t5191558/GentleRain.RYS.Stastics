using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthRevenue
{
    public class DataFormatInValidException : Exception 
    {
        public DataFormatInValidException(string dataName,string reason) : base($"{dataName}数据格式错误:{reason}") { }
    }
}
