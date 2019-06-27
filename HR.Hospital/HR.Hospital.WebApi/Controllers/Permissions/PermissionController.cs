using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HR.Hospital.IRepository.Permissions;
using HR.Hospital.Model;
using HR.Hospital.Common;
using HR.Hospital.Model.Dto;

namespace HR.Hospital.WebApi.Controllers.Permissions
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        //实例化上下文对象
        public IPermissionRepository PermissionRepository { get; set; }

        //构造函数注入
        public PermissionController(IPermissionRepository permissionRepository)
        {
            PermissionRepository = permissionRepository;
        }

        //显示
        //[HttpGet("GetPageList")]
        //public PageHelper<PermissionDto> GetPageList(int pageIndex = 1, int pageSize = 3)
        //{
        //    var show = PermissionRepository.GetPermissionList(pageIndex, pageSize);
        //    return show;
        //}

        //添加
        [HttpPost("AddPermission")]
        public int AddPermission(Permission permission)
        {
            var i = PermissionRepository.AddPermission(permission);
            return i;
        }
        
        //权限下拉
        [HttpGet("GetList")]
        public List<Permission> GetList()
        {
            var list = PermissionRepository.GetList();
            return list;
        }
        
        //获取数据
        [HttpGet("GetPermission")]
        public Permission GetPermission(int id)
        {
            var roil = PermissionRepository.GetPermission(id);
            return roil;
        }

        //是否启用
        [HttpPost("EnablePermission")]
        public int EnablePermission([FromBody]Permission permission)
        {
            var i = PermissionRepository.EnablePermission(permission);
            return i;
        }

        //修改权限
        [HttpPost("UpdatePermission")]
        public int UpdatePermission([FromBody]Permission permission)
        {
            var i = PermissionRepository.UpdatePermission(permission);
            return i;
        }
        
    }
}