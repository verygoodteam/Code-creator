
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.Group
{
    public class GroupController : Controller
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public PageHelper<Professionalgroup> PageList(int pageIndex = 1, int pageSize = 3, string name = "")
        {
            var list = HttpClientApi.GetAsync<PageHelper<Professionalgroup>>("http://localhost:12345/api/Group/getPagedList?pageIndex=" + pageIndex + "&pageSize=" + pageSize  + "&name=" + name);
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
        public ActionResult Add(Professionalgroup model)
        {
            var i = HttpClientApi.PostAsync<Professionalgroup, int>(model, "http://localhost:12345/api/Group/add");
            return Redirect("/Group/Index");
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var i = HttpClientApi.DeleteAsync<int>("http://localhost:12345/api/Group/delete?id=" + id);
            return Redirect("/Group/Index");
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            var list = HttpClientApi.GetAsync<Professionalgroup>("http://localhost:12345/api/Group/GetModel?id=" + id);
            return View(list);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Professionalgroup model)
        {
            var i = HttpClientApi.PutAsync<Professionalgroup, int>(model, "http://localhost:12345/api/Group/update");
            return Redirect("/Group/Index");
        }
    }
}