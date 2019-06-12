using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 院区表
    /// </summary>
    public partial class Area
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 院区名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 手术间数量
        /// </summary>
        public int? OperatingNum { get; set; }

        /// <summary>
        /// 院区属性
        /// </summary>
        public int? AreaProperty { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int? Isnable { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string AreaRemark { get; set; }
    }
}
