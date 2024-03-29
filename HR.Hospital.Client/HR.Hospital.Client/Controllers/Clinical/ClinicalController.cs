﻿using System;
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
            var list = HttpClientApi.GetAsync<Common.PageHelper<Clinicuser>>(HttpHelper.Url + "Clinical/GetPagedList?pageIndex=" + pageIndex + "&pageSize=" + pageSize + "&administrativeId=" + administrativeId + "&englishName=" + englishName);
            return list;
        }

        /// <summary>
        /// 获取科室
        /// </summary>
        /// <returns></returns>
        public List<Administrative> GetDepartment()
        {
            var list = HttpClientApi.GetAsync<List<Administrative>>(HttpHelper.Url + "Clinical/GetDepartment");
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
            var i = HttpClientApi.PostAsync<Clinicuser,int>(model, HttpHelper.Url + "Clinical/Add");
            return Redirect("/Clinical/Index");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var i = HttpClientApi.DeleteAsync<int>(HttpHelper.Url + "Clinical/Delete?id=" + id);
            return Redirect("/Clinical/Index");
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Enable(int id)
        {
            var i = HttpClientApi.DeleteAsync<int>(HttpHelper.Url + "Clinical/Enable?id=" + id);
            return Redirect("/Clinical/Index");
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            ViewBag.Id=id;
            return View();
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <returns></returns>
        public Clinicuser UpdateData(int id)
        {
            var list = HttpClientApi.GetAsync<Clinicuser>(HttpHelper.Url + "Clinical/GetModel?id=" + id);
            return list;
        }

        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateClinical(Clinicuser model)
        {
            var i = HttpClientApi.PutAsync<Clinicuser,int>(model, HttpHelper.Url + "Clinical/Update");
            return Redirect("/Clinical/Index");
        }
    }
}