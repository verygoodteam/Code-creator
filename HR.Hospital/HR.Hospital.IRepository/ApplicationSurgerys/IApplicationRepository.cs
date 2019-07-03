using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model.Dto;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.ApplicationSurgerys
{
   public interface IApplicationRepository
    {
        /// <summary>
        /// 手术申请显示
        /// </summary>
        /// <returns></returns>
        List<ApplicationSurgeryDto> ApplicationList(int pageIndex = 1, int pageSize = 3);

        /// <summary>
        /// 手术申请添加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int AddApplication(ApplicationSurgery applicationsurgery);

        /// <summary>
        /// 手术申请修改
        /// </summary>
        /// <param name="applicationsurgery"></param>
        /// <returns></returns>
        int UpdateApplication(ApplicationSurgery applicationsurgery);
    }
}
