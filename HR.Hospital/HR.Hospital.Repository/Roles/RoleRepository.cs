using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.IRepository.Roles;
using HR.Hospital.Model;

using Dapper;
using MySql.Data.MySqlClient;

namespace HR.Hospital.Repository.Roles
{
    public class RoleRepository : IRoleRepository
    {
        //连接数据库
        string _conn = "Server=169.254.224.180;User Id=root;Password=123456;Database=hospitaldb";

        //实例化上下文类
        hospitaldbContext db = new hospitaldbContext();

        /// <summary>
        /// 权限列表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<Permission> GetPermission(int pid = 0)
        {
            using (MySqlConnection con = new MySqlConnection(_conn))
            {
                var getpermission = "SELECT * FROM permission where Pid=" + pid;

                var getlist = con.Query<Permission>(getpermission);
                return getlist.ToList();
            }
        }

        /// <summary>
        ///角色回显 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Role Roles(int id)
        {
            using (MySqlConnection con = new MySqlConnection(_conn))
            {
                var getrole = $"SELECT * from role where Id={id}";

                var getlist = con.Query<Role>(getrole);
                return getlist.FirstOrDefault();
            }
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int UpdateRole(Role roles, string ids)
        {
            var id = ids.Split(',');
            int[] array = new int[id.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(id[i]);
            }

            List<RolePermission> roleperlist = new List<RolePermission>();

            using (MySqlConnection con = new MySqlConnection(_conn))
            {
                string update = $"update Role set RoleName='{roles.RoleName}',PermissionName='{roles.PermissionName}',Isnable='{roles.Isnable}' where Id='{roles.Id}'";
                string delete = $"delete from role_permission where Rid={roles.Id}";

                con.Execute(update);
                con.Execute(delete);

                for (int i = 0; i < array.Length; i++)
                {
                    RolePermission roleper = new RolePermission();
                    roleper.Rid = roles.Id;
                    roleper.Pid = Convert.ToInt32(id[i]);
                    roleperlist.Add(roleper);
                }

                var updaterole = con.Execute($"insert into role_permission(Rid,Pid) values(@Rid,@Pid)", roleperlist);
                return updaterole;
            }
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

            List<RolePermission> roleJuris = new List<RolePermission>();

            using (MySqlConnection con = new MySqlConnection(_conn))
            {
                string str = $"insert into Role(RoleName, PermissionName, Isnable) values('{roles.RoleName}','{roles.PermissionName}','{roles.Isnable}')";
                string lastid = "SELECT MAX(Id) FROM role";
                con.Execute(str);
                var result = con.Query<int>(lastid).FirstOrDefault();

                for (int i = 0; i < array.Length; i++)
                {
                    RolePermission rolejuir = new RolePermission();
                    rolejuir.Rid = result;
                    rolejuir.Pid = Convert.ToInt32(id[i]);
                    roleJuris.Add(rolejuir);
                }

                var addrolejuris = con.Execute($"insert into role_permission(Rid,Pid) values(@Rid,@Pid)", roleJuris);
                return addrolejuris;
            }
        }

        /// <summary>
        /// 角色显示
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRoles()
        {
            using (MySqlConnection con = new MySqlConnection(_conn))
            {
                var getrole = "SELECT * from role";

                var getlist = con.Query<Role>(getrole);
                return getlist.ToList();
            }
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int Updateenable(Role role)
        {
            var getrole = db.Role.FirstOrDefault(p => p.Id == role.Id);
            getrole.Isnable = role.Isnable;
            var i = db.SaveChanges();
            return i;
        }

        /// <summary>
        /// 角色权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<RolePermission> RolePerList(int id)
        {
            using (MySqlConnection con = new MySqlConnection(_conn))
            {
                var getroleper = $"SELECT * from role_permission WHERE rid={id}";

                var getlist = con.Query<RolePermission>(getroleper);
                return getlist.ToList();
            }
        }
    }
}
