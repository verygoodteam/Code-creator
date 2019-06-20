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
    }
}