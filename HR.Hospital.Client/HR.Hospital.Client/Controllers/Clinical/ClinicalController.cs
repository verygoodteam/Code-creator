using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HR.Hospital.Client.Controllers.Clinical
{
    public class ClinicalController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PageList(int pageIndex = 1, int pageSize = 3, int administrativeId = 0, string englishName = null)
            {
            var list = HttpClientApi.GetAsync<PageHelper<Clinicuser>>("http://localhost:54463/api/Clinical/GetPagedList?pageIndex=" + pageIndex + "&pageSize=" + pageSize + "&Aadministrativeid=" + administrativeId + "&ClinicUserRemark=" + englishName);
            return Json(list, new JsonSerializerSettings());
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Clinicuser model)
        {
            var i = HttpClientApi.PostAsync<Clinicuser,int>(model, "http://localhost:54463/api/Clinical/add");
            return Redirect("/Clinical/Index");
        }

        public IActionResult Delete(int id)
        {
            var i = HttpClientApi.DeleteAsync<int>("http://localhost:54463/api/Clinical/delete?id="+id);
            return Redirect("/Clinical/Index");
        }
    }
}