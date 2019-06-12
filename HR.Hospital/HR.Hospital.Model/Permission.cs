using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class Permission
    {
        public int Id { get; set; }
        public string PermissionsName { get; set; }
        public string Url { get; set; }
        public int? Pid { get; set; }
        public int? Isnable { get; set; }
        public DateTime? Createtime { get; set; }
    }
}
