﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Hospital.Client.Models;
using HR.Hospital.Client.Filter;
using HR.Hospital.Cache.Redis;

namespace HR.Hospital.Client.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [MyActionFilter]
        public IActionResult MainIndex()
        {
            var tmpUser = RedisHelper.Get<Ooperationuser>(_id.ToString());
            if (_id == 0)
            {
                return RedirectToAction(nameof(LoginController.Login), "Login");
            }
            ViewBag.name = tmpUser.OoperationUserName;
            ViewBag.list = RedisHelper.Get<Ooperationuser>(_id.ToString()).PermissionList;
            return View();
        }

        /// <summary>
        /// 获取登录人的权限
        /// </summary>
        /// <returns></returns>
        public IActionResult GetMenus()
        {
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
