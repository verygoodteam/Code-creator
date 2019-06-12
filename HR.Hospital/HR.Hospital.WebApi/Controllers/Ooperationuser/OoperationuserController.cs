using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HR.Hospital.Model;
using HR.Hospital.IRepository;
using HR.Hospital.IRepository.OoperationUser;

namespace HR.Hospital.WebApi.Controllers.Ooperationuser
{
    [Route("api/[controller]")]
    [ApiController]
    public class OoperationuserController : ControllerBase
    {
        public IOoperationUserRepository iooperuser { get; set; }

        //构造函数注入
        public OoperationuserController(IOoperationUserRepository iooperusers)
        {
            iooperuser = iooperusers;
        }


        //显示
        [HttpGet("GetOoperuser")]
        public List<Model.Ooperationuser> GetOoperuser(int administrativeid, string name, string englishname)
        {
            var studentshow = iooperuser.ShowOoperationUser(administrativeid, name, englishname);
            return studentshow;
        }
    }
}