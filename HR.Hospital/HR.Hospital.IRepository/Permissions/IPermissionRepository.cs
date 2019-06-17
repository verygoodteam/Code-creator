using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model.Dto;
using HR.Hospital.Common;

namespace HR.Hospital.IRepository.Permissions
{
   public interface IPermissionRepository
    {
        //权限显示
        PageHelper<PermissionDto> getpermission(int pageIndex = 1, int pageSize = 3);

        //权限回显
        Model.Permission roilpermission(int id);

        //权限下拉
        List<Model.Permission> getlist();

        //权限添加
        int addpermission(Model.Permission permission);

        //修改状态
        int updateenable(Model.Permission permission);

        //权限修改
        int updatepermission(Model.Permission permission);
    }
}
