using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.Solitaire
{
    public class SolitaireController : Controller
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        public PageHelper<SolitaireSet> PageList(int pageIndex = 1, int pageSize = 3, string shift = "")
        {
            var list = HttpClientApi.GetAsync<PageHelper<SolitaireSet>>(HttpHelper.Url + "Solitaire/GetPagedList?pageIndex=" + pageIndex + "&pageSize=" + pageSize + "&shift=" + shift);
            return list;
        }
    }
}