﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.OoperationUser
{
    public class OoperationUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}