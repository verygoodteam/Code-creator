using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.ApprovalFunction
{
    /// <summary>
    /// 类型的接口
    /// </summary>
    public interface IApprovalTypeRepository
    {
        /// <summary>
        /// 查看类型
        /// </summary>
        /// <returns></returns>
        List<ApprovalType> GetListApprovalType();

        /// <summary>
        /// 查看级别信息
        /// </summary>
        /// <returns></returns>
        List<UserLevel> GetListUserLevel();
    }
}
