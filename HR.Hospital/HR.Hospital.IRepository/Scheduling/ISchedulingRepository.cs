using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.IRepository.Scheduling
{
    public interface ISchedulingRepository
    {
        /// <summary>
        /// 获取排班列表
        /// </summary>
        /// <returns></returns>
        List<Model.Scheduling> GetSchedulings();

        /// <summary>
        /// 排班
        /// </summary>
        /// <param name="scheduling"></param>
        /// <returns></returns>
        bool Add(Model.Scheduling scheduling);


    }
}
