using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models.Dto;
using Newtonsoft.Json;
using HR.Hospital.Client.Models;
namespace HR.Hospital.Client.Controllers.Permissions
{
    public class PermissionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 权限显示
        /// </summary>
        /// <returns></returns>
        public ActionResult PermissionShow()
        {
            return View();                                                 
        }

        /// <summary>
        ///权限显示方法 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult PermissionShows(int pageIndex = 1, int pageSize = 3)
        {
            var pagePermission = HttpClientApi.GetAsync<Common.PageHelper<PermissionDto>>("http://localhost:12345/api/Permission/GetPermmission?pageIndex=" + pageIndex + "&pageSize=" + pageSize);
            return Json(pagePermission, new JsonSerializerSettings());
        }

        /// <summary>
        /// 权限添加
        /// </summary>
        /// <returns></returns>
        public IActionResult PermissionAdd()
        {
            return View();
        }

        /// <summary>
        ///权限添加方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int PermissionAdds(Permission permission)
        {
            var result = HttpClientApi.PostAsync<Permission, int>(permission, "http://localhost:12345/api/Permission/AddPermmission");
            return result;
        }

        /// <summary>
        /// 权限编辑视图
        /// </summary>
        /// <returns></returns>
        public IActionResult PermissionUpdate(int id)
        {
            ViewBag.id = id;
            return View();
        }

        /// <summary>
        /// 权限编辑方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int PermissionUpdates(Permission permission)
        {
            var result = HttpClientApi.PostAsync<Permission, int>(permission, "http://localhost:12345/api/Permission/UpdatePermmission");
            return result;
        }

        /// <summary>
        /// 权限编辑状态
        /// </summary>
        /// <returns></returns>
        public int IsanbleUpdate(Permission permission)
        {
            var result = HttpClientApi.PostAsync<Permission, int>(permission, "http://localhost:12345/api/Permission/UpdateIsable");
            return result;
        }
    }
}