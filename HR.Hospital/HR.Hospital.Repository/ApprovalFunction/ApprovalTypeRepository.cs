using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.IRepository.ApprovalFunction;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.ApprovalFunction
{
    /// <summary>
    /// 实现活动类型查看
    /// </summary>
    public class ApprovalTypeRepository : IApprovalTypeRepository
    {
        //实例化上下文类
        private readonly hospitaldbContext _context = new hospitaldbContext();

        /// <summary>
        /// 类别的查看
        /// </summary>
        /// <returns></returns>
        public List<ApprovalType> GetListApprovalType()
        {
            //返回一个集合
            var listApprovalType = _context.ApprovalType.ToList();
            return listApprovalType;
        }

        /// <summary>
        /// 级别的查看
        /// </summary>
        /// <returns></returns>
        public List<UserLevel> GetListUserLevel()
        {
            var listUserLevel = _context.UserLevel.ToList();
            return listUserLevel;
        }
    }
}
