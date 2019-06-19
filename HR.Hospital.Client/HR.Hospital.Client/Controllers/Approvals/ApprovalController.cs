using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HR.Hospital.Client.Controllers.Approvals
{
    public class ApprovalController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Activity = HttpClientApi.GetAsync<List<ActivityTable>>(HttpHelper.Url + "Activity/GetListApproval");
            return View();
        }
        public IActionResult Add(int id)
        {
            var listActivity = HttpClientApi.GetAsync<List<ActivityTable>>(HttpHelper.Url + "Activity/GetListApproval");
            var activity = listActivity.FirstOrDefault(p => p.Id == id);
            if (activity != null) ViewBag.Title = activity.ActivityName;
            ViewBag.RadioType = HttpClientApi.GetAsync<List<ApprovalType>>(HttpHelper.Url + "Activity/GetApprovalType");
            return View();
        }

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetListRole()
        {
            var listRole = HttpClientApi.GetAsync<List<Role>>(HttpHelper.Url + "Activity/GetListRole");
            return Json(listRole, new JsonSerializerSettings());
        }

        /// <summary>
        /// 获取级别
        /// </summary>
        /// <returns></returns>
        public JsonResult GetListUserLevel()
        {
            var listUserLevel = HttpClientApi.GetAsync<List<UserLevel>>(HttpHelper.Url + "Activity/GetListUserLevel").Where(p => p.Id != 1);
            return Json(listUserLevel, new JsonSerializerSettings());
        }

        /// <summary>
        /// 指定人员
        /// </summary>
        /// <returns></returns>
        public IActionResult AddUser()
        {

            return View();
        }



    }
}