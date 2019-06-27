using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Cache.Redis;
using HR.Hospital.Client.Common;
using HR.Hospital.Client.Filter;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers.ShiftDutys
{
    public class ShiftDutyController : BaseController
    {
        [MyActionFilter]
        public IActionResult AddShiftDuty()
        {



            //Id写死
            


            

            
            

            //获取登陆人所有的信息
            var user = RedisHelper.Get<Ooperationuser>("1");
            //获取角色Id
            var roleId = user.Roleid;
            var userList = HttpClientApi.GetAsync<List<Ooperationuser>>(HttpHelper.Url + "ShiftDuty/GetUserList?roleId=" + roleId);
            ViewBag.userList = userList.Where(p => p.Id != 1).ToList();
            return View();
        }

    }
}