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
        PageHelper<PermissionDto> Getpermission(int pageIndex = 1, int pageSize = 3);

        //权限回显
        Model.Permission Roilpermission(int id);

        //权限下拉
        List<Model.Permission> Getlist();

        //权限添加
        int Addpermission(Model.Permission permission);

        //修改状态
        int Updateenable(Model.Permission permission);

        //权限修改
        int Updatepermission(Model.Permission permission);
    }
}
