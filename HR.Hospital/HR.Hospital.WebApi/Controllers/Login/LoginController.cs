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
    public class LoginController : Controller
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
        [HttpGet("Post")]
        public void Post([FromBody]Model.Ooperationuser ooperationuser)
        {
            _userRepository.Login(ooperationuser);
        }

      
    }
}
