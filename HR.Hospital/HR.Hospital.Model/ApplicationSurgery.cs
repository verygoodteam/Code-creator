using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Model
{
    public class ApplicationSurgery
    {
        /// <summary>
        /// 手术申请Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///患者Id 
        /// </summary>
        public int PatientId { get; set; }

        /// <summary>
        /// 手术表Id
        /// </summary>
        public int OperationsId { get; set; }

        /// <summary>
        /// 申请人id
        /// </summary>
        public int ApplyPerson { get; set; }

        /// <summary>
        /// 科室Id
        /// </summary>
        public int AdministrativeId { get; set; }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyDate { get; set; }

        /// <summary>
        /// 麻药师
        /// </summary>
        public int AnesthesiologistId { get; set; }

        /// <summary>
        /// 巡回
        /// </summary>
        public int TourUserId { get; set; }

        /// <summary>
        ///  器械人员
        /// </summary>
        public int ApparatusUserId { get; set; }

        /// <summary>
        ///  主刀医生
        /// </summary>
        public int OperationUserId { get; set; }

        /// <summary>
        ///  是否排班
        /// </summary>
        public int IsSched { get; set; }
        
        /// <summary>
        ///  备注
        /// </summary>
        public string OperationRemark { get; set; }
    }
}
