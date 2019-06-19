using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;

namespace HR.Hospital.Client.Controllers.Positions
{
    public class PositionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 显示视图
        /// </summary>
        /// <returns></returns>
        public IActionResult PositionView()
        {
            var getposition = HttpClientApi.GetAsync<List<Position>>("http://localhost:12345/api/Position/GetPosition");
            return View(getposition);
        }

        /// <summary>
        /// 添加视图
        /// </summary>
        /// <returns></returns>
        public IActionResult AddView()
        {
            return View();
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <returns></returns>
        public int AddPosition(Position position)
        {
            var addposition = HttpClientApi.PostAsync<Position, int>(position, "http://localhost:12345/api/Position/AddPosition");
            return addposition;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int DeletePosition(int id)
        {
            var deleteposition = HttpClientApi.DeleteAsync<int>("http://localhost:12345/api/Position/DeletePosition?id=" + id);
            return deleteposition;
        }
    }
}