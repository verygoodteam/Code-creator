using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 职称类
    /// </summary>
    public partial class Professional
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 职称名称
        /// </summary>
        public string ProfessionalName { get; set; }
    }
}
