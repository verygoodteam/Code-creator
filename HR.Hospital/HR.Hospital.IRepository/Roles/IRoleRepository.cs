using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.Roles
{
   public interface IRoleRepository
    {
        //角色显示
        List<Role> GetRoles();

        //权限列表
        List<Permission> GetPermission(int pid = 0);

        //添加角色
        int Addrole(Role roles, string ids);

        //回显角色
        Role Roles(int id);

        //修改
        int UpdateRole(Role roles, string ids);
    }
}
