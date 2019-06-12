using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 科室类
    /// </summary>
    public partial class Administrative
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 科室名称
        /// </summary>
        public string AdministrativeName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int? Isoperation { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string AdministrativeRemark { get; set; }
    }
}
