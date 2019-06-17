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

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int addpermission(Permission permission)
        {
            db.Permission.Add(permission);
            var sql = db.SaveChanges();
            return sql;

        }

        /// <summary>
        /// 权限下拉
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public List<Permission> getlist()
        {
            var list = db.Permission.ToList();
            return list;
        }

        /// <summary>
        /// 显示权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public PageHelper<PermissionDto> getpermission(int pageIndex = 1, int pageSize = 3)
        {
            var page = new PageHelper<PermissionDto>();

            var query = from p1 in db.Permission
                        join p2 in db.Permission on  p1.Pid equals p2.Id
                        into JoinedEmpDept1
                        from p2 in JoinedEmpDept1.DefaultIfEmpty()
                        select new PermissionDto
                        {
                            Id = p1.Id,
                            PermissionsName = p1.PermissionsName,
                            Pid = p1.Pid,
                            Isnable=p1.Isnable,
                            FatherName=p2.PermissionsName
                        };

            var perlist = query.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var total = db.Permission.Count();

            page.PageSizes = total;
            page.PageList = perlist;
            page.PageNum = (page.PageSizes / pageSize);

            return page;

        }

        //回显
        public Permission roilpermission(int id)
        {
            var roil = db.Permission.FirstOrDefault(p=>p.Id==id);
            return roil;
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int updateenable(Permission permission)
        {
            var info = db.Permission.FirstOrDefault(p => p.Id == permission.Id);
            info.Isnable = permission.Isnable;
            var sql = db.SaveChanges();
            return sql;
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int updatepermission(Permission permission)
        {
            var info = db.Permission.FirstOrDefault(p => p.Id == permission.Id);
            info.Pid = permission.Pid;
            info.Isnable = permission.Isnable;
            info.PermissionsName = permission.PermissionsName;
            info.Url = permission.Url;
            info.Createtime = DateTime.Now;

            var sql = db.SaveChanges();
            return sql;
        }

    }
}
