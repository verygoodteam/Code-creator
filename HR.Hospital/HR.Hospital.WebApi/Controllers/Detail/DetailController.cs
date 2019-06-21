using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Common;
using HR.Hospital.IRepository.Detail;
using HR.Hospital.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.WebApi.Controllers.Detail
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IDetailRepository _detailRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="detailRepository"></param>
        public DetailController(IDetailRepository detailRepository)
        {
            _detailRepository = detailRepository;
        }
        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPagedList")]
        public PageHelper<AttendanceDetail> GetPagedList(int pageIndex = 1, int pageSize = 3,string time=null, string name = null)
        {
            var list = _detailRepository.GetPagedList(pageIndex, pageSize, time, name);
            return list;
        }
    }
}