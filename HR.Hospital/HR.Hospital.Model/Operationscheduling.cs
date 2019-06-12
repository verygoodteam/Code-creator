using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 手术排班类
    /// </summary>
    public partial class Operationscheduling
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 手术间Id
        /// </summary>
        public int? OperatingRoomId { get; set; }

        /// <summary>
        /// 台次
        /// </summary>
        public int? TableNumber { get; set; }

        /// <summary>
        /// 病区|科室
        /// </summary>
        public int? InpatientArea { get; set; }

        /// <summary>
        /// 手术名称Id
        /// </summary>
        public int? OperationId { get; set; }

        /// <summary>
        /// 主刀医生
        /// </summary>
        public int? OperationUserId { get; set; }

        /// <summary>
        /// 器械人员
        /// </summary>
        public int? ApparatusUserId { get; set; }

        /// <summary>
        /// 巡回
        /// </summary>
        public int? TourUserId { get; set; }

        /// <summary>
        /// 麻药师
        /// </summary>
        public int? AnesthesiologistId { get; set; }

        /// <summary>
        /// 患者Id
        /// </summary>
        public int? PatientId { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OperationRemark { get; set; }
    }
}
