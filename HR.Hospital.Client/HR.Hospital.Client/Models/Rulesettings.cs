using System;

namespace HR.Hospital.Client.Models
{
    /// <summary>
    /// 规则设置类
    /// </summary>
    public partial class Rulesettings
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 班次id
        /// </summary>
        public int? ShiftsId { get; set; }

        /// <summary>
        /// 时间一
        /// </summary>
        public DateTime? OneTime { get; set; }

        /// <summary>
        /// 时间二
        /// </summary>
        public DateTime? TwoTime { get; set; }

        /// <summary>
        /// 时间三
        /// </summary>
        public DateTime? ThreeTime { get; set; }

        /// <summary>
        /// 规则类型
        /// </summary>
        public bool? Types { get; set; }
    }
}
