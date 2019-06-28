using HR.Hospital.Client.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Hospital.Client.Models
{
    public class Ooperationuser
    {
        public Ooperationuser()
        {

        }
        public int Id { get; set; }
        public string OoperationUserName { get; set; }
        public string Account { get; set; }
        public string Jobnumber { get; set; }
        public string Pwd { get; set; }
        public int? Sex { get; set; }
        public string Phone { get; set; }
        public string Simplename { get; set; }
        public int? Isarrange { get; set; }
        public int? Roleid { get; set; }
        public int? Userid { get; set; }
        public int? PositionId { get; set; }
        public int? ProfessionalId { get; set; }
        public int? HierarchyId { get; set; }
        public int? Workage { get; set; }
        public DateTime? Enrollmentdate { get; set; }
        public int? Annualdays { get; set; }
        public string Grade { get; set; }
        public string OoperationUserRemark { get; set; }
        public virtual List<UserRolePermissionDto> PermissionList { get; set; }
    }
}
