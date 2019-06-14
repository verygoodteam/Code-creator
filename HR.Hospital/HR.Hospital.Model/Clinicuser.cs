using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 临床用户类
    /// </summary>
    public partial class Clinicuser
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string ClinicUserName { get; set; }

        /// <summary>
        /// 所属科室
        /// </summary>
        public int? Aadministrativeid { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string Jobnumber { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string ClinicUserRemark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int IsEnable { get; set; }
    }
}
