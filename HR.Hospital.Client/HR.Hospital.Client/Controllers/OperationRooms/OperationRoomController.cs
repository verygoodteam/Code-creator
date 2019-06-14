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
        public JsonResult IndexRoomAction(int pageIndex = 1, int pageSize = 2, int areaId = 3, string operationName = "")
        {
            var result = HttpClientApi.GetAsync<PageHelper<AreaRoomDto>>("http://localhost:12345/api/OperationRoom/GetListOperationRoom?pageIndex=" + pageIndex + "&pageSize=" + pageSize + "&areaId=" + areaId + "&operationName=" + operationName);
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
            var result = HttpClientApi.PostAsync<Operationroom, int>(operationRoom, "http://localhost:12345/api/OperationRoom/AddOperationRoom");
            return result;
        }

        /// <summary>
        /// 删除手术间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EnableOperationRoom(int id)
        {
            var result = HttpClientApi.DeleteAsync<int>("http://localhost:12345/api/OperationRoom/EnableOperationRoom?id="+id);
            return Redirect("/OperationRoom/IndexRoom");
        }





    }
}