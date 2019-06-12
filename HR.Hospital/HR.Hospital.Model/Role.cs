using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string PermissionName { get; set; }
        public int? Isnable { get; set; }
    }
}
