using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.IRepository.Roles;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.Roles
{
    public class RoleRepository : IRoleRepository
    {
        //实例化上下文类
        hospitaldbContext db = new hospitaldbContext();

        /// <summary>
        /// 权限列表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<Permission> GetPermission(int pid = 0)
        {
            var list = db.Permission.Where(p=>p.Pid==pid).ToList();
            return list;
        }

        
        /// <summary>
        ///角色回显 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role role(int id)
        {
            var list = db.Role.FirstOrDefault(p=>p.Id==id);
            return list;
        }

        
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int updaterole(Role roles, string ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Addrole(Role roles, string ids)
        {
            var id = ids.Split(',');
            int[] array = new int[id.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(id[i]);
            }

            List<RolePermission> rolepermission = new List<RolePermission>();
            return 0;
           
        }
    }
}
