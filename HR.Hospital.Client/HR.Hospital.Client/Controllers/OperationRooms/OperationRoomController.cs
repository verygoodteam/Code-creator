using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.OperationRooms
{
    public class OperationRoomController : Controller
    {
        public IActionResult IndexRoom()
        {
            return View();
        }

        /// <summary>
        /// 添加手术间
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRoom()
        {
            return View();
        }

        /// <summary>
        /// 添加手术室的方法
        /// </summary>
        /// <param name="operationRoom"></param>
        /// <returns></returns>
        public int AddRoomAction(Operationroom operationRoom)
        {
            var result = HttpClientApi.PostAsync<Operationroom, int>(operationRoom, "http://localhost:12345/api/Areas/AddArea");
            return result;
        }
    }
}