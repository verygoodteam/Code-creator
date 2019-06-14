using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.Clinical
{
    public class ClinicalController : Controller
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public PageHelper<Clinicuser> PageList(int pageIndex = 1, int pageSize = 3, int administrativeId = 0, string englishName = "")
        {
            var list = HttpClientApi.GetAsync<PageHelper<Clinicuser>>("http://localhost:12345/api/clinical/getPagedList?pageIndex=" + pageIndex + "&pageSize=" + pageSize + "&Aadministrativeid=" + administrativeId + "&ClinicUserRemark=" + englishName);
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
        public ActionResult Add(Clinicuser model)
        {
            var i = HttpClientApi.PostAsync<Clinicuser,int>(model, "http://localhost:12345/api/clinical/add");
            return Redirect("/Clinical/Index");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var i = HttpClientApi.DeleteAsync<int>("http://localhost:12345/api/clinical/delete?id=" + id);
            return Redirect("/Clinical/Index");
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Enable(int id)
        {
            return View();
            var i = HttpClientApi.DeleteAsync<int>("http://localhost:12345/api/clinical/enable?id=" + id);
            return Redirect("/Clinical/Index");
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            var list = HttpClientApi.GetAsync<Clinicuser>("http://localhost:12345/api/clinical/GetModel?id=" + id);
            return View(list);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Clinicuser model)
        {
            var i = HttpClientApi.PutAsync<Clinicuser,int>(model, "http://localhost:12345/api/clinical/update");
            return Redirect("/Clinical/Index");
        }
    }
}