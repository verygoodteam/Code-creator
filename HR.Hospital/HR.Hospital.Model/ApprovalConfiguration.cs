using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Model
{
    public class ApprovalConfiguration
    {
        public int Id { get; set; }

        /// <summary>
        /// 活动Id
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// 级别Id
        /// </summary>
        public int UserLevelId { get; set; }

        /// <summary>
        /// 下一步Id
        /// </summary>
        public int DownId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// 排序Id
        /// </summary>
        public int SortId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 审批人Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }

        public int IsEnable { get; set; }

    }
}
