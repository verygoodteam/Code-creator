using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Client.Models.Dto
{
   public class PermissionDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string PermissionsName { get; set; }

        /// <summary>
        /// 父权限名称
        /// </summary>
        public string FatherName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 父级编号
        /// </summary>
        public int? Pid { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int? Isnable { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Createtime { get; set; }
    }
}
