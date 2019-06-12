using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 用户角色类
    /// </summary>
    public partial class UserRole
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int? Uid { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public int? Rid { get; set; }
    }
}
