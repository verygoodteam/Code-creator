namespace HR.Hospital.Client.Models
{
    public class UserLevel
    {
        public int Id { get; set; }

        /// <summary>
        /// 级别名称
        /// </summary>
        public string LevelName { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 职务Id
        /// </summary>
        public int PositionId { get; set; }
    }
}
