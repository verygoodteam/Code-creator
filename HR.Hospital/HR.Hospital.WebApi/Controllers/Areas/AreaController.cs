using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Common;
using HR.Hospital.IRepository.Areas;
using HR.Hospital.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.WebApi.Controllers.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        public IAreaRepository AreaRepository { get; set; }

        //构造函数注入
        public AreaController(IAreaRepository areaRepository)
        {
            AreaRepository = areaRepository;
        }


        /// <summary>
        /// 显示查询
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="areaProperty">条件查询</param>
        /// <param name="areaName">模糊查询</param>
        /// <returns></returns>
        [HttpGet("GetAreaList")]
        public PageHelper<Area> GetAreaList(int pageIndex, int pageSize, int areaProperty, string areaName)
        {
            var areaList = AreaRepository.ShowArea(pageIndex, pageSize, areaProperty, areaName);
            return areaList;
        }

        /// <summary>
        /// 获取单个Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetArea")]
        public Area GetArea(int id)
        {
            var area = AreaRepository.GetArea(id);
            return area;
        }

        /// <summary>
        /// 添加院区
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        // POST: api/Area
        [HttpPost]
        public int AddArea([FromBody]Area area)
        {
            var result = AreaRepository.AddArea(area);
            return result;
        }

        /// <summary>
        /// 修改院区信息
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        [HttpPut("UpdateArea")]
        public int UpdateArea([FromBody] Area area)
        {
            var result = AreaRepository.UpdateArea(area);
            return result;
        }

        /// <summary>
        /// 启用禁用院区
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("EnableArea")]
        public int EnableArea(int id)
        {
            var result = AreaRepository.EnableArea(id);
            return result;
        }
    }
}
