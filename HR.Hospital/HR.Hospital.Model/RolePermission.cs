using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class RolePermission
    {
        public int Id { get; set; }
        public int? Pid { get; set; }
        public int? Rid { get; set; }
    }
}
