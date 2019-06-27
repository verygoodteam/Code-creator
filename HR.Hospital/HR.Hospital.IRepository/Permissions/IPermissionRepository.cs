using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model.Dto;
using HR.Hospital.Model;
using HR.Hospital.Common;

namespace HR.Hospital.IRepository.Permissions
{
    public interface IPermissionRepository
    {
        /// <summary>
        /// 权限显示分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        PageHelper<PermissionDto> GetPermissionList(int pageIndex = 1, int pageSize = 3, string name = "");

        /// <summary>
        /// 获取权限对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Permission GetPermission(int id);

        /// <summary>
        /// 权限下拉
        /// </summary>
        /// <returns></returns>
        List<Permission> GetList();

        //权限添加
        int AddPermission(Permission permission);

        /// <summary>
        /// 删除权限(假删除)启用禁用
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        int EnablePermission(Permission permission);

        /// <summary>
        /// 权限修改
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        int UpdatePermission(Model.Permission permission);
    }
}
