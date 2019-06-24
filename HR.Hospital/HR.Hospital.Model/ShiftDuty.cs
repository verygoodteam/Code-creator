using System;
using System.ComponentModel.DataAnnotations;

namespace HR.Hospital.Model
{
    public class ShiftDuty
    {

        /// <summary>
        ///主表Id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 申请人Id
        /// </summary>

        public int ApplicantId { get; set; }

        /// <summary>
        /// 被换班人Id
        /// </summary>
        public int ShiftChangerId { get; set; }

        /// <summary>
        /// 换班理由
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplicationTime { get; set; }

        /// <summary>
        /// 换班时长
        /// </summary>
        public int Duration { get; set; }

    }
}
