﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HR.Hospital.Client.Models.Dto
{
    public class ApprovalConfigurationDto
    {
        public int Id { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        [Display(Name = "活动名称")]
        public string ActivityName { get; set; }

        /// <summary>
        /// 审批人
        /// </summary>
        [Display(Name = "审批人")]
        public string OoperationUserName { get; set; }

        /// <summary>
        /// 审批人角色
        /// </summary>
        [Display(Name = "审批人角色")]
        public string RoleName { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>
        [Display(Name = "审批状态")]
        public string Start { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 下一步Id
        /// </summary>
        [Display(Name = "下步Id")]
        public int DownId { get; set; }
    }
}
