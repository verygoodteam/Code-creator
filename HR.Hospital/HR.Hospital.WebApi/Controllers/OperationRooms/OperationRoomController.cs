using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Common;
using HR.Hospital.IRepository.OperationRooms;
using HR.Hospital.Model;
using HR.Hospital.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.WebApi.Controllers.OperationRooms
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationRoomController : ControllerBase
    {

        /// <summary>
        /// 实例化EF上下文对象
        /// </summary>
        public IOperationRoomRepository OperationRoomRepository { get; set; }

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="operationRoomRepository"></param>
        public OperationRoomController(IOperationRoomRepository operationRoomRepository)
        {
            OperationRoomRepository = operationRoomRepository;
        }

        /// <summary>
        /// 显示查询手术间
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="areaProperty">条件查询</param>
        /// <param name="areaName">模糊查询</param>
        /// <returns></returns>
        [HttpGet("GetListOperationRoom")]
        public PageHelper<AreaRoomDto> GetListOperationRoom(int pageIndex, int pageSize, int areaProperty, string areaName)
        {
            var areaList = OperationRoomRepository.GetListOperationRoom(pageIndex, pageSize, areaProperty, areaName);
            return areaList;
        }

        /// <summary>
        /// 获取手术间对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetOperationRoom")]
        public OperationRoom GetOperationRoom(int id)
        {
            var area = OperationRoomRepository.GetOperationRoom(id);
            return area;
        }

        /// <summary>
        /// 添加手术间
        /// </summary>
        /// <param name="operationRoom"></param>
        /// <returns></returns>
        // POST: api/Area
        [HttpPost]
        public int AddOperationRoom([FromBody]OperationRoom operationRoom)
        {
            var result = OperationRoomRepository.AddOperationRoom(operationRoom);
            return result;
        }

        /// <summary>
        /// 获取院区的信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetListArea")]
        public List<AreaDto> GetListArea()
        {
            var listArea = OperationRoomRepository.GetListArea();
            return listArea;
        }

        /// <summary>
        /// 修改手术间信息
        /// </summary>
        /// <param name="operationRoom"></param>
        /// <returns></returns>
        [HttpPut("UpdateOperationRoom")]
        public int UpdateOperationRoom([FromBody] OperationRoom operationRoom)
        {
            var result = OperationRoomRepository.UpdateOperationRoom(operationRoom);
            return result;
        }

        /// <summary>
        /// 启用禁用手术间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("EnableOperationRoom")]
        public int EnableOperationRoom(int id)
        {
            var result = OperationRoomRepository.EnableOperationRoom(id);
            return result;
        }
    }
}
