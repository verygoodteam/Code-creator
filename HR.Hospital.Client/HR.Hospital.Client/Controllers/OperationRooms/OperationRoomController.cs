using System.Collections.Generic;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using HR.Hospital.Client.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HR.Hospital.Client.Controllers.OperationRooms
{
    public class OperationRoomController : Controller
    {
        public IActionResult IndexRoom()
        {

            return View();
        }

        /// <summary>
        /// 显示方法
        /// </summary>
        /// <returns></returns>
        public IActionResult IndexRoomAction()
        {
            var result = HttpClientApi.GetAsync<List<AreaRoomDto>>("http://localhost:12345/api/OperationRoom/GetListArea");
            return Json(result, new JsonSerializerSettings());
        }

        /// <summary>
        /// 添加手术间
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRoom()
        {
            return View();
        }

        public JsonResult GetListArea()
        {
            var result = HttpClientApi.GetAsync<List<AreaDto>>("http://localhost:12345/api/OperationRoom/GetListArea");
            return Json(result, new JsonSerializerSettings());
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