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
            var roleshow = HttpClientApi.GetAsync<List<Role>>("http://localhost:12345/api/Role/GetRoles");
            return View(roleshow);
        }
      
        /// <summary>
        /// 添加视图
        /// </summary>
        /// <returns></returns>
        public ActionResult AddView()
        {
            return View();
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddRole(Role roles, string ids)
        {
            var addrole = HttpClientApi.PostAsync<Role,int>(roles,"http://localhost:12345/api/Role/AddRoles?ids="+ids);
            return addrole;
        }

        /// <summary>
        /// 修改视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateView(int id)
        {
            ViewBag.id = id;
            return View();
        }

        /// <summary>
        /// 返填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Roill(int id)
        {
            var roill = HttpClientApi.GetAsync<Role>("http://localhost:12345/api/Role/RoilRoles?id="+id);
            return Json(roill, new JsonSerializerSettings());
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost]
        public int Updaterole(Role roles, string ids)
        {
            var updaterole = HttpClientApi.PostAsync<Role, int>(roles, "http://localhost:12345/api/Role/UpdateRoles?ids=" + ids);
            return updaterole;
        }

        /// <summary>
        /// 编辑状态
        /// </summary>
        /// <returns></returns>
        public int IsanbleUpdate(Permission permission)
        {
            var isanbleupdate = HttpClientApi.PostAsync<Permission, int>(permission, "http://localhost:12345/api/Role/UpdateIsable");
            return isanbleupdate;
        }

        /// <summary>
        /// 查询角色权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetRolePer(int id)
        {
            var getroleper = HttpClientApi.GetAsync<List<RolePermission>>("http://localhost:12345/api/Role/GetRolePer?id=" + id);
            return Json(getroleper, new JsonSerializerSettings());
        }

    }
}