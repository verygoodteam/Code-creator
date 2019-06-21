using HR.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.IRepository.ApprovalFunction
{
    public interface IApprovalConfigurationRepository
    {
        /// <summary>
        /// 添加配置信息
        /// </summary>
        /// <param name="approvalConfiguration"></param>
        /// <returns></returns>
        int AddApprovalConfiguration(ApprovalConfiguration approvalConfiguration);

        /// <summary>
        /// 显示配置信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        List<ApprovalConfiguration> GetApprovalConfigurations(int pageIndex, int pageSize, string name);

        /// <summary>
        /// 修改配置信息
        /// </summary>
        /// <param name="approvalConfiguration"></param>
        /// <returns></returns>
        int UpdateApprovalConfiguration(ApprovalConfiguration approvalConfiguration);
    }
}
