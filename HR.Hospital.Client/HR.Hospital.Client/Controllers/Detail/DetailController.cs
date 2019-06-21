using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.Detail
{
    public class DetailController : Controller
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        public PageHelper<AttendanceDetail> PageList(int pageIndex = 1, int pageSize = 3, string time = "", string name = "")
        {
            var list = HttpClientApi.GetAsync<PageHelper<AttendanceDetail>>(HttpHelper.Url + "Detail/GetPagedList?pageIndex=" + pageIndex + "&pageSize=" + pageSize + "&time=" + time + "&name=" + name);
            return list;
        }
    }
}