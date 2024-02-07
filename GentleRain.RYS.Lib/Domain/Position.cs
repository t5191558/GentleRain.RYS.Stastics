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
    public class Position : BaseEntity, IPosition
    {
        public string Name { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public int IsDelete { get; set; }
        public int IsEnable { get; set; }

        public PositionModel Create(PositionCreateModel position)
        {
            throw new NotImplementedException();
        }

        public void Delete(string code)
        {
            throw new NotImplementedException();
        }

        public PositionModel GetFromCode(string code)
        {
            throw new NotImplementedException();
        }

        public PositionModel GetFromName(string name)
        {
            throw new NotImplementedException();
        }

        public List<PositionModel> Gets()
        {
            throw new NotImplementedException();
        }

        public void Update(PositionUpdateModel position)
        {
            throw new NotImplementedException();
        }
    }
}
