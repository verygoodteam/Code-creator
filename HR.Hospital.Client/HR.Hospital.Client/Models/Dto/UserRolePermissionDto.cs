using System;
using System.Collections.Generic;
using System.Text;


namespace HR.Hospital.Client.Models.Dto
{
    public class UserRolePermissionDto
    {
        public UserRolePermissionDto()
        {

        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int PermissionId { get; set; }
        public string PermissionsName { get; set; }
        public int Pid { get; set; }
        public string Url { get; set; }
    }
}
