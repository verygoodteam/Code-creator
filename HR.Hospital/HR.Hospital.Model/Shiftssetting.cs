using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class Shiftssetting
    {
        public int Id { get; set; }
        public string Shiftssettingcolour { get; set; }
        public string ShiftssettingName { get; set; }
        public DateTime? Opentime { get; set; }
        public DateTime? Closingtime { get; set; }
        public string Validtime { get; set; }
        public string Duration { get; set; }
        public int? Isclock { get; set; }
        public int? Shiftssettingtypeid { get; set; }
        public int? Sortid { get; set; }
        public string Validday { get; set; }
    }
}
