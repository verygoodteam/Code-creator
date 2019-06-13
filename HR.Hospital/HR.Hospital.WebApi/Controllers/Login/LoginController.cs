using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Hospital.IRepository.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Hospital.WebApi.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/Login
        [HttpGet]
        public IEnumerable<Model.Ooperationuser> Get()
        {
           return  _userRepository.ooperationusers();
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public void Post([FromBody] string value)
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
            //WriteCookie(tmpUser);

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

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
