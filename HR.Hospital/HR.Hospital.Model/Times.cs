using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class Times
    {
        public int Id { get; set; }
        public DateTime? DateTimes { get; set; }
        public int? UserId { get; set; }
        public int? ShiftsId { get; set; }
        public string Remark { get; set; }
    }
}
