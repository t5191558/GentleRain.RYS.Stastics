using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentleRain.RYS.Lib
{
    public interface IProject
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        ProjectModel Create(ProjectCreateModel project);
        void Update(ProjectUpdateModel project);
        void Delete(string code);
        ProjectModel Get(string code);
        List<ProjectModel> Gets();
    }
}
