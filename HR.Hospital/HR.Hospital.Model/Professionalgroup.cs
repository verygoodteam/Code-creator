using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class Professionalgroup
    {
        public int Id { get; set; }
        public string ProfessionalGroupName { get; set; }
        public string ProfessionalGroupColore { get; set; }
        public int? DepartmentId { get; set; }
        public int? TeachingId { get; set; }
        public int? GroupLeader { get; set; }
        public string TeamMember { get; set; }
    }
}
