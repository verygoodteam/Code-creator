namespace HR.Hospital.Client.Models
{
    /// <summary>
    /// 角色权限表
    /// </summary>
    public partial class RolePermission
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 权限编号
        /// </summary>
        public int? Pid { get; set; }

        /// <summary>
        /// 角色编号
        /// </summary>
        public int? Rid { get; set; }
    }
}
