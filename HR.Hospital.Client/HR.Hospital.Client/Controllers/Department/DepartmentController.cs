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
            var list = HttpClientApi.GetAsync<Common.PageHelper<Administrative>>(HttpHelper.Url + "Department/GetPagedList?pageIndex=" + pageIndex + "&pageSize=" + pageSize + "&isOperation=" + isOperation + "&name=" + name);
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
            var i = HttpClientApi.PostAsync<Administrative, int>(model, HttpHelper.Url + "Department/Add");
            return Redirect("/Department/Index");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var i = HttpClientApi.DeleteAsync<int>(HttpHelper.Url + "Department/Delete?id=" + id);
            return Redirect("/Department/Index");
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Enable(int id)
        {
            var i = HttpClientApi.DeleteAsync<int>(HttpHelper.Url + "Department/Enable?id=" + id);
            return Redirect("/Department/Index");
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <returns></returns>
        public Administrative UpdateData(int id)
        {
            var list = HttpClientApi.GetAsync<Administrative>(HttpHelper.Url + "Department/GetModel?id=" + id);
            return list;
        }

        /// <summary>
        /// 编辑方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateDepartment(Administrative model)
        {
            var i = HttpClientApi.PutAsync<Administrative, int>(model, HttpHelper.Url + "Department/Update");
            return Redirect("/Department/Index");
        }
    }
}