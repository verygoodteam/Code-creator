using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 职务类
    /// </summary>
    public partial class Position
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 职务名称
        /// </summary>
        public string PositionName { get; set; }
    }
}
