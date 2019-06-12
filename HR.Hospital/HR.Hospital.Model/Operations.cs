using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 手术类
    /// </summary>
    public partial class Operations
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 手术名称
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// 科室Id
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string OperationCreateTime { get; set; }
    }
}
