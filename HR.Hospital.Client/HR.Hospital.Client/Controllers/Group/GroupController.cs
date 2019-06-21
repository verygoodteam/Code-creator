
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
            var list = HttpClientApi.GetAsync<Common.PageHelper<Professionalgroup>>(HttpHelper.Url + "Group/GetPagedList?pageIndex=" + pageIndex + "&pageSize=" + pageSize  + "&name=" + name);
            return list;
        }

        /// <summary>
        /// 获取科室
        /// </summary>
        /// <returns></returns>
        public List<Administrative> GetDepartment()
        {
            var list = HttpClientApi.GetAsync<List<Administrative>>(HttpHelper.Url + "Group/GetDepartment");
            return list;
        }

        /// <summary>
        /// 获取人员
        /// </summary>
        /// <returns></returns>
        public List<Clinicuser> GetClinical()
        {
            var list = HttpClientApi.GetAsync<List<Clinicuser>>(HttpHelper.Url + "Group/GetClinical");
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
            var i = HttpClientApi.PostAsync<Professionalgroup, int>(model, HttpHelper.Url + "Group/add");
            return Redirect("/Group/Index");
        }
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var i = HttpClientApi.DeleteAsync<int>(HttpHelper.Url + "Group/delete?id=" + id);
            return Redirect("/Group/Index");
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
        public Professionalgroup UpdateData(int id)
        {
            var list = HttpClientApi.GetAsync<Professionalgroup>(HttpHelper.Url + "Group/GetModel?id=" + id);
            return list;
        }
        
        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateGroup(Professionalgroup model)
        {
            var i = HttpClientApi.PutAsync<Professionalgroup, int>(model, HttpHelper.Url + "Group/update");
            return Redirect("/Group/Index");
        }
    }
}