using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class Operations
    {
        public int Id { get; set; }
        public string OperationName { get; set; }
        public int? DepartmentId { get; set; }
        public string OperationCreateTime { get; set; }
    }
}
