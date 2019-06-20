using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using HR.Hospital.Model;
using HR.Hospital.IRepository.Positions;

namespace HR.Hospital.WebApi.Controllers.Positions
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        //实例化上下文对象
        public IPositionRepository PositionRepository { get; set; }

        //构造函数注入
        public PositionController(IPositionRepository positionRepository)
        {
            PositionRepository = positionRepository;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPosition")]
        public List<Position> GetPosition()
        {
            var getposition = PositionRepository.GetPosition();
            return getposition.ToList();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpDelete("DeletePosition")]
        public int DeletePosition(int id)
        {
            var deleteposition = PositionRepository.DeletePosition(id);
            return deleteposition;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost("AddPosition")]
        public int AddPosition(Position position)
        {
            var addposition = PositionRepository.AddPosition(position);
            return addposition;
        }
    }
}