using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models.Dto;
using Newtonsoft.Json;
using HR.Hospital.Client.Models;

namespace HR.Hospital.Client.Controllers.Roles
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///角色显示
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult RoleShows()
        {
            var pagePermission = HttpClientApi.GetAsync<List<Role>>("http://localhost:12345/api/Role/GetRoles");
            return View(pagePermission);
        }
    }
}