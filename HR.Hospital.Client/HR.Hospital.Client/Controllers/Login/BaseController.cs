using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HR.Hospital.Cache.Redis;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HR.Hospital.Client.Controllers.Login
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public Models.Ooperationuser userInfo
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var tmpuserInfo = Cache.Redis.RedisHelper.Get<Models.Ooperationuser>(User.Identity.Name);
                    return tmpuserInfo;
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmpUser"></param>
        public void WriteCookie(Models.Ooperationuser ooperationuser)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, ooperationuser.OoperationUserName));
             
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            //存储redis
           Cache.Redis.RedisHelper.Set<Models.Ooperationuser>(ooperationuser.OoperationUserName, ooperationuser);

            //取Redis-测试
            var tmpUser = RedisHelper.Get<Models.Ooperationuser>(ooperationuser.OoperationUserName);
        }

        /// <summary>
        /// 动作过滤器-动作执行之前的事件
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            controller.ViewBag.LoginInfo = userInfo;
            base.OnActionExecuting(filterContext);
        }

    }
}