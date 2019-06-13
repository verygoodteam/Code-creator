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
        /// 显示
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetList")]
        public List<Clinicuser> GetList(int administrativeId=0, string englishName="")
        {
            var list = _clinicalRepository.GetList(administrativeId, englishName);
            return list;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPagedList")]
        public PageDto<Clinicuser> GetPagedList(int pageIndex, int pageSize, int administrativeId, string englishName)
        {
            var list = _clinicalRepository.GetPagedList(pageIndex,pageSize,administrativeId, englishName);
            return list;
        }
        
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public int Add([FromBody]Clinicuser model)
        {
            var i = _clinicalRepository.Add(model);
            return i;
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            var i = _clinicalRepository.Delete(id);
            return i;
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{Get}")]
        public Clinicuser Get(int id)
        {
            var model = _clinicalRepository.GetModel(id);
            return model;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        [HttpPut]
        public int Update([FromBody]Clinicuser model)
        {
            var i = _clinicalRepository.Update(model);
            return i;
        }
    }
}