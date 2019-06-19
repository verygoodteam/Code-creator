using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;

namespace HR.Hospital.Client.Controllers.Hierarchys
{
    public class HierarchyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 显示视图
        /// </summary>
        /// <returns></returns>
        public IActionResult HierarchieView()
        {
            var gethierarchie = HttpClientApi.GetAsync<List<Hierarchy>>("http://localhost:12345/api/Hierarchy/GetHierarchy");
            return View(gethierarchie);
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
        public int AddHierarchie(Hierarchy hierarchy)
        {
            var addhierarchie = HttpClientApi.PostAsync<Hierarchy,int>(hierarchy, "http://localhost:12345/api/Hierarchy/AddHierarchy");
            return addhierarchie;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int DeleteHierarchie(int id)
        {
            var deletehierarchy = HttpClientApi.DeleteAsync<int>("http://localhost:12345/api/Hierarchy/DeleteHierarchy?id=" + id);
            return deletehierarchy;
        }
    }
}