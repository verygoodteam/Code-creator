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
        public bool Add(Model.Shiftssetting shiftssetting)
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

        /// <summary>
        /// 获取最大id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetId")]
        public int GetId()
        {
            int i = _shiftssettingRepository.GetId();
            return i;
        }

        /// <summary>
        /// 向上调整排序编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Upsortid")]
        public bool Upsortid(int id)
        {
            bool b = _shiftssettingRepository.UpdateSortid(id);
            return b;
        }

        /// <summary>
        /// 向上调整排序编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DownSortid")]
        public bool DownSortid(int id)
        {
            bool b = _shiftssettingRepository.DownSortid(id);
            return b;
        }
    }
}