using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public interface IPosition
    {
        /// <summary>
        /// 创建职位
        /// </summary>
        /// <param name="position">创建信息</param>
        /// <returns>创建的职位信息</returns>
        /// <exception cref="PositionExistsException"></exception>
        /// <exception cref="RevenueSettingNotFoundException"></exception>
        PositionModel Create(PositionCreateModel position);

        /// <summary>
        /// 修改职位
        /// </summary>
        /// <param name="position">修改信息</param>
        /// <exception cref="PositionNotFoundException"></exception>
        /// <exception cref="RevenueSettingNotFoundException"></exception>
        /// <exception cref="PositionExistsException"></exception>"
        void Update(PositionUpdateModel position);

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="code">职位编码</param>
        /// <exception cref="PositionNotFoundException"></exception>
        /// <exception cref="PositionCanNotDeleteException"></exception>"
        void Delete(string code);

        /// <summary>
        /// 获取职位信息 
        /// </summary>
        /// <param name="code">职位编码</param>
        /// <returns>职位信息</returns>
        /// <exception cref="PositionNotFoundException"></exception>"
        PositionModel GetFromCode(string code);
        /// <summary>
        /// 获取职位信息
        /// </summary>
        /// <param name="name">职位名称</param>
        /// <returns>职位信息</returns>
        /// <exception cref="PositionNotFoundException"></exception>""
        PositionModel GetFromName(string name);
        /// <summary>
        /// 获取所有职位
        /// </summary>
        /// <returns></returns>
        List<PositionModel> Gets();
    }
}
