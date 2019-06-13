namespace HR.Hospital.Client.Models
{
    /// <summary>
    /// 专业组类
    /// </summary>
    public partial class Professionalgroup
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 专业组名称
        /// </summary>
        public string ProfessionalGroupName { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string ProfessionalGroupColore { get; set; }

        /// <summary>
        /// 关联科室
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// 带教
        /// </summary>
        public int? TeachingId { get; set; }

        /// <summary>
        /// 组长
        /// </summary>
        public int? GroupLeader { get; set; }

        /// <summary>
        /// 组员
        /// </summary>
        public string TeamMember { get; set; }
    }
}
