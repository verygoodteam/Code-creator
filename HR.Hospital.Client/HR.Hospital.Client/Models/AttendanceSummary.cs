using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Hospital.Client.Models
{
    public class AttendanceSummary
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
        public int? AttendanceDays { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? AbsencesDays { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? LateNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? LeaveNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? LackCard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Absenteeism { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? AnnualLeave { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? SickLeave { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? AffairLeave { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? MaternityLeave { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? MarriageLeave { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FuneralLeave { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? HomeLeave { get; set; }
    }
}
