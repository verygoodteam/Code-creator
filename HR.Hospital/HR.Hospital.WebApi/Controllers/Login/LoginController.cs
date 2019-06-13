using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.IRepository.Login;
using Microsoft.AspNetCore.Mvc;
using HR.Hospital.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.Hospital.WebApi.Controllers.Login
{
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        public readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        /// <summary>
        /// 判断是否有这个用户  
        /// </summary>
        /// <param name="ooperationuser"></param>
        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Model.Ooperationuser ooperationuser)
        {
            _userRepository.Login(ooperationuser);
        }

        [HttpPost]
        public IActionResult LoginDo(Model.Ooperationuser ooperationuser, string returnUrl = null)
        {
            //验证用户是否登录
            const string errorMessage = "用户名或密码错误！";
            if (ooperationuser == null)
            {
                return BadRequest(errorMessage);
            }
            var tmpUser = _userRepository.ooperationusers().FirstOrDefault(m => m.OoperationUserName == ooperationuser.OoperationUserName && m.Pwd == ooperationuser.Pwd);
            if (tmpUser?.Pwd != ooperationuser.Pwd)
            {
                return BadRequest(errorMessage);
            }

            //写入缓存
            WriteCookie(tmpUser);

            //判断是否返回前页
            if (returnUrl == null)
            {
                returnUrl = TempData["returnUrl"]?.ToString();
            }
            if (returnUrl != null)
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(nameof(LoginController.Post), "Home");
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(LoginController.Post), "Account");
        }
    }
}
