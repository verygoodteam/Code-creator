using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.Solitaire
{
    public class SolitaireController : Controller
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        public PageHelper<SolitaireSet> PageList(int pageIndex = 1, int pageSize = 3, string shift = "")
        {
            var list = HttpClientApi.GetAsync<PageHelper<SolitaireSet>>(HttpHelper.Url + "Solitaire/GetPagedList?pageIndex=" + pageIndex + "&pageSize=" + pageSize + "&shift=" + shift);
            return list;
        }

        /// <summary>
        /// 获取班次
        /// </summary>
        /// <returns></returns>
        public List<Models.Shiftssetting> GetShift()
        {
            var list = HttpClientApi.GetAsync<List<Models.Shiftssetting>>(HttpHelper.Url + "Solitaire/GetShift");
            return list;
        }

        public ActionResult PersonIndex()
        {
            return View();
        }
        /// <summary>
        /// 获取人员
        /// </summary>
        /// <returns></returns>
        public PageHelper<Clinicuser> GetPerson(int pageIndex = 1, int pageSize = 3, string name = "")
        {
            var list = HttpClientApi.GetAsync<PageHelper<Clinicuser>>(HttpHelper.Url + "Solitaire/GetPerson?pageIndex=" + pageIndex + "&pageSize=" + pageSize + "&name=" + name);
            return list;
        }

        /// <summary>   
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public int Add(SolitaireSet model)
        {
            var i = HttpClientApi.PostAsync<SolitaireSet, int>(model, HttpHelper.Url + "Solitaire/Add");
            return i;
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            var i = HttpClientApi.DeleteAsync<int>(HttpHelper.Url + "Solitaire/Delete?id=" + id);
            return i;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <returns></returns>
        public SolitaireSet UpdateData(int id)
        {
            var list = HttpClientApi.GetAsync<SolitaireSet>(HttpHelper.Url + "Solitaire/GetModel?id=" + id);
            return list;
        }
        
        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int Update(SolitaireSet model)
        {
            var i = HttpClientApi.PutAsync<SolitaireSet, int>(model, HttpHelper.Url + "Solitaire/Update");
            return i;
        }


    }
}