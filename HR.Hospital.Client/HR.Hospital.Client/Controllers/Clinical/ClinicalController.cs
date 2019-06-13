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
        public IActionResult Index()
        {
            return View();
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