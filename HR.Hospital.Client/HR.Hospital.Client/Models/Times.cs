using System;

namespace HR.Hospital.Client.Models
{
    /// <summary>
    /// 日期类
    /// </summary>
    public partial class Times
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? DateTimes { get; set; }

        /// <summary>
        /// 姓名Id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 班次Id
        /// </summary>
        public int? ShiftsId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
