using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Common;
using HR.Hospital.IRepository.Summary;
using HR.Hospital.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.WebApi.Controllers.Summary
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly ISummaryRepository _summaryRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="summaryRepository"></param>
        public SummaryController(ISummaryRepository summaryRepository)
        {
            _summaryRepository = summaryRepository;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPagedList")]
        public PageHelper<AttendanceSummary> GetPagedList(int pageIndex = 1, int pageSize = 3, string name = null)
        {
            var list = _summaryRepository.GetPagedList(pageIndex, pageSize, name);
            return list;
        }
    }
}