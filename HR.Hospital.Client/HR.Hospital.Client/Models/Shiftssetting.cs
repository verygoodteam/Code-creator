using System;

namespace HR.Hospital.Client.Models
{
    /// <summary>
    /// 班次设置类
    /// </summary>
    public partial class Shiftssetting
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 班次颜色
        /// </summary>
        public string Shiftssettingcolour { get; set; }

        /// <summary>
        /// 班次名称
        /// </summary>
        public string ShiftssettingName { get; set; }

        /// <summary>
        /// 上班时间
        /// </summary>
        public DateTime? Opentime { get; set; }

        /// <summary>
        /// 下班时间
        /// </summary>
        public DateTime? Closingtime { get; set; }

        /// <summary>
        /// 有效工作日
        /// </summary>
        public string Validtime { get; set; }

        /// <summary>
        /// 计算工时
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// 是否打卡
        /// </summary>
        public int? Isclock { get; set; }

        /// <summary>
        /// 班次类型
        /// </summary>
        public int? Shiftssettingtypeid { get; set; }

        /// <summary>
        /// 班次顺序
        /// </summary>
        public int? Sortid { get; set; }

        /// <summary>
        /// 有效排班日
        /// </summary>
        public string Validday { get; set; }
    }
}
