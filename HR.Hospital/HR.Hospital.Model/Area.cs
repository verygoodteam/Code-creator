using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class Area
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public int? OperatingNum { get; set; }
        public int? AreaProperty { get; set; }
        public int? Isnable { get; set; }
        public string AreaRemark { get; set; }
    }
}
