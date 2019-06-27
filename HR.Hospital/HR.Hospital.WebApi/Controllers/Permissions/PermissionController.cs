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
    [Route("api/[controller]")]
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

        ////显示
        //[HttpGet("GetPermmission")]
        //public PageHelper<PermissionDto> GetPermmission(int pageIndex = 1, int pageSize = 3)
        //{
        //    var show = PermissionRepository.Getpermission(pageIndex,pageSize);
        //    return show;
        //}

        ////回显
        //[HttpGet("RoilPermmissionList")]
        //public Permission RoilPermmissionList(int id)
        //{
        //    var roil = PermissionRepository.Roilpermission(id);
        //    return roil;
        //}

        ////权限下拉
        //[HttpGet("GetPermmissionList")]
        //public List<Permission> GetPermmissionList()
        //{
        //    var list = PermissionRepository.Getlist();
        //    return list;
        //}

        ////修改状态
        //[HttpPost("UpdateIsable")]
        //public int UpdateIsable([FromBody]Permission permission)
        //{
        //    var updateenable = PermissionRepository.Updateenable(permission);
        //    return updateenable;
        //}

        ////修改权限
        //[HttpPost("UpdatePermmission")]
        //public int UpdatePermmission([FromBody]Permission permission)
        //{
        //    var updatepermission = PermissionRepository.Updatepermission(permission);
        //    return updatepermission;
        //}

        ////添加
        //[HttpPost("AddPermmission")]
        //public int AddPermmission(Permission permission)
        //{
        //    var addpermission = PermissionRepository.Addpermission(permission);
        //    return addpermission;
        //}
    }
}