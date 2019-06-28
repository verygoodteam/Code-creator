using System;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "权限名称")]
        public string PermissionsName { get; set; }

        /// <summary>
        /// 父权限名称
        /// </summary>
        [Display(Name = "父权限名称")]
        public string FatherName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        public string Url { get; set; }

        /// <summary>
        /// 父级编号
        /// </summary>
        [Display(Name = "父级编号")]
        public int? Pid { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Display(Name = "是否启用")]
        public int? IsEnable { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }
    }
}
