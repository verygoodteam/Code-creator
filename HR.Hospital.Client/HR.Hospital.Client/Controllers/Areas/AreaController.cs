using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace HR.Hospital.Client.Controllers.Areas
{
    public class AreaController : Controller
    {
        /// <summary>
        /// 主页
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexArea()
        {
            return View();
        }

        /// <summary>
        /// 显示的方法
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="areaProperty"></param>
        /// <param name="areaName"></param>
        /// <returns></returns>
        public ActionResult ListArea(int pageIndex = 1, int pageSize = 2, int areaProperty = 0, string areaName = "")
        {
            var pageArea = HttpClientApi.GetAsync<PageHelper<Area>>("http://localhost:49733/api/Areas/GetAreaList?pageIndex=" + pageIndex + "&pageSize=" + pageSize + "&areaProperty=" + areaProperty + "&areaName=" + areaName);
            return Json(pageArea, new JsonSerializerSettings());
        }

        /// <summary>
        /// 添加的页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddArea()
        {
            return View();
        }

        /// <summary>
        /// 添加执行的方法
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddAreaAction(Area area)
        {
            var result = HttpClientApi.PostAsync<Area, int>(area, "http://localhost:49733/api/Areas/AddArea");
            return result;
        }

        /// <summary>
        /// 修改的页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateArea(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// 修改页面的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult AreaJson(int id)
        {
            var result = HttpClientApi.GetAsync<Area>("http://localhost:49733/api/Areas/GetArea?id=" + id);
            return Json(result);
        }



        // POST: Area/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction();
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// 删除方法  (启用禁用)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EnableArea(int id)
        {
            HttpClientApi.DeleteAsync<int>("http://localhost:49733/api/Areas/EnableArea?id=" + id);
            return Redirect("/Area/IndexArea");
        }


    }
}