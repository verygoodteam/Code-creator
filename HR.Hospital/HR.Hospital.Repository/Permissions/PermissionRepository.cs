using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.IRepository.Permissions;
using HR.Hospital.Common;
using System.Linq;
using HR.Hospital.Model.Dto;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.Permissions
{
    public class PermissionRepository : IPermissionRepository
    {
        //实例化上下文类
        hospitaldbContext db = new hospitaldbContext();

        public PageHelper<PermissionDto> GetPermissionList(int pageIndex = 1, int pageSize = 3, string name = "")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取权限下拉
        /// </summary>
        /// <returns></returns>
        public List<Permission> GetList()
        {
            var list = db.Permission.ToList();
            return list;
        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int AddPermission(Permission permission)
        {
            db.Permission.Add(permission);
            return db.SaveChanges();
        }

        /// <summary>
        /// 是否启用权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int EnablePermission(Permission permission)
        {
            var info = db.Permission.FirstOrDefault(p => p.Id == permission.Id);
            info.Isnable = permission.Isnable;
            return db.SaveChanges();
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Permission GetPermission(int id)
        {
            var permission = db.Permission.FirstOrDefault(p => p.Id == id);
            return permission;
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int UpdatePermission(Permission permission)
        {
            var model = db.Permission.FirstOrDefault(p => p.Id == permission.Id);
            model.PermissionsName = permission.PermissionsName; //名称
            model.Url = permission.Url; //路径
            model.Pid = permission.Pid; //父级Id
            model.Isnable = permission.Isnable; //是否启用
            //model.Createtime = DateTime.Now; //创建时间
            return db.SaveChanges();
        }
    }
}
