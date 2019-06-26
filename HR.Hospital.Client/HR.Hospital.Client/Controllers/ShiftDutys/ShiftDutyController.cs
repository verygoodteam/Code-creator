using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Cache.Redis;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.ShiftDutys
{
    public class ShiftDutyController : BaseController
    {
        public IActionResult AddShiftDuty()
        {

            var str = RedisHelper.Get<Ooperationuser>(_id.ToString());
            return View();
        }
    }
}