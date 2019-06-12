using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class Rulesettings
    {
        public int Id { get; set; }
        public int? ShiftsId { get; set; }
        public DateTime? OneTime { get; set; }
        public DateTime? TwoTime { get; set; }
        public DateTime? ThreeTime { get; set; }
        public bool? Types { get; set; }
    }
}
