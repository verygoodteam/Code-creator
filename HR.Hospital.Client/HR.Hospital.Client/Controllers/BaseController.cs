using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HR.Hospital.Cache.Redis;
using HR.Hospital.Client.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace HR.Hospital.Client.Controllers
{
    public class BaseController : Controller
    {
        protected static int _id;
        /// <summary>
        /// 用户信息
        /// </summary>
        public Ooperationuser UserInfo
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var tmpuserInfo = Cache.Redis.RedisHelper.Get<Ooperationuser>(User.Identity.Name);
                    return tmpuserInfo;
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void WriteCookie(Ooperationuser ooperationuser)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, ooperationuser.OoperationUserName));

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            _id = ooperationuser.Id;
            //存储redis
            Cache.Redis.RedisHelper.Set(_id.ToString(), ooperationuser);

            //取Redis-测试
            var tmpUser = RedisHelper.Get<Ooperationuser>(_id.ToString());
        }

        /// <summary>
        /// 动作过滤器-动作执行之前的事件
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            controller.ViewBag.LoginInfo = UserInfo;
            base.OnActionExecuting(filterContext);
        }

    }
}