using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class Operationscheduling
    {
        public int Id { get; set; }
        public int? OperatingRoomId { get; set; }
        public int? TableNumber { get; set; }
        public int? InpatientArea { get; set; }
        public int? OperationId { get; set; }
        public int? OperationUserId { get; set; }
        public int? ApparatusUserId { get; set; }
        public int? TourUserId { get; set; }
        public int? AnesthesiologistId { get; set; }
        public int? PatientId { get; set; }
        public string OperationRemark { get; set; }
    }
}
