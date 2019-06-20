using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.Detail
{
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}