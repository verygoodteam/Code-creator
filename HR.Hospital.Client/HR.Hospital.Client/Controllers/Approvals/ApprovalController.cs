using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.Approvals
{
    public class ApprovalController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Activity = HttpClientApi.GetAsync<List<ActivityTable>>(HttpHelper.Url + "Activity/GetListApproval");
            return View();
        }
    }
}