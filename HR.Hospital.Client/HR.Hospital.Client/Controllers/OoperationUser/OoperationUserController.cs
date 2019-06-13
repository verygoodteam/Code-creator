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

        
        /// <summary>
        ///显示手术室用户 
        /// </summary>
        /// <returns></returns>
        public IActionResult OopUserShow()
        {
            return View();
        }
        
        /// <summary>
        /// 手术用户添加
        /// </summary>
        /// <returns></returns>
        public IActionResult OopUserAdd()
        {
            return View();
        }
    }
}