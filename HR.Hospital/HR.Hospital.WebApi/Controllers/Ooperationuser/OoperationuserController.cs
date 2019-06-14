using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HR.Hospital.Model;
using HR.Hospital.Common;
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


        //显示查询
        [HttpGet("GetOoperuser")]
        public List<Common.OoperationuserModel.Ooperationuser> GetOoperuser(int hierarchyid = 0, string name = "", string englishname = "")
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

        //角色下拉
        [HttpGet("GetRole")]
        public List<Model.Role> GetRole()
        {
            var Roles = iooperuser.GetRoles();
            return Roles;
        }

        //职务下拉
        [HttpGet("GetPosition")]
        public List<Model.Position> GetPosition()
        {
            var Positions = iooperuser.GetPositions();
            return Positions;
        }

        //职称下拉
        [HttpGet("GetProfessional")]
        public List<Model.Professional> GetProfessional()
        {
            var Professionals = iooperuser.GetProfessionals();
            return Professionals;
        }

        //主管下拉
        [HttpGet("GetUser")]
        public List<Model.Ooperationuser> GetUser()
        {
            var Ooperationusers = iooperuser.GetOoperationusers();
            return Ooperationusers;
        }

        //手术室用户添加
        [HttpPost("InsertOoperationuser")]
        public int InsertOoperationuser(Model.Ooperationuser operuser)
        {
            var InsertOoperationusers = iooperuser.AddOoperationUser(operuser);
            return InsertOoperationusers;
        }

    }
}