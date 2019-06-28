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

        /// <summary>
        /// 显示分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public PageHelper<PermissionDto> GetPageList(int pageIndex, int pageSize, string name)
        {
            var show = PermissionRepository.GetPermissionList(pageIndex, pageSize, name);
            return show;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        [HttpPost("AddPermission")]
        public int AddPermission(Permission permission)
        {
            var i = PermissionRepository.AddPermission(permission);
            return i;
        }

        /// <summary>
        /// 权限下拉
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetList")]
        public List<Permission> GetList()
        {
            var list = PermissionRepository.GetList();
            return list;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetPermission")]
        public Permission GetPermission(int id)
        {
            var roil = PermissionRepository.GetPermission(id);
            return roil;
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        [HttpPost("EnablePermission")]
        public int EnablePermission([FromBody]Permission permission)
        {
            var i = PermissionRepository.EnablePermission(permission);
            return i;
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        [HttpPost("UpdatePermission")]
        public int UpdatePermission([FromBody]Permission permission)
        {
            var i = PermissionRepository.UpdatePermission(permission);
            return i;
        }

    }
}