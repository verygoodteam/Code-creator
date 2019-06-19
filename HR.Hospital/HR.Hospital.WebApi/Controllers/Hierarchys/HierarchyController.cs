using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using HR.Hospital.Model;
using HR.Hospital.IRepository.Hierarchys;

namespace HR.Hospital.WebApi.Controllers.Hierarchys
{
    [Route("api/[controller]")]
    [ApiController]
    public class HierarchyController : ControllerBase
    {
        //实例化上下文对象
        public IHierarchyRepository HierarchyRepository { get; set; }

        //构造函数注入
        public HierarchyController(IHierarchyRepository hierarchyRepository)
        {
            HierarchyRepository = hierarchyRepository;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetHierarchy")]
        public List<Hierarchy> GetHierarchy()
        {
            var gethierarchy = HierarchyRepository.GetHierarchie();
            return gethierarchy.ToList();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpDelete("DeleteHierarchy")]
        public int DeleteHierarchy(int id)
        {
            var deletehierarchy = HierarchyRepository.DeleteHierarchy(id);
            return deletehierarchy;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost("AddHierarchy")]
        public int AddHierarchy(Hierarchy hierarchy)
        {
            var addhierarchy = HierarchyRepository.AddHierarchy(hierarchy);
            return addhierarchy;
        }
    }
}