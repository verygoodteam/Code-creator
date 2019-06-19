using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Common;
using HR.Hospital.IRepository.Group;
using HR.Hospital.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.WebApi.Controllers.Group
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly IGroupRepository _groupRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPagedList")]
        public PageHelper<Professionalgroup> GetPagedList(int pageIndex=1, int pageSize=2, string name=null)
        {
            var list = _groupRepository.GetPagedList(pageIndex, pageSize, name);
            return list;
        }

        /// <summary>
        /// 获取科室
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDepartment")]
        public List<Administrative> GetDepartment()
        {
            var list = _groupRepository.GetDepartment();
            return list;
        }

        /// <summary>
        /// 获取人员
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetClinical")]
        public List<Clinicuser> GetClinical()
        {
            var list = _groupRepository.GetClinical();
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        [HttpPost("Add")]
        public int Add([FromBody]Professionalgroup model)
        {
            var i = _groupRepository.Add(model);
            return i;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Delete")]
        public int Delete(int id)
        {
            var i = _groupRepository.Delete(id);
            return i;
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetModel")]
        public Professionalgroup GetModel(int id)
        {
            var model = _groupRepository.GetModel(id);
            return model;
        }
        
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        [HttpPut("Update")]
        public int Update([FromBody]Professionalgroup model)
        {
            var i = _groupRepository.Update(model);
            return i;
        }
    }
}