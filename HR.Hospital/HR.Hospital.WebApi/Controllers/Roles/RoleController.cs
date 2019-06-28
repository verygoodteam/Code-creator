using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HR.Hospital.IRepository.Roles;
using HR.Hospital.Model;

namespace HR.Hospital.WebApi.Controllers.Roles
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        //实例化上下文对象
        public IRoleRepository RoleRepository { get; set; }

        //构造函数注入
        public RoleController(IRoleRepository roleRepository)
        {
            RoleRepository = roleRepository;
        }

        /// <summary>
        /// 角色显示
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRoles")]
        public List<Role> GetRoles()
        {
            var list = RoleRepository.GetRoles();
            return list;
        }
        
        /// <summary>
        /// 权限列表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        [HttpGet("PerList")]
        public List<Permission> PerList(int pid = 0)
        {
            var list = RoleRepository.GetPermission(pid);
            return list;
        }

        /// <summary>
        /// 角色回显
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("RoilRoles")]
        public Role RoilRoles(int id)
        {
            var role = RoleRepository.Roles(id);
            return role;
        }
        
        /// <summary>
        /// 角色添加
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddRoles")]
        public int AddRoles(Role roles, string ids)
        {
            var i = RoleRepository.AddRole(roles, ids);
            return i;
        }

        /// <summary>
        /// 角色修改
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("UpdateRoles")]
        public int UpdateRoles([FromBody]Role roles, string ids)
        {
            var i = RoleRepository.UpdateRole(roles, ids);
            return i;
        }

        //修改状态
        [HttpPost("UpdateIsable")]
        public int UpdateIsable([FromBody]Role role)
        {
            var i = RoleRepository.UpdateEnable(role);
            return i;
        }

        //查询角色权限
        [HttpGet("GetRolePer")]
        public List<RolePermission> GetRolePer(int id)
        {
            var list = RoleRepository.RolePerList(id);
            return list;
        }
    }
}