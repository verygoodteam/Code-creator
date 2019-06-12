using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 能级类
    /// </summary>
    public partial class Hierarchy
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 能级名称
        /// </summary>
        public string HierarchyName { get; set; }
    }
}
