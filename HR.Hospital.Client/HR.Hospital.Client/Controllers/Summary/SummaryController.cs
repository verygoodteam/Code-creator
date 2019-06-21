using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.Summary
{
    public class SummaryController : Controller
    {
        /// <summary>
        /// 分页查询
        /// </summary>  
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        public PageHelper<AttendanceSummary> PageList(int pageIndex = 1, int pageSize = 3, string name = "")
        {
            var list = HttpClientApi.GetAsync<PageHelper<AttendanceSummary>>(HttpHelper.Url + "Summary/GetPagedList?pageIndex=" + pageIndex + "&pageSize=" + pageSize  + "&name=" + name);
            return list;
        }
    }
}