namespace HR.Hospital.Client.Models
{

    /// <summary>
    /// 活动主表
    /// </summary>
    public class ActivityTable
    {
        public int Id { get; set; }

        /// <summary>
        /// 主表名称(最上面下拉)
        /// </summary>
        public string ActivityName { get; set; }
    }
}
