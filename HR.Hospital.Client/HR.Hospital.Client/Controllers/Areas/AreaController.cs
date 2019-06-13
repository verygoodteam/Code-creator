using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.Areas
{
    public class AreaController : Controller
    {
        // GET: Area
        public ActionResult IndexArea()
        {
            return View();
        }

        public JsonResult ListArea(int pageIndex = 1, int pageSize = 2, int areaProperty = 0, string name = "")
        {
            return null;
        }
        // GET: Area/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Area/Create
        public ActionResult Create()
        {
            return View();
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
        public ActionResult Delete(int id)
        {
            return View();
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