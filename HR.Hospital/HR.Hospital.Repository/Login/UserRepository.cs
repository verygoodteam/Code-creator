using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HR.Hospital.IRepository.Login;
using HR.Hospital.Model;
using HR.Hospital.Model.Dto;
using HR.Hospital.Common;
using HR.Hospital.IRepository;
using HR.Hospital.IRepository.OperationRooms;
using Microsoft.EntityFrameworkCore;

namespace HR.Hospital.Repository.Login
{
    public class UserRepository : IUserRepository
    {

        public int Login(Model.Ooperationuser ooperationuser)
        {
            using (Model.hospitaldbContext context = new Model.hospitaldbContext())
            {
                Model.Ooperationuser uer = context.Ooperationuser.Where(u => u.OoperationUserName == ooperationuser.OoperationUserName && u.Pwd == ooperationuser.Pwd).FirstOrDefault();
                if (uer != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public List<Model.Ooperationuser> ooperationusers()
        {
            using (Model.hospitaldbContext context = new Model.hospitaldbContext())
            {
                return context.Ooperationuser.ToList();
            }
        }

        /// <summary>
        /// 根据登陆人找到对应的权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<UserRolePermissionDto> userRolePermissionDtos(int id)
        {
            using (Model.hospitaldbContext context = new Model.hospitaldbContext())
            {

                var sql = $"select a.Id,a.OoperationUserName as UserName,c.Id as RoleId,c.RoleName,e.Id as PermissionId,e.PermissionsName,e.Url from ooperationuser a join user_role b on a.Id = b.Uid  join role c on b.Rid = c.Id join role_permission d on c.Id = d.Rid join permission e on d.Pid = e.Id WHERE a.Id ={id}";
#pragma warning disable EF1000 // Possible SQL injection vulnerability.
                List<UserRolePermissionDto> userRolePermissionDto = context.QueryUserRolePermissionDto.FromSql(sql).ToList();
#pragma warning restore EF1000 // Possible SQL injection vulnerability.

                //var userRolePermissionDto = context.QueryUserRolePermissionDto.FromSql("select a.Id,a.OoperationUserName,c.Id,c.RoleName,e.Id,e.PermissionsName,e.Url " +
                //    "from ooperationuser a " +
                //    "join user_role b on a.Id = b.Uid  " +
                //    "join role c on b.Rid = c.Id " +
                //    "join role_permission d on c.Id = d.Rid " +
                //    "join permission e on d.Pid = e.Id  WHERE a.Id = {0}", id)
                //    .ToList();
                return userRolePermissionDto;
            }
        }
    }
}
//select a.Id, a.OoperationUserName as UserName, c.Id as RoleId, c.RoleName, e.Id as PermissionId, e.PermissionsName, e.Url from ooperationuser a join user_role b on a.Id = b.Uid  join role c on b.Rid = c.Id join role_permission d on c.Id = d.Rid join permission e on d.Pid = e.Id  WHERE a.Id = 1

