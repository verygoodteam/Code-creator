using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class Administrative
    {
        public int Id { get; set; }
        public string AdministrativeName { get; set; }
        public int? Isoperation { get; set; }
        public string AdministrativeRemark { get; set; }
    }
}
