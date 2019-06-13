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
        public List<Model.Ooperationuser> GetOoperuser(int hierarchyid = 0, string name = "", string englishname = "")
        {
            var usershow = iooperuser.ShowOoperationUser(hierarchyid, name, englishname);
            return usershow;
        }

        //能级下拉
        [HttpGet("GetHierarchie")]
        public List<Model.Hierarchy> GetHierarchie()
        {
            var Hierarchies = iooperuser.GetHierarchies();
            return Hierarchies;
        }
    }
}