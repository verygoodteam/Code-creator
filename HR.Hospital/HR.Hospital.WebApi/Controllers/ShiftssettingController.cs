using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.IRepository.Shiftssettings;
using HR.Hospital.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.WebApi.Controllers
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
        public List<Shiftssetting> GetList()
        {
            List<Model.Shiftssetting> list = _shiftssettingRepository.GetShiftssettings();
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="shiftssetting"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Add(Model.Shiftssetting shiftssetting)
        {
            bool b = _shiftssettingRepository.AddShiftssetting(shiftssetting);
            return b;
        }


    }
}