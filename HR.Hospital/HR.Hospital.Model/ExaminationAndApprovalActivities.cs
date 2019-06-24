using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Model
{
    public class ExaminationAndApprovalActivities
    {
        public int Id { get; set; }

        /// <summary>
        ///配置表Id
        /// </summary>
        public int ApprovalConfigurationId { get; set; }

        /// <summary>
        /// 活动表Id
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// 级别表Id
        /// </summary>
        public int UserLevelId { get; set; }

        /// <summary>
        /// 下一步Id
        /// </summary>
        public int DownId { get; set; }

        /// <summary>
        /// 审批状态
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

        /// <summary>
        /// 是否开启
        /// </summary>
        public int IsEnable { get; set; }

        /// <summary>
        /// 申请人Id
        /// </summary>
        public int ApplicantId { get; set; }

        /// <summary>
        /// 状态Id
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// 被换班人Id
        /// </summary>
        public int ShiftChangerPeople { get; set; }

    } 
}
