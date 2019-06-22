using HR.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model.Dto;

namespace HR.Hospital.IRepository.ApprovalFunction
{
    public interface IApprovalConfigurationRepository
    {
        /// <summary>
        /// 添加配置信息
        /// </summary>
        /// <param name="approvalConfiguration"></param>
        /// <returns></returns>
        int AddApprovalConfiguration(List<ApprovalConfiguration> approvalConfiguration);

        /// <summary>
        /// 显示配置信息
        /// </summary>
        /// <returns></returns>
        List<ApprovalConfigurationDto> GetApprovalConfigurations();

        /// <summary>
        /// 修改配置信息
        /// </summary>
        /// <param name="approvalConfiguration"></param>
        /// <returns></returns>
        int UpdateApprovalConfiguration(ApprovalConfiguration approvalConfiguration);

        /// <summary>
        /// 获取活动的Id
        /// </summary>
        /// <returns></returns>
        List<int> GetActivityId();
    }
}
