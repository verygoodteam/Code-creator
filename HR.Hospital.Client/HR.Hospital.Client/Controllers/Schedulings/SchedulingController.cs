using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.Schedulings
{
    public class SchedulingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}