using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        /// 显示
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetList")]
        public List<Professionalgroup> GetList()
        {
            var list = _groupRepository.GetPageList();
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
        /// 获取单个
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