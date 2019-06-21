using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Common;
using HR.Hospital.IRepository.Solitaire;
using HR.Hospital.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.WebApi.Controllers.Solitaire
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolitaireController : ControllerBase
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private readonly ISolitaireRepository _solitaireRepository;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="solitaireRepository"></param>
        public SolitaireController(ISolitaireRepository solitaireRepository)
        {
            _solitaireRepository = solitaireRepository;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPagedList")]
        public PageHelper<SolitaireSet> GetPagedList(int pageIndex = 1, int pageSize = 3, string shift = null)
        {
            var list = _solitaireRepository.GetPagedList(pageIndex, pageSize, shift);
            return list;
        }

        /// <summary>
        /// 获取班次
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetShift")]
        public List<Shiftssetting> GetShift()
        {
            var list = _solitaireRepository.GetShift();
            return list;
        }

        /// <summary>
        /// 获取人员
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPerson")]
        public PageHelper<Clinicuser> GetPerson(int pageIndex = 1, int pageSize = 3, string name = null)
        {
            var list = _solitaireRepository.GetPerson(pageIndex, pageSize, name);
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        [HttpPost("Add")]
        public int Add([FromBody]SolitaireSet model)
        {
            var i = _solitaireRepository.Add(model);
            return i;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Delete")]
        public int Delete(int id)
        {
            var i = _solitaireRepository.Delete(id);
            return i;
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetModel")]
        public SolitaireSet GetModel(int id)
        {
            var model = _solitaireRepository.GetModel(id);
            return model;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        [HttpPut("Update")]
        public int Update([FromBody]SolitaireSet model)
        {
            var i = _solitaireRepository.Update(model);
            return i;
        }

        /// <summary>
        /// 获取最大id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMaxId")]
        public int GetMaxId()
        {
            int i = _solitaireRepository.GetMaxId();
            return i;
        }

        /// <summary>
        /// 向上调整排序编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("UpdateSortId")]
        public bool UpdateSortId(int id)
        {
            bool b = _solitaireRepository.UpdateSortId(id);
            return b;
        }

        /// <summary>
        /// 向上调整排序编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DownSortId")]
        public bool DownSortId(int id)
        {
            bool b = _solitaireRepository.DownSortId(id);
            return b;
        }

    }
}