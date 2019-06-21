using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Common;
using HR.Hospital.IRepository.Clinical;
using HR.Hospital.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.WebApi.Controllers.Clinical
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicalController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IClinicalRepository _clinicalRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="clinicalRepository"></param>
        public ClinicalController(IClinicalRepository clinicalRepository)
        {
            _clinicalRepository = clinicalRepository;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPagedList")]
        public PageHelper<Clinicuser> GetPagedList(int pageIndex=1, int pageSize=3, int administrativeId=0, string englishName="")
        {
            var list = _clinicalRepository.GetPagedList(pageIndex, pageSize, administrativeId, englishName);
            return list;
        }

        /// <summary>
        /// 获取科室
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDepartment")]
        public List<Administrative> GetDepartment()
        {
            var list = _clinicalRepository.GetDepartment();
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        [HttpPost("Add")]
        public int Add([FromBody]Clinicuser model)
        {
            var i = _clinicalRepository.Add(model);
            return i;
        }

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Delete")]
        public int Delete(int id)
        {
            var i = _clinicalRepository.Delete(id);
            return i;
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <returns></returns>
        [HttpDelete("Enable")]
        public int Enable(int id)
        {
            var i = _clinicalRepository.Enable(id);
            return i;
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetModel")]
        public Clinicuser GetModel(int id)
        {
            var model = _clinicalRepository.GetModel(id);
            return model;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        [HttpPut("Update")]
        public int Update([FromBody]Clinicuser model)
        {
            var i = _clinicalRepository.Update(model);
            return i;
        }
    }
}