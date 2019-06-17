using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;

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

        /// <summary>
        /// 手术用户添加方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int OopUserAdds(Ooperationuser ooperationuser)
        {
            var result = HttpClientApi.PostAsync<Ooperationuser, int>(ooperationuser, "http://localhost:12345/api/Ooperationuser/InsertOoperationuser");
            return result;
        }

        /// <summary>
        /// 手术用户编辑视图
        /// </summary>
        /// <returns></returns>
        public IActionResult OopUserUpdate(int id)
        {
            ViewBag.id = id;
            return View();
        }

        /// <summary>
        /// 手术用户编辑方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int OopUserUpdates(Ooperationuser ooperationuser)
        {
            var result = HttpClientApi.PostAsync<Ooperationuser, int>(ooperationuser, "http://localhost:12345/api/Ooperationuser/UpdateOoperationUser");
            return result;
        }

    }
}