namespace HR.Hospital.Client.Models.Dto
{
    public class AreaRoomDto
    {
        public int Id { get; set; }

        /// <summary>
        /// 院区Id
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 院区名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 手术间名称
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OperationRemark { get; set; }


    }
}
