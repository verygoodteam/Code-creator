﻿using System;
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
        // GET: Area
        public ActionResult IndexArea()
        {
            return View();
        }

        public ActionResult ListArea(int pageIndex = 1, int pageSize = 2, int areaProperty = 0, string areaName = "")
        {
            var pageArea = HttpClientApi.GetAsync<PageHelper<Area>>("http://localhost:49733/api/Areas/GetAreaList?pageIndex=" + pageIndex + "&pageSize=" + pageSize + "&areaProperty=" + areaProperty + "&areaName=" + areaName);
            return Json(pageArea, new JsonSerializerSettings());
        }
        // GET: Area/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Area/Create
        public ActionResult AddArea()
        {
            return View();
        }
        [HttpPost]
        public int AddAreaAction(Area area)
        {
            var result = HttpClientApi.PostAsync<Area, int>(area, "http://localhost:49733/api/Areas/AddArea");
            return result;
        }
        // POST: Area/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction();
            }
            catch
            {
                return View();
            }
        }

        // GET: Area/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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

        // GET: Area/Delete/5
        public ActionResult EnableArea(int id)
        {
            HttpClientApi.DeleteAsync<int>("http://localhost:49733/api/Areas/EnableArea?id=" + id);
            return Redirect("/Area/IndexArea");
        }

        // POST: Area/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction();
            }
            catch
            {
                return View();
            }
        }
    }
}