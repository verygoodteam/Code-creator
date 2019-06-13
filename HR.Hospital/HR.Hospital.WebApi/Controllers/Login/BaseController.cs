using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HR.Hospital.WebApi.Controllers.Login
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        public Model.Ooperationuser ooperationuser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    var tmpuserInfo = Cache.Redis.RedisHelper.Get<Model.Ooperationuser>(User.Identity.Name);
                    return tmpuserInfo;
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmpUser"></param>
        public void WriteCookie(Model.Ooperationuser tmpUser)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, tmpUser.OoperationUserName));
             
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            //存储redis
           Cache.Redis.RedisHelper.Set<Model.Ooperationuser>(tmpUser.OoperationUserName, tmpUser);

            ////取Redis-测试
            //var tmpUser = RedisHelper.Get<UserInfo>(tmpUser.UserName);
        }

        /// <summary>
        /// 动作过滤器-动作执行之前的事件
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            controller.ViewBag.LoginInfo = ooperationuser;
            base.OnActionExecuting(filterContext);
        }

    }
}