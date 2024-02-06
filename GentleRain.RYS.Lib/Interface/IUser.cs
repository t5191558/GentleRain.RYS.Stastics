using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public interface IUser
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">创建该用户的信息</param>
        /// <returns>返回用户信息</returns>
        /// <exception cref="UserSameNameException">已经存在相同名字的用户</exception>
        /// <exception cref="PositionNotFoundException">职位不存在</exception>"
        /// <exception cref="PositionDisableException">职位被禁用</exception>"
        /// <exception cref="TaxNotFoundException">税收不存在</exception>"
        /// <exception cref="TaxDisableException">税收被禁用</exception>"
        UserModel Create(UserCreateModel user);

        /// <summary>
        /// 修改用户信息 
        /// </summary>
        /// <param name="user">修改编码对应用户的姓名、职务、税收</param>
        /// <exception cref="UserNotFoundException">用户不存在</exception>"
        /// <exception cref="UserSameNameException">已经存在相同名字的用户</exception>
        /// <exception cref="PositionNotFoundException">职位不存在</exception>"
        /// <exception cref="PositionDisableException">职位被禁用</exception>"
        /// <exception cref="TaxNotFoundException">税收不存在</exception>"
        /// <exception cref="TaxDisableException">税收被禁用</exception>"
        void Update(UserUpdateModel user);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="code">用户编码</param>
        /// <exception cref="UserNotFoundException">用户不存在</exception>"
        /// <exception cref="UserCanNotDeleteException">用户不能删除</exception>"
        void Delete(string code);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="code">用户编码</param>
        /// <returns>返回用户信息</returns>
        /// <exception cref="UserNotFoundException">用户不存在</exception>""
        UserModel GetFromCode(string code);
        /// <summary>
        /// 获取用户信息 
        /// </summary>
        /// <param name="name">用户姓名</param>
        /// <returns>用户信息</returns>
        /// <exception cref="UserNotFoundException">用户不存在</exception>""
        UserModel GetFromName(string name);

        /// <summary>
        /// 获取某个职务的所有用户
        /// </summary>
        /// <param name="positionCode">职位编码</param>
        /// <returns></returns>
        List<UserModel> GetFromPosition(string positionCode);

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        List<UserModel> Gets();


    }
}
