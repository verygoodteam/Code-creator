using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    public partial class Clinicuser
    {
        public int Id { get; set; }
        public string ClinicUserName { get; set; }
        public int? Aadministrativeid { get; set; }
        public string Jobnumber { get; set; }
        public int? Sex { get; set; }
        public string ClinicUserRemark { get; set; }
    }
}
