using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 排班类
    /// </summary>
    public class Scheduling
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public DateTime Date { get; set; }
        public string Week { get; set; }
        public int ShiftssettingId { get; set; }
    }
}
