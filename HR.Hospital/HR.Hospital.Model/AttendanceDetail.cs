using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Model
{
    public class AttendanceDetail
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Person { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AttendanceTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Shift { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Attendance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime GoWork { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GoResult { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime AfterWork { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AfterResult { get; set; }

    }
}
