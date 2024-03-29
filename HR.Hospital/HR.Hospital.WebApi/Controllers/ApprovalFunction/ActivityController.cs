﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.IRepository.ApprovalFunction;
using HR.Hospital.Model;
using HR.Hospital.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.WebApi.Controllers.ApprovalFunction
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        public IActivityRepository ActivityRepository { get; set; }

        public IApprovalTypeRepository ApprovalTypeRepository { get; set; }

        public IApprovalConfigurationRepository ApprovalConfigurationRepository { get; set; }

        /// <summary>
        ///  构造函数注入
        /// </summary>
        /// <param name="activityRepository"></param>
        /// <param name="approvalTypeRepository"></param>
        /// <param name="approvalConfigurationRepository"></param>
        public ActivityController(IActivityRepository activityRepository, IApprovalTypeRepository approvalTypeRepository, IApprovalConfigurationRepository approvalConfigurationRepository)
        {
            //活动主表的构造函数注入
            ActivityRepository = activityRepository;

            //活动类型的构造函数注入
            ApprovalTypeRepository = approvalTypeRepository;

            //活动配置表的构造函数注入
            ApprovalConfigurationRepository = approvalConfigurationRepository;
        }

        // GET: api/Approval
        [HttpGet("GetListApproval")]
        public IEnumerable<ActivityTable> GetListApproval()
        {
            return ActivityRepository.GetListActivity();
        }

        /// <summary>
        /// 活动类别的查看
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetApprovalType")]
        public List<ApprovalType> GetApprovalType()
        {
            return ApprovalTypeRepository.GetListApprovalType();
        }

        /// <summary>
        /// 活动级别的查看
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListUserLevel")]
        public List<UserLevel> GetListUserLevel()
        {
            return ApprovalTypeRepository.GetListUserLevel();
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListRole")]
        public List<Role> GetListRole()
        {
            return ApprovalTypeRepository.GetListRole();
        }

        /// <summary>
        /// 获取二级联动角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet("GetListOperaTinUser")]
        public List<Model.Ooperationuser> GetListOperaTinUser(int roleId)
        {
            return ApprovalTypeRepository.GetListUser(roleId);
        }

        /// <summary>
        /// 配置表的信息
        /// </summary>
        /// <param name="approvalConfiguration"></param>
        /// <returns></returns>
        [HttpPost("AddApprovalConfiguration")]
        public int AddApprovalConfiguration([FromBody] List<ApprovalConfiguration> approvalConfiguration)
        {
            var result = ApprovalConfigurationRepository.AddApprovalConfiguration(approvalConfiguration);
            return result;
        }

        /// <summary>
        /// 获取配置表中的活动Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetActivityId")]
        public List<ApprovalConfiguration> GetActivityId()
        {
            var activityListId = ApprovalConfigurationRepository.GetActivityId();
            return activityListId;
        }

        /// <summary>
        /// 获取配置表中的活动Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetApprovalConfigurations")]
        public List<ApprovalConfigurationDto> GetApprovalConfigurations()
        {
            var getApprovalConfigurations = ApprovalConfigurationRepository.GetApprovalConfigurations();
            return getApprovalConfigurations;
        }

        /// <summary>
        /// 禁用配置信息(删除配置信息)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("EnableApprovalConfiguration")]
        public int EnableApprovalConfiguration(int id)
        {
            var result = ApprovalConfigurationRepository.EnableApprovalConfiguration(id);
            return result;
        }
    }
}
