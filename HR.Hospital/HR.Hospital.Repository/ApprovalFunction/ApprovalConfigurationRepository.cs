using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.IRepository.ApprovalFunction;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.ApprovalFunction
{
    public class ApprovalConfigurationRepository : IApprovalConfigurationRepository
    {
        private hospitaldbContext _context = new hospitaldbContext();
        /// <summary>
        /// 添加配置表信息
        /// </summary>
        /// <param name="approvalConfiguration"></param>
        /// <returns></returns>
        public int AddApprovalConfiguration(ApprovalConfiguration approvalConfiguration)
        {
            _context.ApprovalConfiguration.Add(approvalConfiguration);
            var result = _context.SaveChanges();
            return result;
        }
        /// <summary>
        /// 显示分页配置表信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="name"></param>
        /// <returns></returns>

        public List<ApprovalConfiguration> GetApprovalConfigurations(int pageIndex, int pageSize, string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改配置表信息
        /// </summary>
        /// <param name="approvalConfiguration"></param>
        /// <returns></returns>
        public int UpdateApprovalConfiguration(ApprovalConfiguration approvalConfiguration)
        {
            throw new NotImplementedException();
        }
    }
}
