using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public interface ITax 
    {
        /// <summary>
        /// 创建税率
        /// </summary>
        /// <param name="tax"></param>
        /// <returns></returns>
        /// <exception cref="TaxExistsException"></exception>
        TaxModel Create(TaxCreateModel tax);
        /// <summary>
        /// 修改税率
        /// </summary>
        /// <param name="tax"></param>
        /// <exception cref="TaxNotFoundException"></exception>
        /// <exception cref="TaxExistsException"></exception>
        void Update(TaxUpdateModel tax);
        /// <summary>
        /// 删除税率
        /// </summary>
        /// <param name="code">编码</param>
        /// <exception cref="TaxNotFoundException"></exception>"
        /// <exception cref="TaxCanNotDeleteException"></exception>
        void Delete(string code);
        /// <summary>
        /// 获取税率 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="TaxNotFoundException"></exception>
        TaxModel GetFromCode(string code);
        /// <summary>
        /// 获取税率
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="TaxNotFoundException"></exception>
        TaxModel GetFromName(string name);
        /// <summary>
        /// 获取所有税率
        /// </summary>
        /// <returns></returns>
        List<TaxModel> Gets();
    }
}
