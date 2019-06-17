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
        /// <summary>
        /// 主页面显示
        /// </summary>
        /// <returns></returns>
        public IActionResult IndexRoom()
        {
            var areaList = HttpClientApi.GetAsync<List<AreaDto>>("http://localhost:12345/api/OperationRoom/GetListArea");
            ViewBag.AreaList = areaList;
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

        /// <summary>
        /// 获取所有信息
        /// </summary>
        /// <returns></returns>
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
            var result = HttpClientApi.DeleteAsync<int>("http://localhost:12345/api/OperationRoom/EnableOperationRoom?id=" + id);
            return Redirect("/OperationRoom/IndexRoom");
        }

        /// <summary>
        /// 修改主视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateOperationRoom(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// 修改视图数据方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult OperationRoomAction(int id)
        {
            var operationRoom = HttpClientApi.GetAsync<Operationroom>("http://localhost:12345/api/OperationRoom/GetOperationRoom?id=" + id);
            return Json(operationRoom, new JsonSerializerSettings());
        }

        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="operationroom"></param>
        /// <returns></returns>
        public int UpdateRoomAction(Operationroom operationroom)
        {
            var operationRoom = HttpClientApi.PutAsync<Operationroom, int>(operationroom, "http://localhost:12345/api/OperationRoom/UpdateOperationRoom");
            return operationRoom;
        }

    }
}