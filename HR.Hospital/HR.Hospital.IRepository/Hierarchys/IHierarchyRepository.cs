using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.IRepository.Hierarchys;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.Hierarchys
{
   public interface IHierarchyRepository
    {
        /// <summary>
        /// 能级添加
        /// </summary>
        /// <param name="hierarchy"></param>
        /// <returns></returns>
        int AddHierarchy(Hierarchy hierarchy);

        /// <summary>
        /// 能级显示
        /// </summary>
        /// <returns></returns>
        List<Hierarchy> GetHierarchie();

        /// <summary>
        /// 删除能级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteHierarchy(int id);
    }
}
