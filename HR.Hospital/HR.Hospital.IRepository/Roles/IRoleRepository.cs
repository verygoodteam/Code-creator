using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.Roles
{
   public interface IRoleRepository
    {
        //权限列表
        List<Permission> GetPermission(int pid = 0);

        //添加角色
        int Addrole(Role roles, string ids);

        //回显角色
        Role role(int id);

        //修改
        int updaterole(Role roles, string ids);
    }
}
