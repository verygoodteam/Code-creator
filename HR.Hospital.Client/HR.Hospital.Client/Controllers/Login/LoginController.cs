using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.Client.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.Client.Controllers
{
    public class LoginController : BaseController
    {
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult LoginDo(Models.Ooperationuser ooperationuser, string returnUrl = null)
        {
            //验证用户是否登录
            //const string errorMessage = "用户名或密码错误！";
            if (ooperationuser == null)
            {
                return RedirectToAction(nameof(LoginController.Login), "Login");
            }
            var tmpUser = Common.HttpClientApi.GetAsync<List<Models.Ooperationuser>>("http://localhost:12345/api/Login/Get").FirstOrDefault(m => m.OoperationUserName == ooperationuser.OoperationUserName && m.Pwd == ooperationuser.Pwd);
            if (tmpUser?.Pwd != ooperationuser.Pwd)
            {
                return RedirectToAction(nameof(LoginController.Login), "Login");
            }

            //写入缓存
            WriteCookie(tmpUser);

            //判断是否返回前页
            //if (returnUrl == null)
            //{
            //    returnUrl = TempData["returnUrl"]?.ToString();
            //}
            //if (returnUrl != null)
            //{
            //    return Redirect(returnUrl);
            //}

            return RedirectToAction(nameof(HomeController.MainIndex), "Home");
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(LoginController.Login), "Login");
        }
    }
}