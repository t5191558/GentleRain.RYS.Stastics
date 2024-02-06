using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public interface ICost
    {
        /// <summary>
        /// 创建费用
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="CostExistsException"></exception>
        CostModel Create(CostCreateModel cost);
        /// <summary>
        /// 编辑费用
        /// </summary>
        /// <param name="cost"></param>
        /// <exception cref="CostNotFoundException"></exception>
        void Update(CostUpdateModel cost);
        /// <summary>
        /// 删除费用
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <exception cref="CostNotFoundException"></exception>"
        void Delete(string code);
        /// <summary>
        /// 获取费用
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        CostModel Get(string userCode, int year, int month);

    }
}
