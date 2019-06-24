using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.ShiftDutys
{
    public class ShiftDutyController : Controller
    {
        public IActionResult AddShiftDuty()
        {
            return View();
        }
    }
}