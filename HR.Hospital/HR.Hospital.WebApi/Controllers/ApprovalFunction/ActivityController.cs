using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.IRepository.ApprovalFunction;
using HR.Hospital.Model;
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

        /// <summary>
        ///  构造函数注入
        /// </summary>
        /// <param name="activityRepository"></param>
        /// <param name="approvalTypeRepository"></param>
        public ActivityController(IActivityRepository activityRepository, IApprovalTypeRepository approvalTypeRepository)
        {
            //活动主表的构造函数注入
            ActivityRepository = activityRepository;

            //活动类型的构造函数注入
            ApprovalTypeRepository = approvalTypeRepository;
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

        // POST: api/Approval
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Approval/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
