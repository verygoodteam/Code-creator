using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.Roles
{
   public interface IRoleRepository
    {
        /// <summary>
        /// 查询角色权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<RolePermission> RolePerList(int id);

        /// <summary>
        /// 角色显示
        /// </summary>
        /// <returns></returns>
        List<Role> GetRoles();

        /// <summary>
        /// 权限列表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        List<Permission> GetPermission(int pid = 0);

        /// <summary>
        ///添加角色 
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        int AddRole(Role roles, string ids);

        /// <summary>
        /// 回显角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Role Roles(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        int UpdateRole(Role roles, string ids);

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int UpdateEnable(Role role);
    }
}
