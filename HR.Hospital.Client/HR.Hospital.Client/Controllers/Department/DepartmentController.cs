using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.Department
{
    public class DepartmentController : Controller
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public PageHelper<Administrative> PageList(int pageIndex = 1, int pageSize = 3, int isOperation = 0, string name = "")
        {
            var list = HttpClientApi.GetAsync<PageHelper<Administrative>>("http://localhost:12345/api/Department/getPagedList?pageIndex=" + pageIndex + "&pageSize=" + pageSize + "&Isoperation=" + isOperation + "&AdministrativeName=" + name);
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Administrative model)
        {
            var i = HttpClientApi.PostAsync<Administrative, int>(model, "http://localhost:12345/api/Department/add");
            return Redirect("/Department/Index");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var i = HttpClientApi.DeleteAsync<int>("http://localhost:12345/api/Department/delete?id=" + id);
            return Redirect("/Department/Index");
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Enable(int id)
        {
            var i = HttpClientApi.DeleteAsync<int>("http://localhost:12345/api/Department/enable?id=" + id);
            return Redirect("/Department/Index");
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            var list = HttpClientApi.GetAsync<Administrative>("http://localhost:12345/api/Department/GetModel?id=" + id);
            return View(list);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Administrative model)
        {
            var i = HttpClientApi.PutAsync<Administrative, int>(model, "http://localhost:12345/api/Department/update");
            return Redirect("/Department/Index");
        }
    }
}