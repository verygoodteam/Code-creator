using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class Operationroom
    {
        public int Id { get; set; }
        public int? AreaId { get; set; }
        public string OperationName { get; set; }
        public string OperationRemark { get; set; }
    }
}
