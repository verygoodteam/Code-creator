using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.IRepository.Shiftssettings;
using HR.Hospital.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.WebApi.Controllers.Shiftssettings
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftssettingController : ControllerBase
    {
        public readonly IShiftssettingRepository _shiftssettingRepository;

        public ShiftssettingController(IShiftssettingRepository shiftssettingRepository)
        {
            _shiftssettingRepository = shiftssettingRepository;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetList")]
        public List<Shiftssetting> GetList(string name)
        {
            List<Model.Shiftssetting> list = _shiftssettingRepository.GetShiftssettings(name);
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="shiftssetting"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public bool Add([FromBody] Model.Shiftssetting shiftssetting)
        {
            bool b = _shiftssettingRepository.AddShiftssetting(shiftssetting);
            return b;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DeleteById")]
        public bool DeleteById(int id)
        {
            bool b = _shiftssettingRepository.DeleteShiftssetting(id);
            return b;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="shiftssetting"></param>
        /// <returns></returns>
        [HttpPost("EditById")]
        public bool EditById([FromBody]Model.Shiftssetting shiftssetting)
        {
            bool b = _shiftssettingRepository.UpdateShiftssetting(shiftssetting);
            return b;
        }
    }
}