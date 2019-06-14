using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.Shiftssetting
{
    public class ShiftssettingController : Controller
    {
        public IActionResult Show()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}