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

        public PageHelper<PermissionDto> GetPermissionList(int pageIndex, int pageSize, string name)
        {
            var page = new PageHelper<PermissionDto>();
            //EF进行两表联查自连接进行投影显示父级元素的名字
            var query = (from p1 in db.Permission
                         join p2 in db.Permission on p1.Pid equals p2.Id
                             into joinedEmpDept1
                         from p2 in joinedEmpDept1.DefaultIfEmpty()
                         select new PermissionDto
                         {
                             Id = p1.Id,
                             PermissionsName = p1.PermissionsName,
                             Pid = p1.Pid,
                             IsEnable = p1.Isnable,
                             FatherName = p2.PermissionsName
                         }).ToList();
            //对没有模糊查询的进行一个分页
            var perList = query.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            //获取两表联查的一个总条数
            var total = query.Count();
            //当前页赋值
            page.PageIndex = pageIndex;
            //每页大小进行赋值
            page.PageSize = pageSize;
            //总条数进行赋值
            page.PageSizes = total;
            //集合赋值
            page.PageList = perList;
            //计算出最大页数
            page.PageNum = (page.PageSizes / pageSize);
            //判断条件是否为空
            if (name == null) return page;
            {
                //进行一个模糊查询
                var nameList = query.Where(p => p.PermissionsName.Contains(name)).ToList();
                var pageList = nameList.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                var totalCount = nameList.Count();
                //当前页赋值
                page.PageIndex = pageIndex;
                //每页大小进行赋值
                page.PageSize = pageSize;
                //总条数进行赋值
                page.PageSizes = totalCount;
                //集合赋值
                page.PageList = pageList;
                //计算出最大页数
                page.PageNum = (page.PageSizes / pageSize);
            }
            return page;

        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        /// <summary>
        /// 是否启用权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int EnablePermission(Permission permission)
        {
            var info = db.Permission.FirstOrDefault(p => p.Id == permission.Id);
            if (info != null) info.Isnable = permission.Isnable;
            return db.SaveChanges();
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int UpdatePermission(Permission permission)
        {
            var model = db.Permission.FirstOrDefault(p => p.Id == permission.Id);
            if (model == null) return db.SaveChanges();
            model.PermissionsName = permission.PermissionsName; //名称
            model.Url = permission.Url; //路径
            model.Pid = permission.Pid; //父级Id
            model.Isnable = permission.Isnable; //是否启用
            //model.Createtime = DateTime.Now; //创建时间
            return db.SaveChanges();
        }
    }
}
