using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Model
{
    public class PatchCard
    {
        public int Id { get; set; }
        public DateTime Unpunched { get; set; }
        public string Reason { get; set; }
        public int ApplicantId { get; set; }
    }
}
