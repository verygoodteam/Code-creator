using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Hospital.Client.Models
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
        [Display(Name = "被换班人")]
        public int ShiftChangerId { get; set; }

        /// <summary>
        /// 换班理由
        /// </summary>
        [Display(Name = "换班理由")]
        public string Reason { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        [Display(Name = "开始时间")]
        public DateTime ApplicationTime { get; set; }

        /// <summary>
        /// 换班时长
        /// </summary>
        [Display(Name = "换班时长")]
        [RegularExpression(@"^[0-7]*$", ErrorMessage = "请输入小于7天")]
        public int Duration { get; set; }

    }
}
