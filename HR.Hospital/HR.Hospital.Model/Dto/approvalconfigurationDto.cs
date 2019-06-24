using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Model.Dto
{
    public class ApprovalConfigurationDto
    {
        public int Id { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string ActivityName { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        public string OoperationUserName { get; set; }

        /// <summary>
        /// 审批人角色
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 下一步Id
        /// </summary>
        public int DownId { get; set; }
    }
}
