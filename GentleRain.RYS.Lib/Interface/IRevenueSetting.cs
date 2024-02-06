using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public interface IRevenueSetting
    {
        /// <summary>
        /// 创建提成比率配置 
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        /// <exception cref="RevenueSettingExistsException"></exception>
        RevenueSettingModel Create(RevenueSettingCreateModel setting);

        /// <summary>
        /// 修改提成比率配置
        /// </summary>
        /// <param name="setting"></param>
        /// <exception cref="RevenueSettingNotFoundException"></exception>
        /// <exception cref="RevenueSettingExistsException"></exception>
        void Update(RevenueSettingUpdateModel setting);
        /// <summary>
        /// 删除提成比率配置
        /// </summary>
        /// <param name="code"></param>
        /// <exception cref="RevenueSettingNotFoundException"></exception>
        /// <exception cref="RevenueSettingCanNotDeleteException"></exception>
        void Delete(string code);
        /// <summary>
        /// 查找提成配置
        /// </summary>
        /// <param name="code">提成设置编号</param>
        /// <returns></returns>
        /// <exception cref="RevenueSettingNotFoundException"></exception>"
        RevenueSettingModel GetFromCode(string code);
        /// <summary>
        /// 查找提成配置
        /// </summary>
        /// <param name="name">提成设置名称</param>
        /// <returns></returns>
        /// <exception cref="RevenueSettingNotFoundException"></exception>
        RevenueSettingModel GetFromName(string name);
        /// <summary>
        /// 获取所有提成配置
        /// </summary>
        /// <returns></returns>
        List<RevenueSettingModel> Gets();
    }
}
