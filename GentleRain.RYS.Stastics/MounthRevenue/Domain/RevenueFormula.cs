using MonthRevenue.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthRevenue
{
    public static class RevenueFormula
    {
        /// <summary>
        /// 计算业绩
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static decimal Cardinal(RevenueDayEntity entity)
        { 
            return entity.Count * entity.UnitCardinal;
        }

        /// <summary>
        /// 用于计算提成的业绩
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static decimal CardinalWithOutPerformance(RevenueDayEntity entity)
        {
            return entity.UnitPerformance == 0 ? entity.Count * entity.UnitCardinal: 0;
        }

        public static decimal Performance(RevenueDayEntity entity)
        {
            return entity.Count * entity.UnitPerformance;
        }

        /// <summary>
        /// 固定扣减168
        /// </summary>
        /// <returns></returns>
        public static decimal CardinalFixSbu()
        {
            return 168;
        }


    }
}
